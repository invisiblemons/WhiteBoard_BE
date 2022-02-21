using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface ICriterionService
    {
        Task<Criterion> AddAsync(Criterion criterion);
        Task<Criterion> DeleteAsync(Guid id);
        Task<IEnumerable<Criterion>> GetAllAsync();
        Task<Criterion> GetByIdAsync(Guid id);
        Task<Criterion> UpdateAsync(Criterion criterion);
    }

    public class CriterionService : ICriterionService
    {
        private readonly ICriterionRepository repository;

        public CriterionService(ICriterionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Criterion> AddAsync(Criterion criterion)
        {
            return await repository.AddtAsync(criterion);
        }

        public async Task<Criterion> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Criterion>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Criterion> UpdateAsync(Criterion criterion)
        {
            return await repository.UpdateAsync(criterion);
        }

        public async Task<Criterion> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
