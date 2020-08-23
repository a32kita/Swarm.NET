using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwarmDotNET.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var swService = new SwarmService(new SwarmClientInfo()
            {
                ClientId = "KWCZOZ5S5WGXNE054WLHNWZ0BJNRMHRS5FOCZASF15JRPQUP",
                ClientSecret = "1I1CGA0UTKS2T0WFWPZR5YNN0QHFY3M2XSKFWS5RA34XNCXN",
                AuthorizationRedirectUri = new Uri("http://www.a32kita.net/dummy/fsqauth"),
            }))
            {
                Console.WriteLine("Please authorize this client;");
                Console.WriteLine(swService.GetAuthorizationUri());
                Console.WriteLine();
                Console.WriteLine("Please input redirected uri;");
                
                Console.Write("> ");
                var redirectedUri = Console.ReadLine();

                swService.AuthorizeWithRedirectedUriAsync(new Uri(redirectedUri)).Wait();

                Console.WriteLine("Authentication flow is completed.");
                Console.WriteLine(swService.AccessToken.Token);

                Console.ReadLine();
            }
        }
    }
}
