using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CorrelationId.Interfaces
{
    public interface IReflectionService
    {
        IEnumerable<string> ReturnAllStrings(object obj);
        IDictionary<int, string> ReturnOnlyDictionary(object obj);
        IEnumerable<EventId> ReturnOnlyEventIds(object obj);
        IDictionary<int, (string message, LogLevel logLevel)> ReturnOnlyDictionaryLevel(object obj);
    }
}
