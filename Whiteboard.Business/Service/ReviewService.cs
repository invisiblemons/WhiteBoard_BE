using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IReviewService
    {
        Task<ReviewDetail> AddAsync(PostReview review);
        Task<ReviewDetail> DeleteAsync(Guid id);
        Task<ReviewDetail> GetByIdAsync(Guid id);
        Task<SearchReviewResult> SearchReview(string KeyWord, int Page, int PageSize, string SortBy, string Order, DateTime? From, DateTime? To, string Status, Guid? CampaignId, Guid? CampusId, Guid? ReviewerId, Guid? UniversityId);
        Task<ReviewDetail> UpdateAsync(PutReview review);
        Task<ReviewDetail> UpdateStatusOfReview(Guid id, string status, string message);
    }

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository repository;

        public ReviewService(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ReviewDetail> AddAsync(PostReview review)
        {
            return await repository.AddtAsync(review);
        }

        public async Task<ReviewDetail> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        //public async Task<IEnumerable<Review>> GetAllAsync()
        //{
        //    return await repository.GetAllAsync();
        //}

        public async Task<ReviewDetail> UpdateAsync(PutReview review)
        {
            if (review.Status == MyConstant.Locked)
            {
                return await repository.UpdateStatusOfReview(review.Id, MyConstant.Locked, "");
            }
            else
            {
                return await repository.UpdateAsync(review);
            }
        }

        public async Task<ReviewDetail> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<SearchReviewResult> SearchReview(String KeyWord, int Page, int PageSize, String SortBy, String Order, DateTime? From, DateTime? To, String Status, Guid? CampaignId, Guid? CampusId, Guid? ReviewerId, Guid? UniversityId)
        {
            //SortBy = !String.IsNullOrWhiteSpace(SortBy) ? SortBy : MyConstant.Title;
            //Order = !String.IsNullOrWhiteSpace(Order) ? Order : MyConstant.Acs;
            Page = Page < 1 ? 1 : Page;
            PageSize = PageSize < 1 ? MyConstant.DefaultsPageSizeForSerch : PageSize;
            return await repository.SearchReview(KeyWord, Page, PageSize, SortBy, Order, From, To, Status, CampaignId, ReviewerId, CampusId, UniversityId);
        }

        public async Task<ReviewDetail> UpdateStatusOfReview(Guid id, string status, string message)
        {
            return await repository.UpdateStatusOfReview(id, status, message);
        }
    }
}
