using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Data;

namespace WeatherService
{
    /// <summary>
    /// Monitors the database, with the intent to forward new messages.
    /// </summary>
    public class MessageMonitor
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IMessageRepository _messageRepository;

        // Accept a message repository to facilitate database monitoring.
        public MessageMonitor(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// Uses default MessageRepository
        /// </summary>
        public MessageMonitor()
        {
            _messageRepository = new MessageRepository(new NotifierDbContext());
        }

        /// <summary>
        /// Returns any new messages. Returns empty list if no new messages.
        /// </summary>
        /// <returns>List of messages unseen</returns>
        public List<Message> GetMessagesIfAny()
        {
            log.Info("Querying for new messages.");
            var newMessages = _messageRepository.GetMessages().Where(m => m.TimeSent == null).ToList();
            log.Info("Found " + newMessages.Count().ToString() + " new messages.");
            return newMessages;
        }

        /// <summary>
        /// Update the given messages' sent fields, to ensure they're not forwarded again.
        /// </summary>
        /// <param name="sentMessages"></param>
        public void MarkMessagesSent(List<Message> sentMessages, DateTime timeSent)
        {
            log.Info("Marking " + sentMessages.Count.ToString() + " messages as sent.");
            foreach (var message in sentMessages)
            {
                // Update sent time
                message.TimeSent = timeSent;
                // Update the record
                _messageRepository.UpdateMessage(message);
            }

            // Save
            _messageRepository.Save();
            log.Info(sentMessages.Count.ToString() + " messages marked as read.");
        }

        public void MarkMessageSent(Message message, DateTime timeSent)
        {
            log.Info("Marking message (Id: " + message.MessageId.ToString() + ") as sent.");

            // Update sent time
            message.TimeSent = timeSent;
            // Update the record
            _messageRepository.UpdateMessage(message);

            // Save
            _messageRepository.Save();
            log.Info("Marked message (Id: " + message.MessageId.ToString() + ") as sent.");
        }
    }
}
