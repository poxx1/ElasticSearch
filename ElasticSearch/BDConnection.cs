using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ElasticSearch
{
    class BDConnection
    {
        public string[] Consulta(string query)
        {
            SqlConnection _conexion = new SqlConnection(@"Server=AR-NB-415\SQLEXPRESS; Initial Catalog=ElasticSearch;Integrated Security=True");
            var cmd = new SqlCommand(query, _conexion);
            var objeto = new object();
            var objeto1 = new object();
            cmd.CommandTimeout = 5;
            int counter = 0;

            //Abro la conexion
            try
            {
                _conexion.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            string[] server = new string[4];
            

            //Ejecuto la consulta
            try
            {
                using (SqlDataReader dr = cmd.ExecuteReader())

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            server[0] = dr[0].ToString();
                            server[1] = dr[1].ToString();
                            server[2] = dr[1].ToString();
                            server[3] = dr[1].ToString();
                            //counter++;
                        }
                    }
                    else
                    {
                        server[0] = "No existen ocurrencias para el server";        
                    }
            }
            catch (Exception e)
            {
                throw e;
            }

            _conexion.Close();

            return server;
        }

        public object Insert(string query)
        {
            object ok=9;
            return ok;
        }
        public bool test()
        {

            SqlConnection _conexion = new SqlConnection(@"Server=AR-NB-415\SQLEXPRESS; Initial Catalog=ElasticSearch;Integrated Security=True");
            
            //Abro la conexion
            try
            {
                _conexion.Open();
                _conexion.Close();
                Console.WriteLine("Connection was succesfull!");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cant connect to database!\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                throw e;
            }
            return true;
        }
    }
}

