using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Whiteboard.API.Extensions;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using static Whiteboard.API.Controllers.AdminsController;

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.AdminOrReviewer)]
    [ApiController]
    [Route("api/v1.0/reviewers")]
    public class ReviewersController : ControllerBase
    {
        private readonly IReviewerService service;
        //private readonly IDistributedCache cache;

        public ReviewersController(IReviewerService service)//, IDistributedCache cache)
        {
            this.service = service;
            //this.cache = cache;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticatedReviewer>> Authenticate(ReviewerAuthRequest reviewerAuthRequest)
        {
            try
            {
                AuthenticatedReviewer authenticatedReviewer = await service.Authenticate(reviewerAuthRequest);

                if (authenticatedReviewer == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(authenticatedReviewer);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //[AllowAnonymous]
        //[HttpPost("simpleauthenticate")]
        //public ActionResult<AuthenticatedReviewer> Authenticate([Required][FromBody] SimpleLoginRequest simpleLoginRequest)
        //{
        //    try
        //    {
        //        AuthenticatedReviewer authenticatedReviewer = service.Authenticate(simpleLoginRequest.Username, simpleLoginRequest.Paswword);

        //        if (authenticatedReviewer == null)
        //            return BadRequest();

        //        return Ok(authenticatedReviewer);

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [Authorize(Roles = MyConstant.Admin)]
        [HttpGet]
        public async Task<ActionResult<SearchReviewerResult>> SearchReviewer(int page, int pagesize, Guid? campusid, Guid? universityid)
        {
            try
            {
                //string recordKey = nameof(SearchReviewer) + HttpContext.Request.QueryString + DateTime.Now.Hour + (DateTime.Now.Minute / 5);
                //var result = await cache.GetRecordAsync<SearchReviewerResult>(recordKey);
                //if (result == null)
                //{
                //    result = await service.SearchReviewer(page, pagesize, campusid, universityid);

                //    await cache.SetRecordAsync<SearchReviewerResult>(recordKey, result);
                //}
                SearchReviewerResult result = await service.SearchReviewer(page, pagesize, campusid, universityid);
                if (result.Reviewers == null)
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

        //[HttpGet("getmyinformation")]
        //public async Task<ActionResult<Reviewer>> GetMyInformation()
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

        //    // Get the claims values
        //    var FireBaseId = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
        //                       .Select(c => c.Value).SingleOrDefault();

        //    if (FireBaseId == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        Reviewer reviewer = await service.GetByFireBaseIdAsync(FireBaseId);
        //        if (reviewer == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(reviewer);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReviewerDetail>> GetReviewerById(Guid id)
        {
            try
            {
                ReviewerDetail reviewer = await service.GetByIdAsync(id);
                if (reviewer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(reviewer);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<Reviewer>> CreateReviewer([Required] Reviewer reviewer)
        //{
        //    try
        //    {
        //        Reviewer NewReviewer = await service.AddAsync(reviewer);
        //        return CreatedAtAction(nameof(GetReviewerById), new { id = NewReviewer.Id }, NewReviewer);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error create data");
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult<Reviewer>> UpdateReviewer([Required] Reviewer reviewer)
        {
            try
            {
                if (await service.GetByIdAsync(reviewer.Id) == null)
                {
                    return NotFound($"Reviewer with Id = {reviewer.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(reviewer));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reviewer>> DeleteReviewer(Guid id)
        {
            try
            {
                var reviewer = await service.GetByIdAsync(id);
                if (reviewer == null)
                {
                    return NotFound($"Reviewer with Id = {id} not found");
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
    }
}
