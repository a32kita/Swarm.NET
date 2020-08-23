using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET
{
    public class SwarmClientInfo
    {
        public string ClientId
        {
            get;
            set;
        }

        public string ClientSecret
        {
            get;
            set;
        }

        public Uri AuthorizationRedirectUri
        {
            get;
            set;
        }
    }
}
