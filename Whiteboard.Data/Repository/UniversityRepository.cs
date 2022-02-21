using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiteboard.Data.Context;
using Whiteboard.Data.Entities;
using Whiteboard.Data.Model;

namespace Whiteboard.Data.Repository
{
    public interface IUniversityRepository
    {
        Task<UniversityDetail> AddtAsync(PostUniversity university);
        Task<UniversityDetail> DeleteAsync(Guid ID);
        Task<UniversityDetail> GetByIdAsync(Guid ID);
        Task<SearchUniversityResult> SearchUniversity(int page, int pageSize);
        Task<UniversityDetail> UpdateAsync(PutUniversity university);
    }

    public class UniversityRepository : IUniversityRepository
    {
        private readonly WhiteboardContext context;

        public UniversityRepository(WhiteboardContext context)
        {
            this.context = context;
        }

        //public async Task<IEnumerable<University>> GetAllAsync()
        //{
        //    return await context.Universities.ToListAsync();
        //}

        public async Task<UniversityDetail> GetByIdAsync(Guid ID)
        {
            return new UniversityDetail(await context.Universities.Include(u => u.Campuses).ThenInclude(ca => ca.Majors).AsNoTracking().FirstOrDefaultAsync(u => u.Id == ID));
        }

        public async Task<UniversityDetail> AddtAsync(PostUniversity university)
        {
            var result = await context.Universities.AddAsync(new University
            {
                Id = Guid.NewGuid(),
                Name = university.Name,
                PhoneNumber = university.PhoneNumber,
                Email = university.Email,
                Image = university.Image,
                Link = university.Link
            });
            await context.SaveChangesAsync();
            return await GetByIdAsync(result.Entity.Id);
        }

        public async Task<UniversityDetail> UpdateAsync(PutUniversity university)
        {
            var result = await context.Universities.FirstOrDefaultAsync(u => (u.Id == university.Id) && (u.Status != MyConstant.Deleted));

            if (result != null)
            {
                result.Name = university.Name;
                result.Email = university.Email;
                result.PhoneNumber = university.PhoneNumber;
                result.Image = university.Image;
                result.Link = university.Link;

                await context.SaveChangesAsync();

                return await GetByIdAsync(result.Id);
            }
            else
            {
                return null;
            }
        }

        //public async Task<UniversityDetail> DeleteAsync(Guid ID)
        //{
        //    var result = await context.Universities.Include(u => u.Campuses).ThenInclude(ca => ca.Majors).FirstOrDefaultAsync(r => r.Id == ID);

        //    if (result != null)
        //    {
        //        context.Universities.Remove(result);
        //        await context.SaveChangesAsync();
        //        return new UniversityDetail(result);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<UniversityDetail> DeleteAsync(Guid ID)
        {
            var result = await context.Universities.FirstOrDefaultAsync(u => (u.Id == ID) && (u.Status != MyConstant.Deleted));

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

        public async Task<SearchUniversityResult> SearchUniversity(int page, int pageSize)
        {
            var universities = from u in context.Universities
                               select u;
            universities = universities.Include(u => u.Campuses).ThenInclude(ca => ca.Majors).Where(u => u.Status != MyConstant.Deleted);
            universities = universities.AsNoTracking();
            int totalRow = await universities.CountAsync();
            int totalPage = (int)Math.Ceiling(totalRow / (double)pageSize);
            page = page > totalPage ? totalPage : page;
            int skipRow = (page - 1) * pageSize;
            int takeRow = (totalRow - skipRow) > pageSize ? pageSize : (totalRow - skipRow);
            return new SearchUniversityResult
            {
                Page = page,
                PageSize = pageSize,
                TotalPage = totalPage,
                TotalRow = totalRow,
                Universitys = totalRow == 0 ? null : (await universities.Skip(skipRow).Take(takeRow).ToListAsync()).Select(university => new UniversityDetail(university))
            };
        }
    }
}
