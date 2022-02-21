using FirebaseAdmin.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;
using Whiteboard.Data.Repository;

namespace Whiteboard.Business.Service
{
    public interface IAdminService
    {
        Task<Admin> AddAsync(Admin admin);
        AuthenticatedAdmin Authenticate(string username, string paswword);
        Task<AuthenticatedAdmin> Authenticate(UserRecord userRecord);
        Task<Admin> DeleteAsync(Guid id);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(Guid id);
        Task<Admin> UpdateAsync(Admin admin);
    }

    public class AdminService : IAdminService
    {
        private readonly IAdminRespository respository;

        public AdminService(IAdminRespository respository)
        {
            this.respository = respository;
        }

        public async Task<Admin> AddAsync(Admin admin)
        {
            return await respository.AddtAsync(admin);
        }

        public async Task<Admin> GetByIdAsync(Guid id)
        {
            return await respository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await respository.GetAllAsync();
        }

        public async Task<Admin> UpdateAsync(Admin admin)
        {
            return await respository.UpdateAsync(admin);
        }

        public async Task<Admin> DeleteAsync(Guid id)
        {
            return await respository.DeleteAsync(id);
        }

        public async Task<AuthenticatedAdmin> Authenticate(UserRecord userRecord)
        {
            Admin admin = await respository.GetByFireBaseUIdAsync(userRecord.Uid);

            // return null if user not found
            if (admin == null)
                return null;

            // authentication successful so generate jwt token
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            JwtSecurityTokenHandler tokenHandler = jwtSecurityTokenHandler;
            var key = Encoding.ASCII.GetBytes(MyConstant.Secret);
            var Expires = DateTime.UtcNow.AddDays(MyConstant.DaysExpires);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Id.ToString()),
                    new Claim(ClaimTypes.Role, MyConstant.Admin)
                }),
                Expires = Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedAdmin(admin, tokenHandler.WriteToken(token), Expires);
            //return tokenHandler.WriteToken(token);
        }

        public AuthenticatedAdmin Authenticate(string username, string paswword)
        {
            if ((username != "admin") || (paswword != "admin"))
            {
                return null;
            }
            Admin admin = new()
            {
                Name = "Đỗ Thành Đạt",
                Email = "dat7124@gmail.com"
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var key = Encoding.ASCII.GetBytes(MyConstant.Secret);
            var Expires = DateTime.UtcNow.AddDays(MyConstant.DaysExpires);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, MyConstant.Admin)
                }),
                Expires = Expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedAdmin(admin, tokenHandler.WriteToken(token), Expires);
        }
    }
}
