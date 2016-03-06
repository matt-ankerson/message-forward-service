using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Data
{
    /// <summary>
    /// Holds information for a single message.
    /// </summary>
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime TimeRecieved { get; set; }
        public Nullable<DateTime> TimeSent { get; set; }
        public string Sender { get; set; }
        public string MessageContent { get; set; }

    }
}
