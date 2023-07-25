using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SwarmDotNET.Endpoints;
using SwarmDotNET.Entities;
using SwarmDotNET.InternalUtilities;

namespace SwarmDotNET
{
    public class SwarmService : IDisposable
    {
        // 非公開フィールド
        private SwarmClientInfo _clientInfo;
        private HttpClient _httpClient;
        private UserAccessToken _accessToken;
        private EventHandler<SwarmServiceAuthorizeEventArgs> _authorized;


        // 公開プロパティ

        public UserAccessToken AccessToken
        {
            get => this._accessToken;
            set
            {
                this._accessToken = value;
                this._authorized?.Invoke(this, new SwarmServiceAuthorizeEventArgs() { AccessToken = value });
            }
        }

        public VenuesApi Venues
        {
            get;
            private set;
        }

        public UsersApi Users
        {
            get;
            private set;
        }

        
        // 公開イベント

        public event EventHandler<SwarmServiceAuthorizeEventArgs> Authorized
        {
            add => this._authorized += value;
            remove => this._authorized -= value;
        }


        // コンストラクタ

        public SwarmService(SwarmClientInfo clientInfo)
        {
            this._clientInfo = clientInfo;
            this._httpClient = new HttpClient();

            this.AccessToken = null;

            this.Venues = new VenuesApi(this);
            this.Users = new UsersApi(this);
        }


        // 限定公開メソッド

        internal HttpClient GetHttpClient()
        {
            return this._httpClient;
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
