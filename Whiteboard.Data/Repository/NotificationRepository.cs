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
    public interface INotificationRepository
    {
        Task<SearchNotificationResult> SearchNotification(int page, int pageSize, string sortBy, string order, DateTime? from, DateTime? to, Guid? reviewerId);
    }

    public class NotificationRepository : INotificationRepository
    {
        private readonly WhiteboardContext context;

        public NotificationRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        //public async Task<IEnumerable<CampaignDetail>> GetAllAsync()
        //{
        //    return await context.Campaigns.ToListAsync();
        //}

        //public async Task<Notification> GetByIdAsync(Guid ID)
        //{
        //    return await context.Notifications.FirstOrDefaultAsync(c => (c.Id == ID));
        //}

        //public async Task<CampaignDetail> AddtAsync(PostCampaign campaign)
        //{
        //    var result = await context.Campaigns.AddAsync(new Campaign
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = campaign.Name,
        //        CampusId = campaign.CampusId,
        //        Description = campaign.Description,
        //        StartDay = campaign.StartDay,
        //        EndDay = campaign.EndDay,
        //        Image = campaign.Image
        //    });
        //    //foreach (CriterionForPostCampaign criterion in campaign.Criterions)
        //    //{
        //    //    await context.Criterions.AddAsync(new Criterion {
        //    //        Id = Guid.NewGuid(),
        //    //        CampaignId = result.Entity.Id,
        //    //        Name = criterion.Name
        //    //    });
        //    //}
        //    await context.SaveChangesAsync();
        //    return await GetByIdAsync(result.Entity.Id);
        //}

        //public async Task<CampaignDetail> UpdateAsync(PutCampaign campaign)
        //{
        //    var result = await context.Campaigns.FirstOrDefaultAsync(c => (c.Id == campaign.Id) && (c.Status != MyConstant.Deleted));

        //    if (result != null)
        //    {
        //        result.Name = campaign.Name;
        //        result.Description = campaign.Description;
        //        result.StartDay = campaign.StartDay;
        //        result.EndDay = campaign.EndDay;
        //        result.Image = campaign.Image;
        //        result.CampusId = campaign.CampusId;

        //        await context.SaveChangesAsync();

        //        return await GetByIdAsync(result.Id);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

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

        //public async Task<CampaignDetail> DeleteAsync(Guid ID)
        //{
        //    var result = await context.Campaigns.AsNoTracking().FirstOrDefaultAsync(c => (c.Id == ID) && (c.Status != MyConstant.Deleted));

        //    if (result != null)
        //    {
        //        result.Status = MyConstant.Deleted;

        //        await context.SaveChangesAsync();

        //        return await GetByIdAsync(result.Id);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<SearchNotificationResult> SearchNotification(int page, int pageSize, String sortBy, String order, DateTime? from, DateTime? to, Guid? reviewerId)
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
            var notifications = from c in context.Notifications
                                select c;
            notifications = notifications.Include(n => n.Review).Include(n => n.Campaign);
            if (reviewerId != null)
            {
                var reviewer = await context.Reviewers.Include(r => r.Major).
                                           FirstOrDefaultAsync(r => (r.Id == reviewerId && r.Status != MyConstant.Deleted));
                notifications = notifications.Where(n => ((n.TopicCampusID != null && n.TopicCampusID == reviewer.Major.CampusId) ||
                                                          (n.TopicReviewerID != null && n.TopicReviewerID == reviewer.Id)));
            }
            //if (!String.IsNullOrWhiteSpace(order) && !String.IsNullOrWhiteSpace(sortBy))
            //{
            //    if (order == MyConstant.Acs)
            //    {
            //        if (sortBy == MyConstant.Name)
            //        {
            //            campaigns = campaigns.OrderBy(c => c.Name);
            //        }
            //        else
            //        {
            //            if (sortBy == MyConstant.StartDay)
            //            {
            //                campaigns = campaigns.OrderBy(c => c.StartDay);
            //            }
            //            else
            //            {
            //                campaigns = campaigns.OrderBy(c => c.EndDay);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (sortBy == MyConstant.Name)
            //        {
            //            campaigns = campaigns.OrderByDescending(c => c.Name);
            //        }
            //        else
            //        {
            //            if (sortBy == MyConstant.StartDay)
            //            {
            //                campaigns = campaigns.OrderByDescending(c => c.StartDay);
            //            }
            //            else
            //            {
            //                campaigns = campaigns.OrderByDescending(c => c.EndDay);
            //            }
            //        }
            //    }
            //}
            notifications = notifications.AsNoTracking();
            int totalRow = await notifications.CountAsync();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            page = page > totalPage ? totalPage : page;
            int skipRow = (page - 1) * pageSize;
            int takeRow = (totalRow - skipRow) > pageSize ? pageSize : (totalRow - skipRow);

            return new SearchNotificationResult
            {
                Page = page,
                PageSize = pageSize,
                TotalPage = totalPage,
                TotalRows = totalRow,
                SortBy = sortBy,
                Order = order,
                From = from,
                To = to,
                ReviewerId = reviewerId,
                Notifications = totalRow == 0 ? null : (await notifications.Skip(skipRow).Take(takeRow).ToListAsync()).Select(n => new NotificationDetail(n))
            };
        }
    }
}
