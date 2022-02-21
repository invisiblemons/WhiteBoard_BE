using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface ICampusService
    {
        Task<Campus> AddAsync(Campus campus);
        Task<Campus> DeleteAsync(Guid id);
        Task<IEnumerable<Campus>> GetAllAsync();
        Task<Campus> GetByIdAsync(Guid id);
        Task<Campus> UpdateAsync(Campus campus);
    }

    public class CampusService : ICampusService
    {
        private readonly ICampusRepository repository;

        public CampusService(ICampusRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Campus> AddAsync(Campus campus)
        {
            return await repository.AddtAsync(campus);
        }

        public async Task<Campus> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Campus>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Campus> UpdateAsync(Campus campus)
        {
            return await repository.UpdateAsync(campus);
        }

        public async Task<Campus> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
