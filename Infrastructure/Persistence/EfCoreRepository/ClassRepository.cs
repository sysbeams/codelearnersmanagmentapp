using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EfCoreRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationContext _context;

        public ClassRepository(ApplicationContext context) 
        { 
            _context = context;
        }
        public async Task<Class> AddClassAsync(Class classObject)
        {
           await _context.Classes.AddAsync(classObject);
            await _context.SaveChangesAsync();
            return classObject;
        }

        public async Task DeleteClass(Class classObject)
        {
             _context.Classes.Remove(classObject);
            await _context.SaveChangesAsync();
        }


        public async Task<Class?> GetClassByIdAsync(Guid classId)
        {
           return await _context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
        }

        public  async Task<IEnumerable<Class>> GetClasses()
        {
            return await _context.Classes.ToListAsync();  
        }

        public async Task<Class> UpdateClassAsync(Class classObject)
        {
            _context.Classes.Update(classObject);
            await _context.SaveChangesAsync();
            return classObject;
        }
    }
}
