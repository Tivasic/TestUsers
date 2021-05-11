using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace TestUsers.models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SmartTruck_Questions> SmartTruck_Questions { get; set; }
        public DbSet<SmartTruck_Answers> SmartTruck_Answers { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

    }
}
