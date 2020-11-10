using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace ElasticSearch
{
    class Requests
    {
        public string url { get; set; }
        public string response { get; set; }

        public string get()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    response = client.DownloadString(url);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Request Succesfull\r\n");
                }
            }
            catch (Exception e)
            {
                response = "Error in request" + e;
            }

            return response;
        }

        public string getRest()
        {
            var client = new RestClient("http://elkcl.tsoftglobal.com:9200");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic bWlrZTpNaWtlMjAyMA==");
            IRestResponse response = client.Execute(request);
            Console.WriteLine("\r\nElastic Search: Conexion exitosa!");
            return response.Content;
        }
        public string post()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    
                    response = client.DownloadString(url);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Request Succesfull\r\n");
                }
            }
            catch (Exception e)
            {
                response = "Error in request" + e;
            }

            return response;
        }
    }
}
