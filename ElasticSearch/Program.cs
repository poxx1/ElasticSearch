using System;

namespace ElasticSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bot integration");

            Requests r = new Requests();
            r.url = "http://localhost:9200/";
            r.response = r.get();
            Console.WriteLine(r.response);
        }

    }
}
