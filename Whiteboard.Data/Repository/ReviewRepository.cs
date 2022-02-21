using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;

namespace Whiteboard.Data.Repository
{
    public interface IReviewRepository
    {
        Task<ReviewDetail> AddtAsync(PostReview review);
        Task<ReviewDetail> DeleteAsync(Guid ID);
        Task<ReviewDetail> GetByIdAsync(Guid ID);
        Task<SearchReviewResult> SearchReview(string keyWord, int page, int pageSize, string sortBy, string order, DateTime? from, DateTime? to, string status, Guid? campaignId, Guid? reviewerId, Guid? campusId, Guid? universityId);
        Task<ReviewDetail> UpdateAsync(PutReview review);
        Task<ReviewDetail> UpdateStatusOfReview(Guid id, string status, string message);
    }

    public class ReviewRepository : IReviewRepository
    {
        private readonly WhiteboardContext context;

        public ReviewRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        //public async Task<IEnumerable<ReviewDetail>> GetAllAsync()
        //{
        //    return await context.Reviews.ToListAsync();
        //}

        public async Task<ReviewDetail> GetByIdAsync(Guid ID)
        {
            return new ReviewDetail(await context.Reviews.Include(r => r.ReviewCriteria).ThenInclude(rc => rc.Criterion)
                             .Include(r => r.Campaign).ThenInclude(c => c.Campus).ThenInclude(ca => ca.University)
                             .Include(r => r.Reviewer)
                             .Include(r => r.PictureForReviews).AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID));
        }

        public async Task<ReviewDetail> AddtAsync(PostReview review)
        {
            var result = await context.Reviews.AddAsync(new Review
            {
                Id = Guid.NewGuid(),
                Title = review.Title,
                Content = review.Content,
                CampaignId = review.CampaignId,
                ReviewerId = review.ReviewerId,
                OnDateTime = DateTime.Now,
                Status = MyConstant.Waiting
            });
            if (review.Images != null)
            {
                foreach (ImageForPostReview image in review.Images)
                {
                    await context.PictureForReviews.AddAsync(new PictureForReview
                    {
                        Id = Guid.NewGuid(),
                        ReviewId = result.Entity.Id,
                        Picture = image.Image
                    });
                }
            }
            if (review.Criterions != null)
            {
                foreach (CriterionForPostReview criterion in review.Criterions)
                {
                    await context.ReviewCriteria.AddAsync(new ReviewCriterion
                    {
                        Id = Guid.NewGuid(),
                        ReviewId = result.Entity.Id,
                        CriterionId = criterion.CriterionId,
                        Rating = criterion.Rating
                    });
                }
            }
            Campaign campaign = await context.Campaigns.FirstOrDefaultAsync(r => r.Id == result.Entity.CampaignId);
            if (campaign != null)
            {
                campaign.WaitingReviews += 1;
            }
            Reviewer reviewer = await context.Reviewers.FirstOrDefaultAsync(r => r.Id == result.Entity.ReviewerId);
            if (reviewer != null)
            {
                reviewer.WaitingReviews += 1;
            }
            await context.SaveChangesAsync();
            return await GetByIdAsync(result.Entity.Id);
        }

