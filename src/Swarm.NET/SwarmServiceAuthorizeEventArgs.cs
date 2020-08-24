using System;
using System.Collections.Generic;
using System.Text;

using SwarmDotNET.Entities;

namespace SwarmDotNET
{
    public class SwarmServiceAuthorizeEventArgs
    {
        public UserAccessToken AccessToken
        {
            get;
            set;
        }
    }
}
