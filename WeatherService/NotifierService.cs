using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherService
{
    public partial class NotifierService : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MessageMonitor messageMonitor;
        private MessageSender messageSender;
        private bool monitorMessages = true;

        public NotifierService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the application is ran as a console app.
        /// </summary>
        /// <param name="args"></param>
        public void StartConsole(string[] args)
        {
            OnStart(args);
            Console.WriteLine("Press <enter> to stop service.");
            Console.Read();
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            log.Info("Notifier Service started.");
            messageMonitor = new MessageMonitor();
            messageSender = new MessageSender();

            // Start monitoring
            new Task(MonitorMessages).Start();
        }

        protected override void OnStop()
        {
            log.Info("Notifier Service stopped.");
        }

        protected override void OnPause()
        {
            base.OnPause();
            log.Info("Notifier Service paused.");
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            log.Info("Notifier Service continued.");
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
            log.Info("Notifier Service recieved custom command: " + command.ToString());
        }

        protected async void MonitorMessages()
        {
            while (monitorMessages)
            {
                // Get any new messages
                var newMessages = messageMonitor.GetMessagesIfAny();
                
                // Send any new messages out.
                if (newMessages.Count > 0)
                {
                    foreach (var message in newMessages)
                    {
                        var now = DateTime.Now;

                        Task<int> returnedTaskResult = messageSender.SendMessage(message, now);
                        int responseCode = await returnedTaskResult;

                        if (responseCode == 200)
                        {
                            messageMonitor.MarkMessageSent(message, now);
                        }
                    }
                    
                }

                // Query for new messages periodically
                Thread.Sleep(2000);
            }
        }
    }
}
