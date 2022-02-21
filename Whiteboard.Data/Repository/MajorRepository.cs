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
    public interface IMajorRepository
    {
        Task<Major> AddtAsync(Major major);
        Task<Major> DeleteAsync(Guid ID);
        Task<IEnumerable<Major>> GetAllAsync();
        Task<Major> GetByIdAsync(Guid ID);
        Task<Major> UpdateAsync(Major major);
    }

    public class MajorRepository : IMajorRepository
    {
        private readonly WhiteboardContext context;

        public MajorRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Major>> GetAllAsync()
        {
            return await context.Majors.ToListAsync();
        }

        public async Task<Major> GetByIdAsync(Guid ID)
        {
            return await context.Majors.AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);
        }

        public async Task<Major> AddtAsync(Major major)
        {
            major.Id = Guid.NewGuid();
            var result = await context.Majors.AddAsync(major);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Major> UpdateAsync(Major major)
        {
            var result = await context.Majors.FirstOrDefaultAsync(r => r.Id == major.Id);

            if (result != null)
            {
                result.Name = major.Name;
                result.Code = major.Code;
                await context.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Major> DeleteAsync(Guid ID)
        {
            var result = await context.Majors.FirstOrDefaultAsync(m => (m.Id == ID) && (m.Status != MyConstant.Deleted));

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
