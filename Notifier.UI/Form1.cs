using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notifier.Data;

namespace Notifier.UI
{
    public partial class Form1 : Form
    {
        private IMessageRepository _messageRepository;

        public Form1()
        {
            InitializeComponent();
            _messageRepository = new MessageRepository(new NotifierDbContext());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var senderName = txtSenderName.Text;
            var messageContent = txtMessageContent.Text;

            var newMessage = new Notifier.Data.Message {
                TimeRecieved = DateTime.Now,
                MessageContent = messageContent,
                Sender = senderName
            };

            _messageRepository.InsertMessage(newMessage);
            _messageRepository.Save();

            // Clear text boxes
            txtMessageContent.Clear();
            txtSenderName.Clear();
        }
    }
}
