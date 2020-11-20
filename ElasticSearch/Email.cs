using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Exchange.WebServices.Data;
using System.Collections.Specialized;
using System.Configuration;

namespace ElasticSearch
{
    public class Email
    {
        static TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local.Id == "Pacific SA Standard Time" ?
            TimeZoneInfo.CreateCustomTimeZone("WorkAround TimeZioneInfo", TimeZoneInfo.Local.BaseUtcOffset, "WorkAround TimeZoneInfo", "WorkAround TimeZoneInfo") : TimeZoneInfo.Local;
        private ExchangeService exchangeService = new ExchangeService(ExchangeVersion.Exchange2013, timeZoneInfo);
        CredentialManager credentials = new CredentialManager();

        string exhangeData = ((NameValueCollection)ConfigurationManager.GetSection("Utilidades/Email"))["ExchangeUrl"];

        string[] multipleRecipients;

        public void Send(string subject, string body, string recipients)
        {
            exchangeService.UseDefaultCredentials = false;
            credentials.Email();
            exchangeService.Credentials = new WebCredentials(credentials.Username, credentials.Password);
            exchangeService.Url = new Uri(exhangeData);

            //ElasticAutomation@outlook.com

            try
            {
                var message = new EmailMessage(exchangeService) { Subject = subject, Body = body };
                message.Body.BodyType = BodyType.HTML;

                multipleRecipients = recipients.Split(';');
                foreach (var recipient in multipleRecipients)
                {
                    message.ToRecipients.Add(recipient);
                }

                message.Send();

                Console.WriteLine("El mensaje ha sido enviado");

                message.ToRecipients.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo enviar el correo \r\n" + ex);
            }

        }
    }
}
