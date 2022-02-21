using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using Whiteboard.API.Extensions;

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.AdminOrReviewer)]
    [ApiController]
    [Route("api/v1.0/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService service;
        private readonly IDistributedCache cache;

        public ReviewController(IReviewService service, IDistributedCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ReviewDetail>>> GetAllReview()
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
        [HttpGet]
        public async Task<ActionResult<SearchReviewResult>> SearchReview(String keyword, int page, int pagesize, String sortby, String order, DateTime? from, DateTime? to, String status, Guid? campaignid, Guid? campusid, Guid? reviewerid, Guid? universityid, bool reloadredis = false)
        {
            try
            {
                //var queryString = HttpContext.Request.QueryString;

                //cache.

                //StringValues headerValues;
                //var userId = string.Empty;

                //if (HttpContext.Request.Headers.TryGetValue("authorization", out headerValues))
                //{
                //    userId = headerValues;
                //}

                SearchReviewResult result = null;
                string recordKey = nameof(SearchReview) + HttpContext.Request.QueryString + DateTime.Now.Day;
                recordKey = recordKey.Replace("?reloadredis=false", "").Replace("&reloadredis=false", "");
                if (reloadredis)
                {
                    recordKey = recordKey.Replace("?reloadredis=true", "").Replace("&reloadredis=true", "");
                } else
                {
                    result = await cache.GetRecordAsync<SearchReviewResult>(recordKey);
                }
                if (result == null)
                {
                    result = await service.SearchReview(keyword, page, pagesize, sortby, order, from, to, status, campaignid, campusid, reviewerid, universityid);
                    
                    await cache.SetRecordAsync<SearchReviewResult>(recordKey, result);
                }

                //SearchReviewResult result = await service.SearchReview(keyword, page, pagesize, sortby, order, from, to, status, campaignid, reviewerid);
                if (result.Reviews == null)
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

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReviewDetail>> GetReviewById(Guid id)
        {
            try
            {
                ReviewDetail review = await service.GetByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(review);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [Authorize(Roles = MyConstant.Admin)]
        [HttpPost("public/{id:Guid}")]
        public async Task<ActionResult<ReviewDetail>> MakeReviewPublicById(Guid id)
        {
            try
            {
                ReviewDetail review = await service.UpdateStatusOfReview(id, MyConstant.Published, null);
                if (review == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(review);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [Authorize(Roles = MyConstant.Admin)]
        [HttpPost("unpublic/{id:Guid}")]
        public async Task<ActionResult<ReviewDetail>> MakeReviewUnpublicById(Guid id, [FromBody] UnpublicReviewRequest unpublicReviewRequest)
        {
            try
            {
                ReviewDetail review = await service.UpdateStatusOfReview(id, MyConstant.Unpublished, unpublicReviewRequest.Message);
                if (review == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(review);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDetail>> CreateReview([Required] PostReview review)
        {
            try
            {
                ReviewDetail reviewNew = await service.AddAsync(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = reviewNew.Id }, reviewNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ReviewDetail>> UpdateReview([Required] PutReview review)
        {
            try
            {
                if (await service.GetByIdAsync(review.Id) == null)
                {
                    return NotFound($"University with Id = {review.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(review));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewDetail>> DeleteReview(Guid id)
        {
            try
            {
                var Review = await service.GetByIdAsync(id);
                if (Review == null)
                {
                    return NotFound($"University with Id = {id} not found");
                }
                else
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
    }
}
