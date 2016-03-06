using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Notifier.Data;

namespace WeatherService
{
    /// <summary>
    /// POST messages to a REST Api
    /// </summary>
    public class MessageSender
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// POST message data to remote REST Api
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>Response code</returns>
        public async Task<int> SendMessage(Message message, DateTime timeStamp)
        {
            using (var client = new HttpClient())
            {
                // Set up the http client
                client.BaseAddress = new Uri("http://ankerson.nz:3000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var payload = new {
                    originMessageId = message.MessageId,
                    timeRecieved = message.TimeRecieved,
                    timeSent = timeStamp,
                    messageContent = message.MessageContent,
                    sender = message.Sender };

                log.Info("Attempting to POST message");
                var response = await client.PostAsJsonAsync("message", payload);

                if (response.IsSuccessStatusCode)
                {
                    // POST successful.
                    log.Info("Message posted successfully");
                }
                else
                {
                    log.Error("Error posting message: " + response.StatusCode.ToString());
                }

                return (int)response.StatusCode;
            }
        }
    }
}
