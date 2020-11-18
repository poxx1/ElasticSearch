using IBM.Cloud.SDK.Core.Authentication.Iam;
using System;
using System.Configuration;
using System.Collections.Specialized;
using IBM.Watson.Discovery.v1;
using IBM.Watson.Discovery.v1.Model;
using System.Collections.Generic;
using IBM.Cloud.SDK.Core.Http;
using System.IO;

namespace ElasticSearch
{
    class WatsonDiscovery
    {
        public object REST(string[] parameters)
        {
            string urlCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["URL"];
            string apikeyCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["APIKey"];
            string versionCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["Version"];
            string collectionCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["CollectionID"];
            string configCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["ConfigurationID"];
            string environmentCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["environmentID"];
            string docPathCfg = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["documentPath"];
            string docIdCFG = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["documentID"];
            string ibmUserCFG = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["userIBM"];
            string fileNameCFG = ((NameValueCollection)ConfigurationManager.GetSection("Watson/Discovery"))["documentName"];

            //Headers + Auth
            //IamAuthenticator authenticator = new IamAuthenticator(apikey: "D_nQRIAE4URpHN53bhMvgPQKfXPmOmAJhIbNQ86ZQdUV");
            IamAuthenticator authenticator = new IamAuthenticator(apikey: apikeyCfg);

            DiscoveryService discovery = new DiscoveryService(versionCfg, authenticator);
            
            discovery.SetServiceUrl("https://api.us-east.discovery.watson.cloud.ibm.com");

            discovery.DisableSslVerification(true);
            
            discovery.WithHeader("X-Watson-Learning-Opt-Out", "true");

            try 
            { 
            //Update Collection
            //Paso 1. Leer Base de datos. Paso 2. Leer collections. Paso 3. Si es necesario, actualizar.
            DetailedResponse<DocumentAccepted> result;
           
            using (FileStream fs = File.OpenRead(docPathCfg))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                        result = discovery.UpdateDocument(
                            environmentId: environmentCfg,
                            collectionId: collectionCfg,
                            documentId: docIdCFG,
                            file: ms,
                            filename: fileNameCFG,
                            fileContentType: "text/html",
                            metadata: "{ \"Creator\": \""+ibmUserCFG+"\", \"Subject\": \"Update\" }"
                            );
                }
            }

            Console.WriteLine("\r\nWatson Discovery: La informacion se cargo exitosamente.");
            
            return result.Response;

        }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la carga en Watson Discovery");
                Console.WriteLine(e);
                return "Cant send request";
            }

        }
    
    }
}
