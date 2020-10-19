using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class Serializer
    {
        public void Serialize()
        { 
        
        }

        public string Deserialize(string json)
        {

            Servers server = JsonConvert.DeserializeObject<Servers>(json);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\r\n\r\n" + server.Name);

            return server.Name+";"+server.Status;

        }
    }
}
