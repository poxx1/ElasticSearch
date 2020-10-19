using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class CSVLoad
    {
        public string cmdExectutor(string command)
        {
            Process.Start("cmd.exe", command);
            var p = Process.GetCurrentProcess();
            p.WaitForExit();
            var result = p.ExitCode.ToString();
            return result;
        }
    }
}
