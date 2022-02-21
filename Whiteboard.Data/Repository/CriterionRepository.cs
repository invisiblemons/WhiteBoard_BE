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
    public interface ICriterionRepository
    {
        Task<Criterion> AddtAsync(Criterion criterion);
        Task<Criterion> DeleteAsync(Guid ID);
        Task<IEnumerable<Criterion>> GetAllAsync();
        Task<Criterion> GetByIdAsync(Guid ID);
        Task<Criterion> UpdateAsync(Criterion criterion);
    }

    public class CriterionRepository : ICriterionRepository
    {
        private readonly WhiteboardContext context;

        public CriterionRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Criterion>> GetAllAsync()
        {
            return await context.Criterions.ToListAsync();
        }

        public async Task<Criterion> GetByIdAsync(Guid ID)
        {
            return await context.Criterions.AsNoTracking().FirstOrDefaultAsync(r => r.Id == ID);
        }

        public async Task<Criterion> AddtAsync(Criterion criterion)
        {
            criterion.Id = Guid.NewGuid();
            var result = await context.Criterions.AddAsync(criterion);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Criterion> UpdateAsync(Criterion criterion)
        {
            var result = await context.Criterions.FirstOrDefaultAsync(r => r.Id == criterion.Id);

            if (result != null)
            {
                result.Name = criterion.Name;
                await context.SaveChangesAsync();

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Criterion> DeleteAsync(Guid ID)
        {
            var result = await context.Criterions.FirstOrDefaultAsync(r => r.Id == ID);

            if (result != null)
            {
                context.Criterions.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
