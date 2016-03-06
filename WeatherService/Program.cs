using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Create the service
            NotifierService service = new NotifierService();

            // Is the app being started via either the .exe or VS?
            if (Environment.UserInteractive)
            {
                service.StartConsole(args);
            }
            else    // ...or is it being run as a service?
            {
                ServiceBase.Run(service);
            }
            
        }
    }
}
