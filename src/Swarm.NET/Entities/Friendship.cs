using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SwarmDotNET.Entities
{
    public class Friendship
    {
        [JsonProperty(PropertyName = "count")]
        public int Count
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "groups")]
        public FriendGroup[] Groups
        {
            get;
            set;
        }
    }
}
