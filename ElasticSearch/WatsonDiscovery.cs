using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using System;
using System.Configuration;
using System.Collections.Specialized;

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

            AssistantService assistant = new AssistantService(versionCfg, authenticator);

            assistant.SetServiceUrl(urlCfg);

            assistant.DisableSslVerification(true);

            assistant.WithHeader("X-Watson-Learning-Opt-Out", "true");

            try
            {
                //Creo la session para poder iniciar el chat.
                var result = assistant.CreateSession(
                assistantId: assisntantIDCfg);

                //La respuesta con el Session ID
                //Console.WriteLine(result.Response+"\r\n\r\n");

                var sessionId = result.Result.SessionId;

                sessionId = result.Result.SessionId;

                //Trabajo con los parametros de entrada
                foreach (var p in parameters)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine(p.ToString());
                    Console.ForegroundColor = ConsoleColor.Cyan;

                }

                string text = "Blue";//parameters[0]; // "pregunta";

                //Obtenido el sessionId envio el mensaje que recivo por parametro de ejecucion
                var r = assistant.Message(
                assistantId: assisntantIDCfg,
                sessionId: "" + sessionId + "",
                input: new MessageInput()
                {
                    //Message to send
                    Text = text
                }
                );

                return r.Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Cant send request";
            }

        }
    
    }
}
