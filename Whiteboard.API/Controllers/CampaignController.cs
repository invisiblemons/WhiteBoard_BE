using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Whiteboard.API.Extensions;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Model;

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.Admin)]
    [ApiController]
    [Route("api/v1.0/campaigns")]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService service;
        private readonly IDistributedCache cache;

        public CampaignsController(ICampaignService service, IDistributedCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaign()
        //{
        //    try
        //    {
        //        return Ok(await service.GetAllAsync());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CampaignDetail>> GetCampaignById(Guid id)
        {
            try
            {
                CampaignDetail campaign = await service.GetByIdAsync(id);
                if (campaign == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(campaign);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CampaignDetail>> CreateCampaign([Required] PostCampaign campaign)
        {
            try
            {
                CampaignDetail NewCampaign = await service.AddAsync(campaign);
                return CreatedAtAction(nameof(GetCampaignById), new { id = NewCampaign.Id }, NewCampaign);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<CampaignDetail>> UpdateCampaign([Required] PutCampaign campaign)
        {
            try
            {
                if (await service.GetByIdAsync(campaign.Id) == null)
                {
                    return NotFound($"Campaign with Id = {campaign.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(campaign));
                }
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CampaignDetail>> DeleteCampaign(Guid id)
        {
            try
            {
                var campaign = await service.GetByIdAsync(id);
                if (campaign == null)
                {
                    return NotFound($"Campaign with Id = {id} not found");
                } else
                {
                    return Ok(await service.DeleteAsync(id));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error delete data");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<SearchCampaignResult>> SearchCampaign(String keyword, int page, int pagesize,String sortby, String order, DateTime? from, DateTime? to, Guid? universityid, Guid? campusid, bool reloadredis = false)
        {
            try
            {
                SearchCampaignResult result = null;
                string recordKey = nameof(SearchCampaign) + HttpContext.Request.QueryString + DateTime.Now.Day;
                recordKey = recordKey.Replace("?reloadredis=false", "").Replace("&reloadredis=false", "");
                if (reloadredis)
                {
                    recordKey = recordKey.Replace("?reloadredis=true", "").Replace("&reloadredis=true", "");
                }
                else
                {
                    result = await cache.GetRecordAsync<SearchCampaignResult>(recordKey);
                }
                if (result == null)
                {
                    result = await service.SearchCampaign(keyword, page, pagesize, sortby, order, from, to, universityid, campusid);

                    await cache.SetRecordAsync<SearchCampaignResult>(recordKey, result);
                }
                //SearchCampaignResult result = await service.SearchCampaign(keyword, page, pagesize, sortby, order, from, to, universityid, campusid);
                if (result.Campaigns == null)
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
