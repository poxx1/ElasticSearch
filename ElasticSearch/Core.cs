using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElasticSearch
{
    class Core
    {
        BDConnection insert = new BDConnection();
        BDConnection update = new BDConnection();
        BDConnection select = new BDConnection();
        Servers sv = new Servers();
       
        bool exist = false;

        //1. Leo el archivo de texto actualizado.
        #region Text Document
        public void TextManager()
        {
            //Cambiar por el app.config XML
            string subPath = @"C:\Users\julian.lastra\Desktop\servers.txt";

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
              //  System.IO.Directory.CreateDirectory(subPath);

            if (!File.Exists(subPath))
            {
                using (FileStream fs = File.Create(subPath))
                {
                    //Add some text to file
                    //byte[] author = new UTF8Encoding(true).GetBytes("Por favor completar con los datos del servidor: [Nombre];[Estado]");
                    //fs.Write(author, 0, author.Length);
                }
            }

            //Lector del archivo
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(subPath);
            var listServers = new List<Servers>();

            while((line = file.ReadLine()) != null)
            {
                try
                {
                    listServers.Add(new Servers
                    {
                        Name = line.Split(';')[0],
                        Status = line.Split(';')[1],
                        Usage = Convert.ToString(line.Split(';'))[2],
                        IP = line.Split(';')[3]
                    }
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            foreach (var item in listServers)
            {
                Select(item.Name, item.Status,item.IP,item.Usage);
            }
        }

        #endregion

        //Pregunto a la base de datos si existe el actual
        public void Select(string name,string status,string ip, int usage)
        { 
            var response = select.Consulta("SELECT * FROM ServersV3 WHERE name = '"+name+"'");
            //si respuesta ok, exist = true, else not  if(select)
            if (response[1] != null)
            {
                //Ejecutar update.
                Update(response[0],status);
                //Console.WriteLine("SQL DB: la base de datos fue actualizada correctamente");
            }
            else
            {
                //Si no encuentro ocurrencias inserto el nuevo server en la base de datos
                Insert(name, status,ip,usage);
            }
            
        }

        //Select * from Servers Where updated=false;
       
        public void Insert(string name,string status,string IP,int usage)
        {
            //Inserto 1 a 1 los servidores
            insert.Consulta("INSERT into ServersV3 (Name,Status,IP,Disk_Usage) VALUES ('"+name+"','"+status+"','"+usage+"','"+IP+"')");
        }
        //Escribir en la base de datos nuevas ocurrencias

        public void Update(string name, string status)
        {
            update.Consulta("Update Servers SET Status = '"+status+"' WHERE Name = '"+name+"'");
            Console.WriteLine("\r\nSQL DB: la base de datos fue actualizada correctamente");
        }
    }
}
