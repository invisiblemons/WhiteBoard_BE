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
    public interface ICampaignRepository
    {
        Task<CampaignDetail> AddtAsync(PostCampaign campaign);
        Task<CampaignDetail> DeleteAsync(Guid ID);
        Task<CampaignDetail> GetByIdAsync(Guid ID);
        Task<SearchCampaignResult> SearchCampaign(string keyWord, int page, int pageSize, string sortBy, string order, DateTime? from, DateTime? to, Guid? universityid, Guid? campusid);
        Task<CampaignDetail> UpdateAsync(PutCampaign campaign);
    }

    public class CampaignRepository : ICampaignRepository
    {
        private readonly WhiteboardContext context;

        public CampaignRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        //public async Task<IEnumerable<CampaignDetail>> GetAllAsync()
        //{
        //    return await context.Campaigns.ToListAsync();
        //}

        public async Task<CampaignDetail> GetByIdAsync(Guid ID)
        {
            return new CampaignDetail(await context.Campaigns.Include(c => c.Criteria)
                                                .Include(c => c.Campus).ThenInclude(campus => campus.University)
                                                .AsNoTracking().FirstOrDefaultAsync(c => c.Id == ID));
        }

        public async Task<CampaignDetail> AddtAsync(PostCampaign campaign)
        {
            var result = await context.Campaigns.AddAsync(new Campaign
            {
                Id = Guid.NewGuid(),
                Name = campaign.Name,
                CampusId = campaign.CampusId,
                Description = campaign.Description,
                StartDay = campaign.StartDay,
                EndDay = campaign.EndDay,
                Image = campaign.Image
            });
            foreach (CriterionForPostCampaign criterion in campaign.Criterions)
            {
                await context.Criterions.AddAsync(new Criterion
                {
                    Id = Guid.NewGuid(),
                    CampaignId = result.Entity.Id,
                    Name = criterion.Name
                });
            }
            await context.SaveChangesAsync();
            var campaignDetail = await GetByIdAsync(result.Entity.Id);
            // nofi
            if (campaignDetail != null)
            {
                var notification = new Entities.Notification {
                    Id = Guid.NewGuid(),
                    OnDateTime = DateTime.Now,
                    Type = MyConstant.CreateCampaign,
                    AboutCampaignID = campaignDetail.Id,
                    TopicCampusID = campaignDetail.CampusId
                };
                var message = new Message()
                {
                    Topic = notification.GetTopic(),
                    Data = new Dictionary<string, string>()
                    {
                        { "OnDateTime", notification.OnDateTime.ToString() },
                        { "AboutCampaignID", campaignDetail.Id.ToString() },
                    },
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = MyConstant.CreateCampaignTitle,
                        Body = MyConstant.CreateCampaignBody1 + campaign.Name + MyConstant.CreateCampaignBody2
                    }
                };
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                context.Notifications.Add(notification);
                await context.SaveChangesAsync();
            }

            return campaignDetail;
        }

        public async Task<CampaignDetail> UpdateAsync(PutCampaign campaign)
        {
            var result = await context.Campaigns.FirstOrDefaultAsync(c => (c.Id == campaign.Id) && (c.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Name = campaign.Name;
                result.Description = campaign.Description;
                result.StartDay = campaign.StartDay;
                result.EndDay = campaign.EndDay;
                result.Image = campaign.Image;
                result.CampusId = campaign.CampusId;
                result.Status = campaign.Status;

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }

        //public async Task<CampaignDetail> DeleteAsync(Guid ID)
        //{
        //    var result = await context.Campaigns.Include(c => c.Criterions)
        //                                        .Include(c => c.BelongToCampus).ThenInclude(campus => campus.BelongToUniversity)
        //                                        .AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);

        //    if (result != null)
        //    {
        //        context.Campaigns.Remove(result);
        //        await context.SaveChangesAsync();
        //        return new CampaignDetail(result);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<CampaignDetail> DeleteAsync(Guid ID)
        {
            var result = await context.Campaigns.Include(c => c.Reviews).ThenInclude(r => r.Reviewer).FirstOrDefaultAsync(c => (c.Id == ID) && (c.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = MyConstant.Deleted;

                if (result.Reviews != null && result.Reviews.Any())
                {
                    foreach (Review r in result.Reviews)
                    {
                        if (r.Status == MyConstant.Published)
                        {
                            r.Reviewer.PublishedReviews--;
                        } 
                        else
                        {
                            if (r.Status ==  MyConstant.Unpublished)
                            {
                                r.Reviewer.UnpublishedReviews--;
                            }
                            else
                            {
                                if (r.Status == MyConstant.Waiting)
                                {
                                    r.Reviewer.WaitingReviews--;
                                }
                            }
                        }
                        r.Status = MyConstant.Deleted;
                    }
                }

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }

        public async Task<SearchCampaignResult> SearchCampaign(String keyWord, int page, int pageSize, String sortBy, String order, DateTime? from, DateTime? to, Guid? universityid, Guid? campusid)
        {
        //    var campaigns = from c in context.Campaigns
        //                    join ca in context.Campuses
        //                    on c.CampusId equals ca.Id
        //                    join u in context.Universities
        //                    on ca.UniversityId equals u.Id
        //                    where (((universityid == null) || (u.Id == universityid)) &&
        //                            ((campusid == null) || (ca.Id == campusid)) &&
        //                            ((keyWord == null) || (c.Name.Contains(keyWord))) &&
        //                            (c.Status != MyConstant.Deleted))
        //                    select c;
            var campaigns = from c in context.Campaigns
                            select c;
            campaigns = campaigns.Include(c => c.Criteria)
                                 .Include(c => c.Campus).ThenInclude(ca => ca.University).Where(c => c.Status != MyConstant.Deleted);
            if (universityid != null)
            {
                campaigns = campaigns.Where(c => c.Campus.University.Id == universityid);
            }
            if (campusid != null)
            {
                campaigns = campaigns.Where(c => c.Campus.Id == campusid);
            }
            if (keyWord != null)
            {
                campaigns = campaigns.Where(c => c.Name.Contains(keyWord));
            }
            if (from != null)
            {
                campaigns = campaigns.Where(c => c.StartDay <= from);
            }
            if (to != null)
            {
                campaigns = campaigns.Where(c => to <= c.StartDay);
            }
            if (!String.IsNullOrWhiteSpace(order) && !String.IsNullOrWhiteSpace(sortBy))
            {
                if (order == MyConstant.Acs)
                {
                    if (sortBy == MyConstant.Name)
                    {
                        campaigns = campaigns.OrderBy(c => c.Name);
                    }
                    else
                    {
                        if (sortBy == MyConstant.StartDay)
                        {
                            campaigns = campaigns.OrderBy(c => c.StartDay);
                        }
                        else
                        {
                            campaigns = campaigns.OrderBy(c => c.EndDay);
                        }
                    }
                }
                else
                {
                    if (sortBy == MyConstant.Name)
                    {
                        campaigns = campaigns.OrderByDescending(c => c.Name);
                    }
                    else
                    {
                        if (sortBy == MyConstant.StartDay)
                        {
                            campaigns = campaigns.OrderByDescending(c => c.StartDay);
                        }
                        else
                        {
                            campaigns = campaigns.OrderByDescending(c => c.EndDay);
                        }
                    }
                }
            }
            campaigns = campaigns.AsNoTracking();
            int totalRow = await campaigns.CountAsync();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            page = page > totalPage ? totalPage : page;
            int skipRow = (page - 1) * pageSize;
            int takeRow = (totalRow - skipRow) > pageSize ? pageSize : (totalRow - skipRow);

            return new SearchCampaignResult
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
                Universityid = universityid,
                Campusid = campusid,
                Campaigns = totalRow == 0 ? null : (await campaigns.Skip(skipRow).Take(takeRow).ToListAsync()).Select(campaign => new CampaignDetail(campaign))
            };
        }
    }
}
