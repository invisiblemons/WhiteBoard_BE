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
    [Route("api/v1.0/majors")]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorService service;

        public MajorsController(IMajorService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Major>>> GetAllMajor()
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
        public async Task<ActionResult<Major>> GetMajorById(Guid id)
        {
            try
            {
                Major major = await service.GetByIdAsync(id);
                if (major == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(major);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Major>> CreateMajor([Required] Major major)
        {
            try
            {
                Major majorNew = await service.AddAsync(major);
                return CreatedAtAction(nameof(GetMajorById), new { id = majorNew.Id }, majorNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Major>> UpdateMajor([Required] Major major)
        {
            try
            {
                if (await service.GetByIdAsync(major.Id) == null)
                {
                    return NotFound($"Major with Id = {major.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(major));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Major>> DeleteMajor(Guid id)
        {
            try
            {
                var major = await service.GetByIdAsync(id);
                if (major == null)
                {
                    return NotFound($"Major with Id = {id} not found");
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
