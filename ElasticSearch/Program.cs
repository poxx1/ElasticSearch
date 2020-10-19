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

            Console.ForegroundColor = ConsoleColor.Green;

            Requests r = new Requests();
            BDConnection b = new BDConnection();
            
            r.url = "http://localhost:9200/";
            r.response = r.get();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(r.response);
            Console.ForegroundColor = ConsoleColor.Cyan;

            //r.url = "http://localhost:5601/api/reporting/generate/csv?jobParams=%28browserTimezone%3AAmerica%2FBuenos_Aires%2CconflictedTypesFields%3A%21%28%29%2Cfields%3A%21%28Name%2CStatus%2C_id%2C_index%2C_score%2C_type%2Ccolumn3%29%2CindexPatternId%3A%274d298f00-11c9-11eb-837e-1580ae756150%27%2CmetaFields%3A%21%28_source%2C_id%2C_type%2C_index%2C_score%29%2CobjectType%3Asearch%2CsearchRequest%3A%28body%3A%28_source%3A%28excludes%3A%21%28%29%29%2Cdocvalue_fields%3A%21%28%29%2Cquery%3A%28bool%3A%28filter%3A%21%28%28multi_match%3A%28lenient%3A%21t%2Cquery%3AName%2Ctype%3Abest_fields%29%29%29%2Cmust%3A%21%28%29%2Cmust_not%3A%21%28%29%2Cshould%3A%21%28%29%29%29%2Cscript_fields%3A%28%29%2Csort%3A%21%28%28_score%3A%28order%3Adesc%29%29%29%2Cstored_fields%3A%21%28%27%2A%27%29%2Cversion%3A%21t%29%2Cindex%3A%27servers%2A";
            //r.response = r.post();
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine(r.response);
            Console.ForegroundColor = ConsoleColor.Cyan;

            //Proceso de Extraccion de la informacion y guardado en un archivo de salida

            Serializer ser = new Serializer();
            IOTxt textFile = new IOTxt();
            var json = textFile.Read();
            var server = ser.Deserialize(json);
            textFile.Write(server);


            //            b.test();

            Console.ForegroundColor = ConsoleColor.Cyan;


        }

    }
}
