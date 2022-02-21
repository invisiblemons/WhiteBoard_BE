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
    public interface ICampusRepository
    {
        Task<Campus> AddtAsync(Campus campus);
        Task<Campus> DeleteAsync(Guid ID);
        Task<IEnumerable<Campus>> GetAllAsync();
        Task<Campus> GetByIdAsync(Guid ID);
        Task<Campus> UpdateAsync(Campus campus);
    }

    public class CampusRepository : ICampusRepository
    {
        private readonly WhiteboardContext context;

        public CampusRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Campus>> GetAllAsync()
        {
            return await context.Campuses.Where(c => c.Status != MyConstant.Deleted).ToListAsync();
        }

        public async Task<Campus> GetByIdAsync(Guid ID)
        {
            return await context.Campuses.AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);
        }

        public async Task<Campus> AddtAsync(Campus campus)
        {
            campus.Id = Guid.NewGuid();
            var result = await context.Campuses.AddAsync(campus);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Campus> UpdateAsync(Campus campus)
        {
            var result = await context.Campuses.FirstOrDefaultAsync(r => r.Id == campus.Id);

            if (result != null)
            {
                result.Name = campus.Name;
                result.PhoneNumber = campus.PhoneNumber;
                result.Email = campus.Email;
                result.Address = campus.Address;
                result.Image = campus.Image;

                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Campus> DeleteAsync(Guid ID)
        {
            var result = await context.Campuses.FirstOrDefaultAsync(c => (c.Id == ID) && (c.Status != MyConstant.Deleted));

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
