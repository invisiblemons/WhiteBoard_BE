using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Repository
{
    public interface IReviewCriterionRepository
    {
        Task<ReviewCriterion> AddtAsync(ReviewCriterion reviewCriterion);
        Task<ReviewCriterion> DeleteAsync(Guid ID);
        Task<IEnumerable<ReviewCriterion>> GetAllAsync();
        Task<ReviewCriterion> GetByIdAsync(Guid ID);
        Task<ReviewCriterion> UpdateAsync(ReviewCriterion reviewCriterion);
    }

    public class ReviewCriterionRepository : IReviewCriterionRepository
    {
        private readonly WhiteboardContext context;

        public ReviewCriterionRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ReviewCriterion>> GetAllAsync()
        {
            return await context.ReviewCriteria.ToListAsync();
        }

        public async Task<ReviewCriterion> GetByIdAsync(Guid ID)
        {
            return await context.ReviewCriteria.AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);
        }

        public async Task<ReviewCriterion> AddtAsync(ReviewCriterion reviewCriterion)
        {
            reviewCriterion.Id = Guid.NewGuid();
            var result = await context.ReviewCriteria.AddAsync(reviewCriterion);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ReviewCriterion> UpdateAsync(ReviewCriterion reviewCriterion)
        {
            var result = await context.ReviewCriteria.FirstOrDefaultAsync(r => r.Id == reviewCriterion.Id);

            if (result != null)
            {
                result.Rating = reviewCriterion.Rating;
                result.ReviewId = reviewCriterion.ReviewId;
                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<ReviewCriterion> DeleteAsync(Guid ID)
        {
            var result = await context.ReviewCriteria.FirstOrDefaultAsync(r => (r.Id == ID) && (r.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = MyConstant.Deleted;

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }
    }
}
