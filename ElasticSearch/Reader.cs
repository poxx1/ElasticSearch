using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class Reader
    {
        public void cmdExectutor(string command)
        {
            //El proceso queda clavado al transcurrir unos segundos
            //Hay que solucionar para matar al proceso al cabo de un minuto y luego continuar.

            Process.Start("cmd.exe","/C"+ command);
            Console.WriteLine("Updateing ElasticDatabase with Logstash");
            var p = Process.GetCurrentProcess();
            Console.WriteLine(p.ProcessName);

            //p.WaitForExit();
            //var result = p.ExitCode.ToString();
            //return result;
        }
    }
}
