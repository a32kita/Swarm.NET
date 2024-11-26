using SwarmDotNET.Entities;
using SwarmDotNET.InternalUtilities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwarmDotNET.Endpoints
{
    public class CheckinsApi : ApiBase
    {
        public CheckinsApi(SwarmService parentService)
            : base(parentService)
        {

        }

        public async Task<Checkin> GetCheckinDetailsAsync(string checkinId)
        {
            return await this.GetAsync<Checkin>(UriUtils.GetUriWithQueryParameters($"https://api.foursquare.com/v2/checkins/{checkinId}", this.StandardParameters));
        }
    }
}
