using Api.CorrelationId.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api.CorrelationId.Service
{
    public class ReflectionService : IReflectionService
    {
        public IEnumerable<string> PrintProperties(object obj)
        {
            var allStrings = new List<string>();

            if (obj == null) return allStrings;
            
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields();
            foreach (FieldInfo field in fields)
            {
                object propValue = field.GetValue(obj);
                if (propValue is IDictionary<int, string>)
                {
                    allStrings.Add("{" + string.Join(",", ((IDictionary<int,string>)propValue).Select(kv => kv.Key + ":" + kv.Value).ToArray()) + "}");
                }
                else
                {
                    allStrings.Add(field.Name + ": " + propValue);
                }
            }

            return allStrings;
        }

        public IEnumerable<string> ReturnAllStrings(object obj)
        {
            return PrintProperties(obj);
        }

        public IDictionary<int, string> ReturnOnlyDictionary(object obj)
        {
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields();
            foreach (FieldInfo field in fields)
            {
                object propValue = field.GetValue(obj);
                if (propValue is IDictionary<int, string>)
                {
                    return (IDictionary<int, string>)propValue;
                }
            }

            return new Dictionary<int, string>();
        }

        public IDictionary<int, (string message, LogLevel logLevel)> ReturnOnlyDictionaryLevel(object obj)
        {
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields();
            foreach (FieldInfo field in fields)
            {
                object propValue = field.GetValue(obj);
                if (propValue is IDictionary<int, (string message, LogLevel logLevel)>)
                {
                    return (IDictionary<int, (string message, LogLevel logLevel)>)propValue;
                }
            }

            return new Dictionary<int, (string message, LogLevel logLevel)>();
        }

        public IEnumerable<EventId> ReturnOnlyEventIds(object obj)
        {
            var eventIds = new List<EventId>();
            Type objType = obj.GetType();
            FieldInfo[] fields = objType.GetFields();
            foreach (FieldInfo field in fields)
            {
                object propValue = field.GetValue(obj);
                if (propValue is EventId)
                {
                    eventIds.Add((EventId)propValue);
                }
            }

            return eventIds;
        }
    }
}
