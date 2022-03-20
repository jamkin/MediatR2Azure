namespace MediatR.InfrastructureBuilder.Logging
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class LoggerNone : ILogger
    {
        internal static ILogger Instance => _instance.Value;

        private static readonly Lazy<ILogger> _instance = new Lazy<ILogger>(() => new LoggerNone());

        private LoggerNone() { }

        public IDisposable BeginScope<TState>(TState state)
        {
            return DisposableNone.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
        }
    }

    public class DisposableNone : IDisposable
    {
        public static IDisposable Instance => _instance.Value;

        private static readonly Lazy<IDisposable> _instance = new Lazy<IDisposable>(() => new DisposableNone());

        private DisposableNone() { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
