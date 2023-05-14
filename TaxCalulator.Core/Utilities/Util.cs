using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalulator.Core.Utilities
{
    public static class Util
    {
        public static T Deserialize<T>(string entity)
        {
            if (entity == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new NullReferenceException("Cannot serialize a null object");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            var jss = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateParseHandling = DateParseHandling.DateTimeOffset
            };

            return JsonConvert.DeserializeObject<T>(entity, jss);
        }
    }
}
