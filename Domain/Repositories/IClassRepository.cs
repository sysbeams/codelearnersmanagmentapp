using Domain.Aggreagtes.ClassAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClassRepository
    {
        //Class related
        Task<Class> AddClassAsync(Class classObject);
        Task<Class?> GetClassByIdAsync(Guid classId);
        Task<bool> ExistAsync(int staffId,DateTime scheduledDatetime);
        Task<Class> UpdateClassAsync(Class classObject);
        Task<IEnumerable<Class>> GetClasses();
        Task DeleteClass(Class classObject);


    }
}