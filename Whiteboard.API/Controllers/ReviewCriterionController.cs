using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Entities;

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.AdminOrReviewer)]
    [ApiController]
    [Route("api/v1.0/reviewcriterion")]
    public class ReviewCriterionController : ControllerBase
    {
        private readonly IReviewCriterionService service;

        public ReviewCriterionController(IReviewCriterionService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewCriterion>>> GetAllReviewCriterion()
        {
            try
            {
                return Ok(await service.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReviewCriterion>> GetReviewCriterionById(Guid id)
        {
            try
            {
                ReviewCriterion reviewCriterion = await service.GetByIdAsync(id);
                if (reviewCriterion == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(reviewCriterion);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Reviewer>> CreateReviewCriterion([Required] ReviewCriterion reviewcriterion)
        {
            try
            {
                ReviewCriterion reviewCriterionNew = await service.AddAsync(reviewcriterion);
                return CreatedAtAction(nameof(GetReviewCriterionById), new { id = reviewCriterionNew.Id }, reviewCriterionNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ReviewCriterion>> UpdateReviewCriterion([Required] ReviewCriterion reviewcriterion)
        {
            try
            {
                if (await service.GetByIdAsync(reviewcriterion.Id) == null)
                {
                    return NotFound($"ReviewCriterion with Id = {reviewcriterion.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(reviewcriterion));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewCriterion>> DeleteReviewCriterion(Guid id)
        {
            try
            {
                var reviewer = await service.GetByIdAsync(id);
                if (reviewer == null)
                {
                    return NotFound($"ReviewCriterion with Id = {id} not found");
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
