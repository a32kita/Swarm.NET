using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwarmDotNET.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var datFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Swarm.NET.dat");
            var tokenFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Swarm.NET_token.dat");

            if (File.Exists(datFilePath) == false)
            {
                Console.WriteLine("Please put client info file.");
                Console.WriteLine(datFilePath);
                Environment.Exit(1);
            }

            var clientInfo = new SwarmClientInfo();
            using (var sr = new StreamReader(File.OpenRead(datFilePath)))
            {
                clientInfo.ClientId = sr.ReadLine();
                clientInfo.ClientSecret = sr.ReadLine();
                clientInfo.AuthorizationRedirectUri = new Uri(sr.ReadLine());
            }

            using (var swService = new SwarmService(clientInfo))
            {
                if (File.Exists(tokenFilePath))
                {
                    Console.WriteLine("Loading token file ...");

                    using (var sr = new StreamReader(File.OpenRead(tokenFilePath)))
                    {
                        swService.AuthorizeWithUserAccessToken(new Entities.UserAccessToken() { Token = sr.ReadLine() });
                    }
                }
                else
                {
                    Console.WriteLine("Please authorize this client;");
                    Console.WriteLine(swService.GetAuthorizationUri());
                    Console.WriteLine();
                    Console.WriteLine("Please input redirected uri;");

                    Console.Write("> ");
                    var redirectedUri = Console.ReadLine();

                    swService.AuthorizeWithRedirectedUriAsync(new Uri(redirectedUri)).Wait();
                }

                Console.WriteLine("Authentication flow is completed.");
                Console.WriteLine(swService.AccessToken.Token);
                Console.WriteLine();

                var me = swService.Users.GetSelf().Result;
                Console.WriteLine("[me]");
                Console.WriteLine("* Name: {0} {1}", me.FirstName, me.LastName);

                Console.ReadLine();
            }
        }
    }
}
