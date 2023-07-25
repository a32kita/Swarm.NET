using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities
{
    public class Venue
    {
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "location")]
        public VenueLocation Location
        {
            get;
            set;
        }
    }
}
