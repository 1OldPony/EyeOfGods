using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace EyeOfGods.Logger
{
    [ProviderAlias("LogToFile")]
    public class EyeOfGodsFileLoggerProvider : ILoggerProvider
    {
        public readonly EyeOfGodsFileLoggerOptions _options;
        private readonly IWebHostEnvironment _env;

        public EyeOfGodsFileLoggerProvider(IOptions<EyeOfGodsFileLoggerOptions> Options, IWebHostEnvironment env)
        {
            _options = Options.Value;
            _env = env;

            if (!Directory.Exists(_options.FolderPath))
            {
                Directory.CreateDirectory(_options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EyeOfGodsFileLogger(this, _env);
        }

        public void Dispose()
        {
        }
    }
}
