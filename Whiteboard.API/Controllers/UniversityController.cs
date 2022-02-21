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

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.Admin)]
    [ApiController]
    [Route("api/v1.0/universities")]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService service;
        private readonly IDistributedCache cache;

        public UniversitiesController(IUniversityService service, IDistributedCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<University>>> GetAllUniversity()
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
        public async Task<ActionResult<SearchUniversityResult>> SearchUniversity(int page, int pagesize, bool reloadredis = false)
        {
            try
            {
                SearchUniversityResult result = null;
                string recordKey = nameof(SearchUniversity) + HttpContext.Request.QueryString + DateTime.Now.Day;
                recordKey = recordKey.Replace("?reloadredis=false", "").Replace("&reloadredis=false", "");
                if (reloadredis)
                {
                    recordKey = recordKey.Replace("?reloadredis=true", "").Replace("&reloadredis=true", "");
                }
                else
                {
                    result = await cache.GetRecordAsync<SearchUniversityResult>(recordKey);
                }
                if (result == null)
                {
                    result = await service.SearchUniversity(page, pagesize);

                    await cache.SetRecordAsync<SearchUniversityResult>(recordKey, result);
                }
                //SearchUniversityResult result = await service.SearchUniversity(page, pagesize);
                if (result.Universitys == null)
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
        public async Task<ActionResult<UniversityDetail>> GetUniversityById(Guid id)
        {
            try
            {
                UniversityDetail university = await service.GetByIdAsync(id);
                if (university == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(university);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UniversityDetail>> CreateUniversity([Required] PostUniversity university)
        {
            try
            {
                UniversityDetail universityNew = await service.AddAsync(university);
                return CreatedAtAction(nameof(GetUniversityById), new { id = universityNew.Id }, universityNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UniversityDetail>> UpdateUniversity([Required] PutUniversity university)
        {
            try
            {
                if (await service.GetByIdAsync(university.Id) == null)
                {
                    return NotFound($"University with Id = {university.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(university));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<University>> DeleteUniversity(Guid id)
        {
            try
            {
                var university = await service.GetByIdAsync(id);
                if (university == null)
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
