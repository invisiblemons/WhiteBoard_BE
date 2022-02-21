using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;

namespace Whiteboard.Data.Repository
{
    public interface IAdminRespository
    {
        Task<Admin> AddtAsync(Admin admin);
        Task<Admin> DeleteAsync(Guid ID);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByFireBaseUIdAsync(string FireBaseUId);
        Task<Admin> GetByIdAsync(Guid ID);
        Task<Admin> UpdateAsync(Admin admin);
    }

    public class AdminRespository : IAdminRespository
    {
        private readonly WhiteboardContext context;

        public AdminRespository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await context.Admins.ToListAsync();
        }

        public async Task<Admin> GetByIdAsync(Guid ID)
        {
            return await context.Admins.AsNoTracking().FirstOrDefaultAsync(a => a.Id == ID);
        }

        public async Task<Admin> GetByFireBaseUIdAsync(String FireBaseUId)
        {
            return await context.Admins.FirstOrDefaultAsync(a => (a.FireBaseUId == FireBaseUId && a.Status != MyConstant.Deleted));
        }

        public async Task<Admin> AddtAsync(Admin admin)
        {
            admin.Id = Guid.NewGuid();
            var result = await context.Admins.AddAsync(admin);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Admin> UpdateAsync(Admin admin)
        {
            var result = await context.Admins.FirstOrDefaultAsync(a => a.Id == admin.Id);

            if (result != null)
            {
                result.Name = admin.Name;
                result.Avatar = admin.Avatar;
                result.Birthday = admin.Birthday;
                result.PhoneNumber = admin.PhoneNumber;
                result.Email = admin.Email;
                result.FireBaseUId = admin.FireBaseUId;

                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Admin> DeleteAsync(Guid ID)
        {
            var result = await context.Admins.FirstOrDefaultAsync(a => (a.Id == ID) && (a.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Status = MyConstant.Deleted;

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }

    }
}
