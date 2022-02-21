using FirebaseAdmin.Auth;
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
using Whiteboard.Data.Model;

namespace Whiteboard.API.Controllers
{
    [Authorize(Roles = MyConstant.Admin)]
    [ApiController]
    [Route("api/v1.0/admins")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService service;

        public AdminsController(IAdminService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticatedAdmin>> Authenticate(AdminAuthRequest adminAuthRequest)
        {
            try
            {
                FirebaseAuth Auth = FirebaseAuth.DefaultInstance;
                FirebaseToken decodedToken = await Auth.VerifyIdTokenAsync(adminAuthRequest.IdToken);
                UserRecord userRecord = await Auth.GetUserAsync(decodedToken.Uid);
            if (userRecord == null)
                {
                    return BadRequest();
                }
                else
                {
                    AuthenticatedAdmin authenticatedAdmin = await service.Authenticate(userRecord);

                    if (authenticatedAdmin == null)
                        return BadRequest();

                    return Ok(authenticatedAdmin);
                }
            }
            catch
            {
                return BadRequest();
            }
        }


        //public class SimpleLoginRequest
        //{
        //    public string Username { get; set; }
        //    public string Paswword { get; set; }
        //}
        //[AllowAnonymous]
        //[HttpPost("simpleauthenticate")]
        //public ActionResult<AuthenticatedAdmin> Authenticate([Required][FromBody] SimpleLoginRequest simpleLoginRequest)
        //{
        //    try
        //    {
        //        AuthenticatedAdmin authenticatedAdmin = service.Authenticate(simpleLoginRequest.Username, simpleLoginRequest.Paswword);

        //        if (authenticatedAdmin == null)
        //            return BadRequest();

        //        return Ok(authenticatedAdmin);

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmin()
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

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Admin>> GetAdminById(Guid id)
        {
            try
            {
                Admin admin = await service.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(admin);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin([Required] Admin admin)
        {
            try
            {
                Admin adminNew = await service.AddAsync(admin);
                return CreatedAtAction(nameof(GetAdminById), new { id = adminNew.Id }, adminNew);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error create data");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Admin>> UpdateAdmin([Required] Admin admin)
        {
            try
            {
                if (await service.GetByIdAsync(admin.Id) == null)
                {
                    return NotFound($"Admin with Id = {admin.Id} not found");
                }
                else
                {
                    return Ok(await service.UpdateAsync(admin));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error update data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(Guid id)
        {
            try
            {
                var admin = await service.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound($"Admin with Id = {id} not found");
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
 