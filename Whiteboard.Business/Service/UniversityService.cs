using System;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IUniversityService
    {
        Task<UniversityDetail> AddAsync(PostUniversity university);
        Task<UniversityDetail> DeleteAsync(Guid id);
        Task<UniversityDetail> GetByIdAsync(Guid id);
        Task<SearchUniversityResult> SearchUniversity(int page, int pageSize);
        Task<UniversityDetail> UpdateAsync(PutUniversity university);
    }

    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository repository;

        public UniversityService(IUniversityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UniversityDetail> AddAsync(PostUniversity university)
        {
            return await repository.AddtAsync(university);
        }

        public async Task<UniversityDetail> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        //public async Task<IEnumerable<University>> GetAllAsync()
        //{
        //    return await repository.GetAllAsync();
        //}

        public async Task<UniversityDetail> UpdateAsync(PutUniversity university)
        {
            return await repository.UpdateAsync(university);
        }

        public async Task<UniversityDetail> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<SearchUniversityResult> SearchUniversity(int page, int pageSize)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? MyConstant.DefaultsPageSizeForSerch : pageSize;
            return await repository.SearchUniversity(page, pageSize);
        }
    }
}
