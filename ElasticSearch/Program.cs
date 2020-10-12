using System;

namespace ElasticSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Intro Screen
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                             REST API ELASTIC SEARCH");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                                        \r\n\r\n");
            Console.BackgroundColor = ConsoleColor.Black;
            #endregion

            Requests r = new Requests();
            r.url = "http://localhost:9200/";
            r.response = r.get();
            Console.WriteLine(r.response);
        }

    }
}
