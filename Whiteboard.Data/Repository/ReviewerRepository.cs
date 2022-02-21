using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using System.Linq;
using FirebaseAdmin.Messaging;

namespace Whiteboard.Data.Repository
{
    public interface IReviewerRepository
    {
        Task<Reviewer> AddtAsync(Reviewer reviewer);
        Task<Reviewer> DeleteAsync(Guid ID);
        Task<IEnumerable<Reviewer>> GetAllAsync();
        Task<Reviewer> GetByFireBaseUIdAsync(string FireBaseUId);
        Task<ReviewerDetail> GetByIdAsync(Guid ID);
        Task<Reviewer> UpdateAsync(Reviewer reviewer);
        Task<SearchReviewerResult> SearchReviewer(int page, int pageSize, Guid? campusId, Guid? universityId);
    }

    public class ReviewerRepository : IReviewerRepository
    {
        private readonly WhiteboardContext context;

        public ReviewerRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Reviewer>> GetAllAsync()
        {
            return await context.Reviewers.ToListAsync();
        }

        public async Task<ReviewerDetail> GetByIdAsync(Guid ID)
        {
            return new ReviewerDetail( await context.Reviewers.Include(r => r.Major).ThenInclude(m => m.Campus).ThenInclude(c => c.University).AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID));
        }

        public async Task<Reviewer> GetByFireBaseUIdAsync(String FireBaseUId)
        {
            return await context.Reviewers.Include(r => r.Major).ThenInclude(m => m.Campus).ThenInclude(ca => ca.University).
                                           FirstOrDefaultAsync(r => (r.FireBaseUId == FireBaseUId && r.Status != MyConstant.Deleted));
        }

        public async Task<Reviewer> AddtAsync(Reviewer reviewer)
        {
            reviewer.Id = Guid.NewGuid();
            var result = await context.Reviewers.AddAsync(reviewer);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Reviewer> UpdateAsync(Reviewer reviewer)
        {
            var result = await context.Reviewers.FirstOrDefaultAsync(r => r.Id == reviewer.Id);

            if (result != null)
            {
                result.Name = reviewer.Name;
                result.Birthday = reviewer.Birthday;
                result.Email = reviewer.Email;
                result.PhoneNumber = reviewer.PhoneNumber;
                result.MajorId = reviewer.MajorId;
                result.Avatar = reviewer.Avatar;
                result.Certification = reviewer.Certification;
                result.WhyBlocked = reviewer.WhyBlocked;

                //if (result.Status == MyConstant.Unverified && reviewer.Status == MyConstant.Verified)
                //{
                //    var notification = new Entities.Notification
                //    {
                //        Id = Guid.NewGuid(),
                //        OnDateTime = DateTime.Now,
                //        Type = MyConstant.VerifiedReviewer,
                //        TopicReviewerID = result.Id
                //    };
                //    var message = new Message()
                //    {
                //        Topic = notification.GetTopic(),
                //        Data = new Dictionary<string, string>()
                //    {
                //        { "OnDateTime", notification.OnDateTime.ToString() }
                //    },
                //        Notification = new FirebaseAdmin.Messaging.Notification
                //        {
                //            Title = MyConstant.VerifiedReviewerTitle,
                //            Body = MyConstant.VerifiedReviewerBody
                //        }
                //    };
                //    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                //    context.Notifications.Add(notification);
                //    await context.SaveChangesAsync();
                //}

                if (result.Status == MyConstant.Blocked && reviewer.Status == MyConstant.Verified)
                {
                    var notification = new Entities.Notification
                    {
                        Id = Guid.NewGuid(),
                        OnDateTime = DateTime.Now,
                        Type = MyConstant.UnBlockedReviewer,
                        TopicReviewerID = result.Id
                    };
                    var message = new Message()
                    {
                        Topic = notification.GetTopic(),
                        Data = new Dictionary<string, string>()
                    {
                        { "OnDateTime", notification.OnDateTime.ToString() }
                    },
                        Notification = new FirebaseAdmin.Messaging.Notification
                        {
                            Title = MyConstant.UnBlockedReviewerTitle,
                            Body = MyConstant.UnBlockedReviewerBody
                        }
                    };
                    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                    context.Notifications.Add(notification);
                    await context.SaveChangesAsync();
                }

                if (reviewer.Status == MyConstant.Blocked)
                {
                    var notification = new Entities.Notification
                    {
                        Id = Guid.NewGuid(),
                        OnDateTime = DateTime.Now,
                        Type = MyConstant.BlockedReviewer,
                        TopicReviewerID = result.Id
                    };
                    var message = new Message()
                    {
                        Topic = notification.GetTopic(),
                        Data = new Dictionary<string, string>()
                    {
                        { "OnDateTime", notification.OnDateTime.ToString() }
                    },
                        Notification = new FirebaseAdmin.Messaging.Notification
                        {
                            Title = MyConstant.BlockedReviewerTitle,
                            Body = MyConstant.BlockedReviewerBody + notification.WhyBlockedReviewer
                        }
                    };
                    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                    context.Notifications.Add(notification);
                    await context.SaveChangesAsync();
                }


                result.Status = reviewer.Status;
                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Reviewer> DeleteAsync(Guid ID)
        {
            var result = await context.Reviewers.FirstOrDefaultAsync(r => (r.Id == ID) && (r.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = MyConstant.Deleted;

                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<SearchReviewerResult> SearchReviewer(int page, int pageSize, Guid? campusId, Guid? universityId)
        {
            var reviewers = from r in context.Reviewers
                            select r;
            reviewers = reviewers.Include(r => r.Major).ThenInclude(m => m.Campus).Where(r => r.Status != MyConstant.Deleted);
            if (campusId != null)
            {
                reviewers = reviewers.Where(r => r.Major.Campus.Id == campusId);
            }
            if (universityId != null)
            {
                reviewers = reviewers.Where(r => r.Major.Campus.University.Id == universityId);
            }
            reviewers = reviewers.AsNoTracking();
            int totalRow = await reviewers.CountAsync();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            page = page > totalPage ? totalPage : page;
            int skipRow = (page - 1) * pageSize;
            int takeRow = (totalRow - skipRow) > pageSize ? pageSize : (totalRow - skipRow);
            return new SearchReviewerResult
            {
                Page = page,
                PageSize = pageSize,
                TotalPage = totalPage,
                TotalRows = totalRow,
                Reviewers = totalRow == 0 ? null : (await reviewers.Skip(skipRow).Take(takeRow).ToListAsync()).Select(reviewers => new ReviewerDetail(reviewers))
            };
        }
    }
}
