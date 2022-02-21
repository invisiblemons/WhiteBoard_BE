using System;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface ICampaignService
    {
        Task<CampaignDetail> AddAsync(PostCampaign campaign);
        Task<CampaignDetail> DeleteAsync(Guid id);
        Task<CampaignDetail> GetByIdAsync(Guid id);
        Task<SearchCampaignResult> SearchCampaign(string KeyWord, int Page, int PageSize, string SortBy, string Order, DateTime? From, DateTime? To, Guid? UniversityId, Guid? CampusId);
        Task<CampaignDetail> UpdateAsync(PutCampaign campaign);
    }

    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository repository;

        public CampaignService(ICampaignRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CampaignDetail> AddAsync(PostCampaign campaign)
        {
            return await repository.AddtAsync(campaign);
        }

        public async Task<CampaignDetail> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        //public async Task<IEnumerable<CampaignDetail>> GetAllAsync()
        //{
        //    return await repository.GetAllAsync();
        //}

        public async Task<CampaignDetail> UpdateAsync(PutCampaign campaign)
        {
            return await repository.UpdateAsync(campaign);
        }

        public async Task<CampaignDetail> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<SearchCampaignResult> SearchCampaign(String KeyWord, int Page, int PageSize, String SortBy, String Order, DateTime? From, DateTime? To, Guid? UniversityId, Guid? CampusId)
        {
            //SortBy = !String.IsNullOrWhiteSpace(SortBy) ? SortBy : MyConstant.Name;
            //Order = !String.IsNullOrWhiteSpace(Order) ? Order : MyConstant.Acs;
            Page = Page < 1 ? 1 : Page;
            PageSize = PageSize < 1 ? MyConstant.DefaultsPageSizeForSerch : PageSize;
            return await repository.SearchCampaign(KeyWord, Page, PageSize, SortBy, Order, From, To, UniversityId, CampusId);
        }
    }
}
