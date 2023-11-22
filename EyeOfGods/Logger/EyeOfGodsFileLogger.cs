using Castle.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace EyeOfGods.Logger
{
    public class EyeOfGodsFileLogger: Microsoft.Extensions.Logging.ILogger
    {
        protected readonly EyeOfGodsFileLoggerProvider _provider;
        protected readonly IWebHostEnvironment _env;

        public EyeOfGodsFileLogger(EyeOfGodsFileLoggerProvider provider, IWebHostEnvironment env)
        {
            _provider = provider;
            _env = env;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var record = string.Format("{0} [{1}] {2} {3}", DateTime.UtcNow.ToString("G"), logLevel.ToString(),
                formatter(state, exception), exception != null ? $"\nMessage: {exception.Message}" + "\n" + $"{exception.StackTrace}".Trim() : "");

            if (logLevel == LogLevel.Critical)
            {
                _provider._options.FolderPath = _env.WebRootPath + "\\Logs\\";
                _provider._options.FileName = DateTime.UtcNow.ToString("d") + ".log";

                var path = string.Concat(_provider._options.FolderPath,
                    _provider._options.FileName);


                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(record);
                writer.Close();
            }
        }
    }
    
}
