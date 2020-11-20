using System;
using System.Threading;

namespace ElasticSearch
{
    class Program
    {
        static void Main(string[] parameters)
        {
            #region Intro Screen
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                             REST API ELASTIC SEARCH");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                                        \r\n\r\n");
            Console.BackgroundColor = ConsoleColor.Black;
            #endregion

            Console.ForegroundColor = ConsoleColor.Green;

            Requests r = new Requests();
            BDConnection b = new BDConnection();
            WatsonDiscovery wd = new WatsonDiscovery();
            Core cr = new Core();

            while (true)
            {
                Email email = new Email();
                email.Send("Email Automation Test","Test: Sending.","julian.lastra@tsoftlatam.com");

                //1.Actualizar base de datos
                //cr.TextManager();
                //cr.Select("SV IQ Bot", "OK", "192.268.0.1", 83);

                //2.Actualizar Watson Discovery
                //var test = new string[] { "a", "b", "c" };
                //wd.REST(test);

                //3.Testing de la conexion con ElasticSearch
                //r.url = "http://elkcl.tsoftglobal.com:9200";
                //r.response = r.getRest();
                Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine(r.response);
                Console.ForegroundColor = ConsoleColor.Cyan;

                ////4.Insertar la data en Logstash
                //string path = @"C:\Users\julian.lastra\Downloads\logstash\bin\logstash -f csv.conf";
                //CSVLoad logstash = new CSVLoad();
                //logstash.cmdExectutor(path);

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("\r\nEsperando para iniciar el nuevo proceso..\r\n");

                Thread.Sleep(7500);

                Console.WriteLine("\r\nIniciando nuevo proceso..\r\n");
            }

        }

    }
}
