using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ElasticSearch
{
    class IOText
    {
        private string path1 = @"C:\Users\julian.lastra\Desktop\log.txt";
        private string path2 = @"C:\Users\julian.lastra\Desktop\response.txt";
        
        public string Read()
        {
            StreamReader sr = new StreamReader(path2);
            var text = sr.ReadToEnd();
            sr.Close();
            return text;
        }
        public string Read(string path)
        {
            StreamReader sr = new StreamReader(path);
            var text = sr.ReadToEnd();
            sr.Close();
            return text;
        }

        public void Write(string textToWrite)
        {
            StreamWriter sw = new StreamWriter(path1);
            sw.Write(textToWrite);
            sw.Close();
        }

        public void Write(string textToWrite,string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(textToWrite);
            sw.Close();
        }
    }
}

