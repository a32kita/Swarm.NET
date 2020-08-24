using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET.Entities
{
    public class Photo
    {
        [JsonProperty(PropertyName = "prefix")]
        public string Prefix
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "suffix")]
        public string Suffix
        {
            get;
            set;
        }
    }
}
