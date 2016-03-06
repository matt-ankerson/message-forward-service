using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Notifier.Data
{
    public class DropCreateNotifierAlways : DropCreateDatabaseAlways<NotifierDbContext>
    {
        protected override void Seed(NotifierDbContext context)
        {
            base.Seed(context);
            PopulateMessages(context);
        }

        private void PopulateMessages(NotifierDbContext context)
        {
            List<Message> messages = new List<Message>();

            messages.Add(new Message
            {
                TimeRecieved = DateTime.Now,
                TimeSent = DateTime.Now,
                MessageContent = "Sample content",
                Sender = "Anonymous"
            });
            messages.Add(new Message
            {
                TimeRecieved = DateTime.Now,
                TimeSent = null,
                MessageContent = "Sample content 1",
                Sender = "Anonymous"
            });
            messages.Add(new Message
            {
                TimeRecieved = DateTime.Now,
                TimeSent = null,
                MessageContent = "Sample content 2",
                Sender = "Anonymous"
            });
            messages.Add(new Message
            {
                TimeRecieved = DateTime.Now,
                TimeSent = null,
                MessageContent = "Sample content 3",
                Sender = "Anonymous"
            });

            messages.ForEach(m => context.Messages.Add(m));
            context.SaveChanges();
        }
    }
}
