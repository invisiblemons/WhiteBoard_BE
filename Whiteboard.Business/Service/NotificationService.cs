using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface INotificationService
    {
        Task<SearchNotificationResult> SearchNotification(int page, int pageSize, string sortBy, string order, DateTime? from, DateTime? to, Guid? reviewerId);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository respository;

        public NotificationService(INotificationRepository respository)
        {
            this.respository = respository;
        }
        public async Task<SearchNotificationResult> SearchNotification(int page, int pageSize, String sortBy, String order, DateTime? from, DateTime? to, Guid? reviewerId)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? MyConstant.DefaultsPageSizeForSerch : pageSize;
            return await respository.SearchNotification(page, pageSize, sortBy, order, from, to, reviewerId);
        }
    }
}
