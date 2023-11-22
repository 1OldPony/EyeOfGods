using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EyeOfGods.Logger
{
    public static class EyeOfGodsLoggerExtensions
    {
        public static ILoggingBuilder AddEyeOfGodsFileLogger(this ILoggingBuilder builder, Action<EyeOfGodsFileLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, EyeOfGodsFileLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
