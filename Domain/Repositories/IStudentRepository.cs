using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStudentRepository
    {
        bool IsExitByNumber(string studentNumber);
        bool IsExitByEmail(string email);
    }
}
