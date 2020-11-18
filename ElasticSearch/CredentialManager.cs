using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch
{
    class CredentialManager
    {
        public string Username { get; set; }
        public string Password { get; set;}

        protected Credential cd = new Credential();

        public void ElasticSearch()
        {
            cd.Target = "elastic";
            cd.Load();
            Username = cd.Username;
            Password = cd.Password;
        }

        public void Kibana()
        {
            cd.Target = "kibana";
            cd.Load();
            Username = cd.Username;
            Password = cd.Password;
        }
    }
}

