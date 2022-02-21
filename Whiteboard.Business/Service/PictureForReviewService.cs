using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IPictureForReviewService
    {
        Task<PictureForReview> AddAsync(PictureForReview pictureForReview);
        Task<PictureForReview> DeleteAsync(Guid id);
        Task<IEnumerable<PictureForReview>> GetAllAsync();
        Task<PictureForReview> GetByIdAsync(Guid id);
        Task<PictureForReview> UpdateAsync(PictureForReview pictureForReview);
    }

    public class PictureForReviewService : IPictureForReviewService
    {
        private readonly IPictureForReviewRepository repository;

        public PictureForReviewService(IPictureForReviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PictureForReview> AddAsync(PictureForReview pictureForReview)
        {
            return await repository.AddtAsync(pictureForReview);
        }

        public async Task<PictureForReview> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PictureForReview>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<PictureForReview> UpdateAsync(PictureForReview pictureForReview)
        {
            return await repository.UpdateAsync(pictureForReview);
        }

        public async Task<PictureForReview> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
