using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CorrelationId
{
    public class SampleReflectedClass
    {
        public static readonly string PUBLICREADONLYSTRING = "publicreadonlystring";
        public static string PUBLICSTRING = "publicstring";
        private static readonly string PRIVATEREADONLYSTRING = "privatereadonlystring";
        private static string PRIVATESTRING = "privatestring";
        protected static readonly string PROTECTEDREADONLYSTRING = "protectedreadonlystring";
        protected static string PROTECTEDSTRING = "protectedstring";
        internal static readonly string INTERNALREADONLYSTRING = "internalreadonlystring";
        internal static string INTERNALSTRING = "internalstring";

        public EventId PUBLICREADONLYEVENTID = new EventId(1, PUBLICREADONLYSTRING);
        public EventId PUBLICEVENTID = new EventId(2, PUBLICSTRING);
        public EventId PRIVATEREADONLYEVENTID = new EventId(3, PRIVATEREADONLYSTRING);
        public EventId PRIVATEEVENTID = new EventId(4, PRIVATESTRING);
        public EventId PROTECTEDREADONLYEVENTID = new EventId(5, PROTECTEDREADONLYSTRING);
        public EventId PROTECTEDEVENTID = new EventId(6, PROTECTEDSTRING);
        public EventId INTERNALREADONLYEVENTID = new EventId(7, INTERNALREADONLYSTRING);
        public EventId INTERNALEVENTID = new EventId(8, INTERNALSTRING);

        public IDictionary<int, string> dictionary = new Dictionary<int, string>(){ 
            { 1, PUBLICREADONLYSTRING },
            { 2, PUBLICSTRING },
            { 3, PRIVATEREADONLYSTRING },
            { 4, PRIVATESTRING },
            { 5, PROTECTEDREADONLYSTRING },
            { 6, PROTECTEDSTRING },
            { 7, INTERNALREADONLYSTRING },
            { 8, INTERNALSTRING }
        };



    }
}
