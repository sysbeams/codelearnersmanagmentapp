using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mail.Logging
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string? message, params object?[] args);
        void LogError(Exception? exception, string? message, params object?[] args);
    }
}
