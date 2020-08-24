using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SwarmDotNET.Entities
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "photo")]
        public Photo Photo
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "friends")]
        public Friendship Friends
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "birthday")]
        public long Birthday
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "homeCity")]
        public string HomeCity
        {
            get;
            set;
        }
    }
}
