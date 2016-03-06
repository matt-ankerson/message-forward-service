using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Data
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetMessages();
        Message GetMessageById(int messageId);
        void InsertMessage(Message message);
        void DeleteMessage(int messageId);
        void UpdateMessage(Message message);
        void Save();
    }
}
