using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwarmDotNET.Entities.ResponseElements;

namespace SwarmDotNET.Entities
{
    public class ResponseRoot
    {
        [JsonProperty(PropertyName = "meta")]
        public MetaData Meta
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "response")]
        public JObject Response
        {
            get;
            set;
        }
    }
}
