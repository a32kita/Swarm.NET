using System;
using System.Text;

using SwarmDotNET.Entities;

namespace SwarmDotNET.Extensions
{
    public static class CheckinExtension
    {
        public static DateTime GetCheckinUTCDateTime(this Checkin checkin)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTime = epoch.AddSeconds(checkin.CreatedAt);
            return dateTime;
        }
    }
}
