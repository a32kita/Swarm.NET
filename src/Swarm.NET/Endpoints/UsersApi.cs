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

        public async Task<User> GetAsync(long userId)
        {
            return await this.GetAsync<User>(UriUtils.GetUriWithQueryParameters($"https://api.foursquare.com/v2/users/{userId}", this.StandardParameters));
        }

        public async Task<User> GetSelfAsync()
        {
            return await this.GetAsync<User>(UriUtils.GetUriWithQueryParameters("https://api.foursquare.com/v2/users/self", this.StandardParameters));
        }

        public async Task<CheckinCollection> GetMyCheckinsAsync(int? limit = null, int? offset = null)
        {
            var parameters = new Dictionary<string, string>(this.StandardParameters);
            if (limit.HasValue)
                parameters.Add("limit", limit.ToString());
            if (offset.HasValue)
                parameters.Add("offset", offset.ToString());

            return await this.GetAsync<CheckinCollection>(UriUtils.GetUriWithQueryParameters("https://api.foursquare.com/v2/users/self/checkins", parameters));
        }

        //public async Task<List<Checkin>> GetCheckinsSelfDebug()
        //{
        //    return await this.GetAsync<List<Checkin>>(UriUtils.GetUriWithQueryParameters("https://api.foursquare.com/v2/users/self/checkins", this.StandardParameters));
        //}
    }
}
