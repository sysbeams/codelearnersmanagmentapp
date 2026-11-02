using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mail.Logging
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }
        public void LogError(Exception? exception, string? message, params object?[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogInformation(string? message, params object?[] args)
        {
            _logger.LogInformation(message, args);
        }
    }
}
