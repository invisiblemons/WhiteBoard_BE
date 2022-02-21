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
    public interface IPictureForReviewRepository
    {
        Task<PictureForReview> AddtAsync(PictureForReview pictureForReview);
        Task<PictureForReview> DeleteAsync(Guid ID);
        Task<IEnumerable<PictureForReview>> GetAllAsync();
        Task<PictureForReview> GetByIdAsync(Guid ID);
        Task<PictureForReview> UpdateAsync(PictureForReview pictureForReview);
    }

    public class PictureForReviewRepository : IPictureForReviewRepository
    {
        private readonly WhiteboardContext context;

        public PictureForReviewRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PictureForReview>> GetAllAsync()
        {
            return await context.PictureForReviews.ToListAsync();
        }

        public async Task<PictureForReview> GetByIdAsync(Guid ID)
        {
            return await context.PictureForReviews.AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);
        }

        public async Task<PictureForReview> AddtAsync(PictureForReview pictureForReview)
        {
            pictureForReview.Id = Guid.NewGuid();
            var result = await context.PictureForReviews.AddAsync(pictureForReview);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PictureForReview> UpdateAsync(PictureForReview pictureForReview)
        {
            var result = await context.PictureForReviews.FirstOrDefaultAsync(r => r.Id == pictureForReview.Id);

            if (result != null)
            {
                result.Picture = pictureForReview.Picture;
                await context.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<PictureForReview> DeleteAsync(Guid ID)
        {
            var result = await context.PictureForReviews.FirstOrDefaultAsync(p => (p.Id == ID) && (p.Status != MyConstant.Deleted));

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
