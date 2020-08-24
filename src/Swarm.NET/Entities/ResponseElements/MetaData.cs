using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities.ResponseElements
{
    public class MetaData
    {
        [JsonProperty(PropertyName = "code")]
        public int Code
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }
}
