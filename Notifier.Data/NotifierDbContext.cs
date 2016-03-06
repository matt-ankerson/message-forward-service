using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Notifier.Data
{
    public class NotifierDbContext : DbContext
    {
        // Call base constructor, pass in connection string name (located in App.config).
        public NotifierDbContext() : base("DefaultConnection")
        {
#if DEBUG
            //Database.SetInitializer(new DropCreateNotifierAlways());
#else
            // No initialization
#endif
        }


        public DbSet<Message> Messages { get; set; }
    }
}
