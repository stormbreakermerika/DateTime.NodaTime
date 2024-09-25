using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTime.NodaTime
{
    public static class DateTimeUtcConversionExtensions
    {
        public static System.DateTime LocalToUtc(this System.DateTime dateTime, string ianaTimeZone)
        {
            ZonedDateTime localDateTime = LocalDateTime.FromDateTime(dateTime).InZoneLeniently(DateTimeZoneProviders.Tzdb[ianaTimeZone]);
            Instant instant = localDateTime.ToInstant();
            return instant.ToDateTimeUtc();
        }

        public static System.DateTime UtcToLocal(this System.DateTime dateTime, string ianaTimeZone)
        {
            Instant utcInstant = Instant.FromDateTimeUtc(dateTime);
            ZonedDateTime localDateTime = utcInstant.InZone(DateTimeZoneProviders.Tzdb[ianaTimeZone]);
            return localDateTime.ToDateTimeUnspecified();
        }
    }
}
