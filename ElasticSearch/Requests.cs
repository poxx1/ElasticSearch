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
                }
            }
            catch (Exception e)
            {
                response = "Error in request" + e;
            }

            return response;
        }

        public string post()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    
                    response = client.DownloadString(url);
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
