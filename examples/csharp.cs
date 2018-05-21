using System;
using System.IO;
using System.Net;

namespace ProxyRackHttpExample
{
    class Program
    {
        private const string Username = "YOURUSERNAME";
        private const string Password = "YOURPASSWORD";

        private const string PROXY_RACK_DNS = "http://megaproxy.rotating.proxyrack.net:222";

        private const string UrlToGet = "http://ip-api.com/json";

        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(UrlToGet);
            var webProxy =
                new WebProxy(new Uri(PROXY_RACK_DNS))
                {
                    Credentials = new NetworkCredential(Username, Password)
                };

            httpWebRequest.Proxy = webProxy;


            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream == null)
            {
                return;
            }

            var responseString = new StreamReader(responseStream).ReadToEnd();
            Console.WriteLine($"Response:\n{responseString}");
            Console.ReadKey();
        }
    }
}
