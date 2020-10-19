using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class Core
    {
        //Leer desde la base de datos para detectar cambios
        //Select * from Servers Where updated=false;
        //
        BDConnection insert = new BDConnection();
        public string status { get; set; }
        public string name { get; set; }
        public void Insert(string name,string status)
        {
            //Inserto 1 a 1 los servidores
            insert.Consulta("INSERT into Servers (Name,Status) VALUES ("+name+","+status+")");
        }
        //Escribir en la base de datos nuevas ocurrencias

    }
}
