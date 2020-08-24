using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SwarmDotNET.Entities;
using SwarmDotNET.InternalUtilities;

namespace SwarmDotNET
{
    public class SwarmService : IDisposable
    {
        // 非公開フィールド
        private SwarmClientInfo _clientInfo;
        private HttpClient _httpClient;


        // 公開プロパティ

        public UserAccessToken AccessToken
        {
            get;
            private set;
        }


        // コンストラクタ

        public SwarmService(SwarmClientInfo clientInfo)
        {
            this._clientInfo = clientInfo;
            this._httpClient = new HttpClient();

            this.AccessToken = null;
        }


        // 公開メソッド

        public Uri GetAuthorizationUri()
        {
            return UriUtils.GetUriWithQueryParameters("https://foursquare.com/oauth2/authenticate", new Dictionary<string, string>()
            {
                { "client_id", this._clientInfo.ClientId },
                { "response_type", "code" },
                { "redirect_uri", this._clientInfo.AuthorizationRedirectUri.ToString() }
            });
        }

        public async Task AuthorizeWithRedirectedUriAsync(Uri redirectedUri)
        {
            var queryParams = UriUtils.GetQueryParametersFromUri(redirectedUri);
            if (queryParams.ContainsKey("code") == false)
                throw new SwarmServiceException($"This uri is not available. {redirectedUri.ToString()}");

            await this.AuthorizeWithCodeAsync(queryParams["code"]);
        }

        public async Task AuthorizeWithCodeAsync(string code)
        {
            var reqUri = UriUtils.GetUriWithQueryParameters("https://foursquare.com/oauth2/access_token", new Dictionary<string, string>()
            {
                { "client_id", this._clientInfo.ClientId },
                { "client_secret", this._clientInfo.ClientSecret },
                { "grant_type", "authorization_code" },
                { "redirect_uri", this._clientInfo.AuthorizationRedirectUri.ToString() },
                { "code", code }
            });

            using (var httpResponse = await this._httpClient.GetAsync(reqUri))
            {
                var responseJson = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new SwarmServiceRestException(
                        "Authorize failured.", reqUri, httpResponse.StatusCode, responseJson, null);

                try
                {
                    this.AccessToken = JsonConvert.DeserializeObject<UserAccessToken>(responseJson);
                }
                catch (Exception ex)
                {
                    throw new SwarmServiceJsonException(ex, responseJson);
                }
            }
        }

        public void AuthorizeWithUserAccessToken(UserAccessToken accessToken)
        {
            this.AccessToken = accessToken;
        }

        public void Dispose()
        {
            this._httpClient.Dispose();
        }
    }
}
