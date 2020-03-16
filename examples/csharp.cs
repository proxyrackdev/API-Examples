using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProxyRackHttpExample
{
    public static class Program
    {
        private const string Username = "YOURUSERNAME";
        private const string Password = "YOURPASSWORD";
        private const string ProxyRackDns = "http://megaproxy.rotating.proxyrack.net:222";
        private const string UrlToGet = "http://ip-api.com/json";

        public static async Task Main()
        {
            using var httpClient = new HttpClient(new HttpClientHandler
            {
                Proxy = new WebProxy(ProxyRackDns),
                Credentials = new NetworkCredential(Username, Password)
            });

            using var responseMessage = await httpClient.GetAsync(UrlToGet);

            var contentString = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine("Response:" + Environment.NewLine + contentString);
            Console.ReadKey(true);
        }
    }
}
