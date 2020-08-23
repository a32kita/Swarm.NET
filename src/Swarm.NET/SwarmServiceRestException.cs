using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace SwarmDotNET
{
    public class SwarmServiceRestException : SwarmServiceException
    {
        public Uri ApiUri
        {
            get;
            private set;
        }

        public HttpStatusCode StatusCode
        {
            get;
            private set;
        }

        public string ResponseBody
        {
            get;
            set;
        }

        public SwarmServiceRestException(string message, Uri apiUri, HttpStatusCode statusCode, string responseBody, Exception innerException)
            : base($"{message}: RequestUri={apiUri.ToString()}", innerException)
        {
            this.ApiUri = apiUri;
            this.StatusCode = statusCode;
            this.ResponseBody = responseBody;
        }
    }
}
