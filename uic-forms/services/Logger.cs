﻿using System.IO;
using System.Reflection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace uic_forms.services
{
    internal class Logger
    {
        private readonly Serilog.Core.Logger _log;

        internal Logger(bool verbose)
        {
            var email = new EmailConnectionInfo
            {
                EmailSubject = "7520 Error",
                FromEmail = "noreply@utah.gov",
                ToEmail = "SGourley@utah.gov",
                MailServer = "send.state.ut.us",
                Port = 25
            };

            var logPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                                       "7520.log-{{Date}}.txt");
            var logLevel = LogEventLevel.Information;
            if (verbose)
            {
                logLevel = LogEventLevel.Verbose;
            }

            _log = new LoggerConfiguration()
                .WriteTo.Email(email, restrictedToMinimumLevel: LogEventLevel.Error)
                .WriteTo.RollingFile(logPath)
                .WriteTo.Console(logLevel)
                .MinimumLevel.Verbose()
                .CreateLogger();
        }

        internal void AlwaysWrite(string format, params object[] args)
        {
            _log.Information(format, args);
        }

        internal void Write(string format, params object[] args)
        {
            _log.Verbose(format, args);
        }
    }
}
