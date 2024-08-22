using System;
using System.Collections.Generic;
using System.Text;

namespace SwarmDotNET
{
    public class SwarmAcceptLanguage
    {
        public string AcceptLanguage
        {
            get;
        }

        public SwarmAcceptLanguage(string acceptLanguage)
        {
            this.AcceptLanguage = acceptLanguage;
        }

        public static readonly SwarmAcceptLanguage Default
            = new SwarmAcceptLanguage(String.Empty);

        public static readonly SwarmAcceptLanguage PrioritizeJapanese
            = new SwarmAcceptLanguage("ja-JP,ja;q=0.9,en-US;q=0.8,en;q=0.7");
    }
}
