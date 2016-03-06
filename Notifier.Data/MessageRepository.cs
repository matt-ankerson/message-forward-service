using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Data
{
    public class MessageRepository : IMessageRepository
    {
        private NotifierDbContext _context;
        private bool disposed = false;

        public MessageRepository(NotifierDbContext context)
        {
            _context = context;
        }


        public void DeleteMessage(int messageId)
        {
            Message messageToDelete = _context.Messages.Find(messageId);
            _context.Messages.Remove(messageToDelete);
        }

        public Message GetMessageById(int messageId)
        {
            return _context.Messages.Find(messageId);
        }

        public IEnumerable<Message> GetMessages()
        {
            return _context.Messages.OrderBy(x => x.TimeRecieved).ToList();
        }

        public void InsertMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {
            _context.Entry(message).State = System.Data.Entity.EntityState.Modified;
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MessageRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
