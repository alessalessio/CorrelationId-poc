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
        public IDictionary<int, (string message, LogLevel logLevel)> logsDictionary =
            new Dictionary<int, (string message, LogLevel logLevel)>()
            {
                {600, ("This is a message with no params!", LogLevel.Information)},
                {601, ("This is a message with one param! {Param1}", LogLevel.Information)},
                {602, ("This is a message with two params! {Param1}, {Param2}", LogLevel.Information) },
                {603, ("This is a debug message with two params! {Param1}, {Param2}", LogLevel.Debug) }
            };

        public ClassUsingStandardLogging(ILogger logger) => _logger = logger;

        public void LogOnceNoParams() => LogByEventId(600);

        public void LogOnceOneParam(string value1) => LogByEventId(601, value1);

        public void LogOnceTwoParams(string value1, int value2) => LogByEventId(602, value1, value2);

        public void LogOnceUsingLoggerMessageWithoutLevelCheck(string value1, int value2) => LogByEventId(603, value1, value2);

        public void LogOnceUsingLoggerMessageWithLevelCheck(string value1, int value2)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
                LogByEventId(603, value1, value2);
        }

        public void LogByEventId(int eventId, params object[] args)
        {
            _logger.Log(logsDictionary[eventId].logLevel, new EventId(eventId), logsDictionary[eventId].message, args);
          
        }
         
    }
}