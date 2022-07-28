using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace DataService
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");

            var request= client.GetAsync("api/Car").Result;
            if (request.IsSuccessStatusCode)
            {
                var resulData = request.Content.ReadAsStringAsync().Result;
                var listData = JsonConvert.DeserializeObject<List<Car>>(resulData);

                Console.WriteLine(resulData);

            }
        }
    }
}