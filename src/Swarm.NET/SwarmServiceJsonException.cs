using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET
{
    public class SwarmServiceJsonException : SwarmServiceException
    {
        // 公開プロパティ

        public string Json
        {
            get;
            private set;
        }


        // コンストラクタ

        public SwarmServiceJsonException(Exception innerException, string json)
            : base("Failure to load json object.", innerException)
        {
            this.Json = json;
        }
    }
}
