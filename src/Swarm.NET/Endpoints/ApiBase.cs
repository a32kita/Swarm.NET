using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using SwarmDotNET.Entities;

namespace SwarmDotNET.Endpoints
{
    public abstract class ApiBase
    {
        // 非公開フィールド


        // 限定公開プロパティ

        protected SwarmService ParentService
        {
            get;
            private set;
        }

        protected IDictionary<string, string> StandardParameters
        {
            get;
            private set;
        }


        // コンストラクタ

        public ApiBase(SwarmService parentService)
        {
            this.ParentService = parentService;
            this.ParentService.Authorized += (sender, e) => this.StandardParameters = new Dictionary<string, string>()
            {
                { "oauth_token", this.ParentService.AccessToken.Token },
                { "v", "20230221" },
            };
        }


        // 非公開メソッド

        private async Task<TEntity> _requestAsync<TEntity>(HttpRequestMessage hreq)
        {
            using (var hres = await this.ParentService.GetHttpClient().SendAsync(hreq))
            {
                var hresContent = await hres.Content.ReadAsStringAsync();
                switch (hres.StatusCode)
                {
                    case HttpStatusCode.OK:
                        break;
                    default:
                        throw new SwarmServiceRestException("REST API Error", hreq.RequestUri, hres.StatusCode, hresContent, null);
                }

                try
                {
                    var responseObject = JsonConvert.DeserializeObject<ResponseRoot>(hresContent);
                    var responseEntityJObject = responseObject.Response.First.First;
                    var responseEntity = responseEntityJObject.ToObject<TEntity>();
                    return responseEntity;
                }
                catch (Exception ex)
                {
                    throw new SwarmServiceJsonException(ex, hresContent);
                }
            }
        }


        // 限定公開メソッド

        protected async Task<TEntity> GetAsync<TEntity>(Uri uri)
        {
            using (var hreq = new HttpRequestMessage(HttpMethod.Get, uri))
                return await this._requestAsync<TEntity>(hreq);
        }

        protected async Task<TEntity> PostAsync<TEntity>(Uri uri, string contentType, Stream content)
        {
            using (var streamContent = new StreamContent(content))
            {
                using (var hreq = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = streamContent,
                })
                {
                    hreq.Headers.Add("Content-Type", contentType);
                    return await this._requestAsync<TEntity>(hreq);
                }
            }
        }
    }
}
