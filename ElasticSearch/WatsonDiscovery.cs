using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using System;
using System.Configuration;
using System.Collections.Specialized;
using IBM.Watson.Discovery.v1;
using IBM.Watson.Discovery.v1.Model;
using System.Collections.Generic;

namespace ElasticSearch
{
    class WatsonDiscovery
    {
        public object REST(string[] parameters)
        {
            string urlCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Chat"))["URL"];
            string apikeyCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Chat"))["APIKey"];
            string versionCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Chat"))["Version"];
            string assisntantIDCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Chat"))["AssistantID"];

            //Headers + Auth
            //IamAuthenticator authenticator = new IamAuthenticator(apikey: "D_nQRIAE4URpHN53bhMvgPQKfXPmOmAJhIbNQ86ZQdUV");
            IamAuthenticator authenticator = new IamAuthenticator(apikey: apikeyCfg);

            DiscoveryService discovery = new DiscoveryService(versionCfg, authenticator);
                
            //discovery.SetServiceUrl(urlCfg);

            discovery.SetServiceUrl("https://api.us-east.discovery.watson.cloud.ibm.com");

            discovery.DisableSslVerification(true);

            discovery.WithHeader("X-Watson-Learning-Opt-Out", "true");

            //Update Collection
            //Paso 1. Leer Base de datos. Paso 2. Leer collections. Paso 3. Si es necesario, actualizar.
            try
            {
                var expansions = new List<Expansion>()
                {
                     new Expansion()
                     {
                         InputTerms = new List<string>()
                         {
                          "input-term"
                         },
                           ExpandedTerms = new List<string>()
                           {
                                  "expanded-term"
                           }
                     }
                };

                var result = discovery.CreateExpansions(
                    environmentId: "{environmentId}",
                    collectionId: "{collectionId}",
                    expansions: expansions
                    );

                Console.WriteLine(result.Response);
                return result.Response;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Cant send request";
            }

        }
    
    }
}
