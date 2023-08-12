using Microsoft.Extensions.Logging;
using Pacagroup.Eccomerce.Transversal.Common;

namespace Pacagroup.Ecommerce_.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            //permite crear sistemas de logging y trazabilidad de las excepciones
            _logger = loggerFactory.CreateLogger<T>();
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}