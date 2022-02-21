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
    [Authorize(Roles = MyConstant.Admin)]
    [ApiController]
    [Route("api/v1.0/criterions")]
    public class CriterionsController : ControllerBase
    {
        private readonly ICriterionService service;

        public CriterionsController(ICriterionService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Criterion>>> GetAllCriterion()
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
        public async Task<ActionResult<Criterion>> GetCriterionById(Guid id)
        {
            try
            {
                Criterion criterion = await service.GetByIdAsync(id);
                if (criterion == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(criterion);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Criterion>> CreateCriterion([Required] Criterion criterion)
        {
            try
            {
                Criterion criterionNew = await service.AddAsync(criterion);
                return CreatedAtAction(nameof(GetCriterionById), new { id = criterionNew.Id }, criterionNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Criterion>> UpdateCriterion([Required] Criterion criterion)
        {
            try
            {
                if (await service.GetByIdAsync(criterion.Id) == null)
                {
                    return NotFound($"Criterion with Id = {criterion.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(criterion));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Criterion>> DeleteCriterion(Guid id)
        {
            try
            {
                var criterion = await service.GetByIdAsync(id);
                if (criterion == null)
                {
                    return NotFound($"Criterion with Id = {id} not found");
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
