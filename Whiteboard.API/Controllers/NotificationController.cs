using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Whiteboard.API.Extensions;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Model;

namespace Whiteboard.API.Controllers
{
    //[Authorize(Roles = MyConstant.Reviewer)]
    [ApiController]
    [Route("api/v1.0/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService service;
        //private readonly IDistributedCache cache;

        public NotificationController(INotificationService service)//, IDistributedCache cache)
        {
            this.service = service;
            //this.cache = cache;
        }


        [HttpGet]
        public async Task<ActionResult<SearchNotificationResult>> searchnotification(int page, int pagesize, string sortby, string order, DateTime? from, DateTime? to, Guid? reviewerid)
        {
            try
            {
                //    string recordKey = nameof(SearchNotificationResult) + HttpContext.Request.QueryString + DateTime.Now.Hour + (DateTime.Now.Minute / 5);
                //    var result = await cache.GetRecordAsync<SearchNotificationResult>(recordKey);
                //    if (result == null)
                //    {
                //        result = await service.SearchNotification(page, pagesize, sortby, order, from, to, reviewerid);

                //        await cache.SetRecordAsync<SearchNotificationResult>(recordKey, result);
                //    }
                var result = await service.SearchNotification(page, pagesize, sortby, order, from, to, reviewerid);
            if (result.Notifications == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
