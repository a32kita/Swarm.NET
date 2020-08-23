using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwarmDotNET.InternalUtilities
{
    internal static class UriUtils
    {
        public static Uri GetUriWithQueryParameters(Uri baseUri, IDictionary<string, string> queryParameters)
        {
            var querySb = new StringBuilder();
            var initFlag = true;
            if (String.IsNullOrEmpty(baseUri.Query))
                querySb.Append("?");
            else
                initFlag = false;

            foreach (var kvp in queryParameters)
            {
                if (initFlag)
                    initFlag = false;
                else
                    querySb.Append("&");

                querySb.Append(kvp.Key);
                querySb.Append("=");
                querySb.Append(Uri.EscapeDataString(kvp.Value));
            }

            return new Uri(baseUri.ToString() + querySb.ToString());
        }

        public static Uri GetUriWithQueryParameters(string baseUriStr, IDictionary<string, string> queryParameters)
        {
            return GetUriWithQueryParameters(new Uri(baseUriStr), queryParameters);
        }

        public static IDictionary<string, string> GetQueryParametersFromUri(Uri uri)
        {
            var queryString = uri.Query.Substring(1).Split('#')[0];
            var queryStringSplitted = queryString.Split('&');

            var result = new Dictionary<string, string>();
            foreach (var parameter in queryStringSplitted)
            {
                var parameterSplitted = parameter.Split('=');
                if (parameterSplitted.Length == 1)
                    result.Add(parameterSplitted[0], null);
                else
                    result.Add(parameterSplitted[0], parameterSplitted[1]);
            }

            return result;
        }
    }
}
