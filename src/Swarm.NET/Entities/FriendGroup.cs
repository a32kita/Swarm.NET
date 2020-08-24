using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET.Entities
{
    public class FriendGroup
    {
        [JsonProperty(PropertyName = "type")]
        public string Type
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

        [JsonProperty(PropertyName = "count")]
        public int Count
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "items")]
        public User[] Items
        {
            get;
            set;
        }
    }
}
