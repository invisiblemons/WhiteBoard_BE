
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
    [Route("api/v1.0/picturesreview")]
    public class PicturesReviewsController : ControllerBase
    {
        private readonly IPictureForReviewService service;

        public PicturesReviewsController(IPictureForReviewService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureForReview>>> GetAllPictureForReview()
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
        public async Task<ActionResult<PictureForReview>> GetPictureForReviewById(Guid id)
        {
            try
            {
                PictureForReview pictureForReview = await service.GetByIdAsync(id);
                if (pictureForReview == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pictureForReview);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Reviewer>> CreatePictureForReview([Required] PictureForReview picturereview)
        {
            try
            {
                PictureForReview picNew = await service.AddAsync(picturereview);
                return CreatedAtAction(nameof(GetPictureForReviewById), new { id = picNew.Id }, picNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<PictureForReview>> UpdatePictureForReview([Required] PictureForReview picturereview)
        {
            try
            {
                if (await service.GetByIdAsync(picturereview.Id) == null)
                {
                    return NotFound($"PictureForReview with Id = {picturereview.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(picturereview));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PictureForReview>> DeletePictureForReview(Guid id)
        {
            try
            {
                var reviewer = await service.GetByIdAsync(id);
                if (reviewer == null)
                {
                    return NotFound($"PictureForReview with Id = {id} not found");
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
