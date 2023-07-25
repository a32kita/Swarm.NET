using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities
{
    public class Checkin
    {
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "createdAt")]
        public long CreatedAt
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "shout")]
        public string Shout
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "venue")]
        public Venue Venue
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "isMayor")]
        public bool IsMayor
        {
            get;
            set;
        }
    }
}
