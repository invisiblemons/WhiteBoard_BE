using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IReviewCriterionService
    {
        Task<ReviewCriterion> AddAsync(ReviewCriterion reviewCriterion);
        Task<ReviewCriterion> DeleteAsync(Guid id);
        Task<IEnumerable<ReviewCriterion>> GetAllAsync();
        Task<ReviewCriterion> GetByIdAsync(Guid id);
        Task<ReviewCriterion> UpdateAsync(ReviewCriterion reviewCriterion);
    }

    public class ReviewCriterionService : IReviewCriterionService
    {
        private readonly IReviewCriterionRepository repository;

        public ReviewCriterionService(IReviewCriterionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ReviewCriterion> AddAsync(ReviewCriterion reviewCriterion)
        {
            return await repository.AddtAsync(reviewCriterion);
        }

        public async Task<ReviewCriterion> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ReviewCriterion>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<ReviewCriterion> UpdateAsync(ReviewCriterion reviewCriterion)
        {
            return await repository.UpdateAsync(reviewCriterion);
        }

        public async Task<ReviewCriterion> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
