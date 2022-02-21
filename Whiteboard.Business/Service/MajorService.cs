using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IMajorService
    {
        Task<Major> AddAsync(Major major);
        Task<Major> DeleteAsync(Guid id);
        Task<IEnumerable<Major>> GetAllAsync();
        Task<Major> GetByIdAsync(Guid id);
        Task<Major> UpdateAsync(Major major);
    }

    public class MajorService : IMajorService
    {
        private readonly IMajorRepository repository;

        public MajorService(IMajorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Major> AddAsync(Major major)
        {
            return await repository.AddtAsync(major);
        }

        public async Task<Major> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Major>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Major> UpdateAsync(Major major)
        {
            return await repository.UpdateAsync(major);
        }

        public async Task<Major> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
