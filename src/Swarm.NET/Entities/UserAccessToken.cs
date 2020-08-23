using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SwarmDotNET.Entities
{
    public class UserAccessToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token
        {
            get;
            set;
        }
    }
}
