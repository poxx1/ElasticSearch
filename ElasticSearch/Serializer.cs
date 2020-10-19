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

            return server.Name + ";" + server.Status;

        }

        public string WatsonDeserialize(string json)
        {
            string g = json.ToString();
            g = g.Replace('"', ' ');
            var spl = g.Split("text :");
            var cResp = spl[1].Split('{');
            var finalR = cResp[0].Split("\r\n");
            string d = finalR[0];
            return d;
        }

    }
}