        public async Task<ReviewDetail> UpdateAsync(PutReview review)
        {
            var result = await context.Reviews.FirstOrDefaultAsync(r => (r.Id == review.Id) && (r.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = review.Status;
                result.Title = review.Title;
                result.Content = review.Content;
                result.CampaignId = review.CampaignId;
                result.ReviewerId = review.ReviewerId;

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }

        //public async Task<ReviewDetail> DeleteAsync(Guid ID)
        //{
        //    var result = await context.Reviews.FirstOrDefaultAsync(r => r.Id == ID);

        //    if (result != null)
        //    {
        //        context.Reviews.Remove(result);
        //        await context.SaveChangesAsync();
        //        return new ReviewDetail(result);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<ReviewDetail> DeleteAsync(Guid ID)
        {
            var result = await context.Reviews.FirstOrDefaultAsync(r => (r.Id == ID) && (r.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = MyConstant.Deleted;

                await context.SaveChangesAsync();

                return new ReviewDetail(result);
            }
            else
            {
                return null;
            }
        }


        public async Task<SearchReviewResult> SearchReview(string keyWord, int page, int pageSize, string sortBy, string order, DateTime? from, DateTime? to, string status, Guid? campaignId, Guid? reviewerId, Guid? campusId, Guid? universityId)
        {
            //var reviews = from r in context.Reviews
            //              join re in context.Reviewers
            //              on r.ReviewerId equals re.Id
            //              join c in context.Campaigns
            //              on r.CampaignId equals c.Id
            //              where ((String.IsNullOrWhiteSpace(status) || (r.Status == status)) &&
            //                    ((campaignId == null) || (r.CampaignId == campaignId)) &&
            //                    ((reviewerId == null) || (r.ReviewerId == reviewerId)) &&
            //                    ((keyWord == null) || (r.Title.Contains(keyWord))) &&
            //                    (r.Status != MyConstant.Deleted))
            //              select r;
            var reviews = from r in context.Reviews
                          select r;

            reviews = reviews.Include(r => r.ReviewCriteria).ThenInclude(rc => rc.Criterion)
                             .Include(r => r.Campaign).ThenInclude(ca => ca.Campus).ThenInclude(ca => ca.University)
                             .Include(r => r.Reviewer)
                             .Include(r => r.PictureForReviews);
            if (status == null)
            {
                reviews = reviews.Where(r => r.Status != MyConstant.Deleted);
            } else
            {
                reviews = reviews.Where(r => r.Status == status);
            }
            if (campusId != null)
            {
                reviews = reviews.Where(r => r.Campaign.Campus.Id == campusId);
            }
            if (campaignId != null)
            {
                reviews = reviews.Where(r => r.Campaign.Id == campaignId);
            }
            if (reviewerId != null)
            {
                reviews = reviews.Where(r => r.Reviewer.Id == reviewerId);
            }
            if (universityId != null)
            {
                reviews = reviews.Where(r => r.Campaign.Campus.University.Id == universityId);
            }
            if (keyWord != null)
            {
                reviews = reviews.Where(r => r.Title.Contains(keyWord));
            }

            if (from != null)
            {
                reviews = reviews.Where(c => c.OnDateTime <= from);
            }
            if (to != null)
            {
                reviews = reviews.Where(c => to <= c.OnDateTime);
            }
            if (!String.IsNullOrWhiteSpace(order) && !String.IsNullOrWhiteSpace(sortBy))
            {
                if (order == MyConstant.Acs)
                {
                    if (sortBy == MyConstant.Title)
                    {
                        reviews = reviews.OrderBy(c => c.Title);
                    }
                    else
                    {
                        reviews = reviews.OrderBy(c => c.OnDateTime);
                    }
                }
                else
                {
                    if (sortBy == MyConstant.Title)
                    {
                        reviews = reviews.OrderByDescending(c => c.Title);
                    }
                    else
                    {
                        reviews = reviews.OrderByDescending(c => c.OnDateTime);
                    }
                }
            }

            reviews = reviews.AsNoTracking();
            int totalRow = await reviews.CountAsync();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            page = page > totalPage ? totalPage : page;
            int skipRow = (page - 1) * pageSize;
            int takeRow = (totalRow - skipRow) > pageSize ? pageSize : (totalRow - skipRow);
            return new SearchReviewResult
            {
                KeyWord = keyWord,
                Page = page,
                PageSize = pageSize,
                TotalPage = totalPage,
                TotalRows = totalRow,
                SortBy = sortBy,
                Order = order,
                From = from,
                To = to,
                Status = status,
                CampaignId = campaignId,
                ReviewerId = reviewerId,
                UniversityId = universityId,
                Reviews = totalRow == 0 ? null : (await reviews.Skip(skipRow).Take(takeRow).ToListAsync()).Select(r => new ReviewDetail(r))
            };
        }

        public async Task<ReviewDetail> UpdateStatusOfReview(Guid id, string status, string message)
        {
            var result = await context.Reviews.Include(r => r.Reviewer).
                                                Include(r => r.Campaign).
                                                Include(r => r.ReviewCriteria).ThenInclude(rc => rc.Criterion).
                                                FirstOrDefaultAsync(r => (r.Id == id) && (r.Status != MyConstant.Deleted));

            if (result != null)
            {
                if (result.Status == MyConstant.Unpublished)
                {
                    result.Campaign.UnpublishedReviews--;
                    result.Reviewer.UnpublishedReviews--;
                }
                else
                {
                    if (result.Status == MyConstant.Waiting)
                    {
                        result.Campaign.WaitingReviews--;
                        result.Reviewer.WaitingReviews--;
                    } else
                    {
                        if (result.Status == MyConstant.Published)
                        {
                            result.Campaign.PublishedReviews--;
                            result.Reviewer.PublishedReviews--;
                        }
                    }
                }

                if (status == MyConstant.Published)
                {
                    result.Campaign.PublishedReviews++;
                    result.Reviewer.PublishedReviews++;
                }
                else
                {
                    if (status == MyConstant.Waiting)
                    {
                        result.Campaign.WaitingReviews++;
                        result.Reviewer.WaitingReviews++;
                    }
                    else
                    {
                        if (status == MyConstant.Unpublished)
                        {
                            result.Campaign.UnpublishedReviews++;
                            result.Reviewer.UnpublishedReviews++;
                        }
                    }
                }

                if ((result.Status == MyConstant.Unpublished || result.Status == MyConstant.Waiting ) &&
                    status == MyConstant.Published)
                {
                    foreach (var reviewCriteria in result.ReviewCriteria)
                    {
                        var rating = reviewCriteria.Criterion.GetRating();
                        rating[reviewCriteria.Rating - 1]++;
                        reviewCriteria.Criterion.SetRating(rating);
                    }
                }

                if ((status == MyConstant.Unpublished || status == MyConstant.Waiting || status == MyConstant.Locked) &&
                    result.Status == MyConstant.Published)
                {
                    foreach (var reviewCriteria in result.ReviewCriteria)
                    {
                        var rating = reviewCriteria.Criterion.GetRating();
                        rating[reviewCriteria.Rating - 1]--;
                        reviewCriteria.Criterion.SetRating(rating);
                    }
                }


                result.Status = status;
                result.WhyNotPublic = message;

                await context.SaveChangesAsync();

                var reviewDetail = await GetByIdAsync(result.Id);

                if (reviewDetail != null)
                {
                    if (status == MyConstant.Published)
                    {
                        var notification = new Entities.Notification
                        {
                            Id = Guid.NewGuid(),
                            OnDateTime = DateTime.Now,
                            Type = MyConstant.PublicReview,
                            AboutReviewID = reviewDetail.Id,
                            TopicReviewerID = reviewDetail.ReviewerId
                        };
                        var m = new Message()
                        {
                            Topic = notification.GetTopic(),
                            Data = new Dictionary<string, string>()
                            {
                                { "OnDateTime", notification.OnDateTime.ToString() },
                                { "AboutReviewID", reviewDetail.Id.ToString() },
                            },
                            Notification = new FirebaseAdmin.Messaging.Notification
                            {
                                Title = MyConstant.PublicReviewTitle,
                                Body = MyConstant.PublicReviewBody1 + result.Title + MyConstant.PublicReviewBody2
                            }
                        };
                        string response = await FirebaseMessaging.DefaultInstance.SendAsync(m);
                        context.Notifications.Add(notification);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        if (status == MyConstant.Unpublished)
                        {
                            var notification = new Entities.Notification
                            {
                                Id = Guid.NewGuid(),
                                OnDateTime = DateTime.Now,
                                Type = MyConstant.UnPublicReview,
                                AboutReviewID = reviewDetail.Id,
                                TopicReviewerID = reviewDetail.ReviewerId
                            };
                            var m = new Message()
                            {
                                Topic = notification.GetTopic(),
                                Data = new Dictionary<string, string>()
                                {
                                    { "OnDateTime", notification.OnDateTime.ToString() },
                                    { "AboutReviewID", reviewDetail.Id.ToString() },
                                },
                                Notification = new FirebaseAdmin.Messaging.Notification
                                {
                                    Title = MyConstant.UnPublicReviewTitle,
                                    Body = MyConstant.UnPublicReviewBody1 + result.Title + MyConstant.UnPublicReviewBody2 + message
                                }
                            };
                            string response = await FirebaseMessaging.DefaultInstance.SendAsync(m);
                            context.Notifications.Add(notification);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            
                        }
                    }
                }

                return reviewDetail;
            }
            else
            {
                return null;
            }
        }
    }
}
