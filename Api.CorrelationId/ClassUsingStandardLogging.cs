using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Api.CorrelationId
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassUsingStandardLogging
    {
        private readonly ILogger _logger;

        // We use a dictionary in order to then use reflection and returns this object to the endpoint
        public IDictionary<int, string> logsDictionary =
            new Dictionary<int, string>()
            {
                {600, "This is a message with no params!"},
                {601, "This is a message with one param! {Param1}"},
                {602, "This is a message with two params! {Param1}, {Param2}" },
                {603, "This is a debug message with two params! {Param1}, {Param2}" }
            };

        public ClassUsingStandardLogging(ILogger logger) => _logger = logger;

        public void LogOnceNoParams() => _logger.LogInformation(new EventId(600), logsDictionary[600]);

        public void LogOnceOneParam(string value1) => _logger.LogInformation(new EventId(601), logsDictionary[601], value1);

        public void LogOnceTwoParams(string value1, int value2) => _logger.LogInformation(new EventId(602), logsDictionary[602], value1, value2);

        public void LogOnceUsingLoggerMessageWithoutLevelCheck(string value1, int value2) => _logger.LogDebug(new EventId(603), logsDictionary[603], value1, value2);

        public void LogOnceUsingLoggerMessageWithLevelCheck(string value1, int value2)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                _logger.LogDebug(new EventId(603), logsDictionary[603], value1, value2);
        }

         
    }
}