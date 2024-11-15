using Domain.Aggreagtes.ClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClassRepository
    {
        Task<Class> AddClassAsync(Class classObject);
        Task<Class?> GetClassByIdAsync(Guid classId);
        Task<Class> UpdateClassAsync(Class classObject);
        Task DeleteClass(Class classObject);
        Task<IEnumerable<Class>> GetAllClassesAsync();
    }
}
