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
    [Route("api/v1.0/campuses")]
    public class CampusesController : ControllerBase
    {
        private readonly ICampusService service;

        public CampusesController(ICampusService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campus>>> GetAllCampus()
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
        public async Task<ActionResult<Campus>> GetCampusById(Guid id)
        {
            try
            {
                Campus campus = await service.GetByIdAsync(id);
                if (campus == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(campus);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Campus>> CreateCampus([Required] Campus campus)
        {
            try
            {
                Campus campusNew = await service.AddAsync(campus);
                return CreatedAtAction(nameof(GetCampusById), new { id = campusNew.Id }, campusNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Campus>> UpdateCampus([Required] Campus campus)
        {
            try
            {
                if (await service.GetByIdAsync(campus.Id) == null)
                {
                    return NotFound($"Campus with Id = {campus.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(campus));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Campus>> DeleteCampus(Guid id)
        {
            try
            {
                var reviewer = await service.GetByIdAsync(id);
                if (reviewer == null)
                {
                    return NotFound($"Campus with Id = {id} not found");
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
