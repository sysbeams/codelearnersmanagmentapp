using Domain.Aggreagtes.CourseAggregate;
using Domain.Repositories.ICourseAggregateRepository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class CourseTypeRepository : ICourseTypeRepository
    {
        private readonly ApplicationContext _context;

        public CourseTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CourseType> AddAsync(CourseType courseType)
        {
            await _context.CourseTypes.AddAsync(courseType);
            await _context.SaveChangesAsync();
            return courseType;
        }

        public async Task<CourseType?> GetByIdAsync(Guid courseTypeId)
        {
            return await _context.CourseTypes.FindAsync(courseTypeId);
        }   

        public async Task<List<CourseType>> GetAllAsync()
        {
            return await _context.CourseTypes.ToListAsync();
        }

        public async Task<CourseType> UpdateAsync(CourseType courseType)
        {
            _context.CourseTypes.Update(courseType);
            await _context.SaveChangesAsync();
            return courseType;
        }

        public async Task DeleteAsync(Guid courseTypeId)
        {
            var courseType = await _context.CourseTypes.FindAsync(courseTypeId);
            if (courseType != null)
            {
                _context.CourseTypes.Remove(courseType);
                await _context.SaveChangesAsync();
            }
        }
    }
}

