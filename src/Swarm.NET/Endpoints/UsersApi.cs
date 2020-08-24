using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using SwarmDotNET.Entities;
using SwarmDotNET.InternalUtilities;

namespace SwarmDotNET.Endpoints
{
    public class UsersApi : ApiBase
    {
        // コンストラクタ

        public UsersApi(SwarmService parentService)
            : base(parentService)
        {

        }


        // 公開メソッド

        public async Task<User> Get(long userId)
        {
            return await this.GetAsync<User>(UriUtils.GetUriWithQueryParameters($"https://api.foursquare.com/v2/users/{userId}", this.StandardParameters));
        }

        public async Task<User> GetSelf()
        {
            return await this.GetAsync<User>(UriUtils.GetUriWithQueryParameters("https://api.foursquare.com/v2/users/self", this.StandardParameters));
        }
    }
}
