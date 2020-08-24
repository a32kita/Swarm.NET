using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET.Endpoints
{
    public abstract class ApiBase
    {
        // 限定公開プロパティ

        protected SwarmService ParentService
        {
            get;
            private set;
        }


        // コンストラクタ

        public ApiBase(SwarmService parentService)
        {
            this.ParentService = parentService;
        }
    }
}
