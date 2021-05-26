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
        public DbSet<SecondTest_Questions> SecondTest_Questions { get; set; }
        public DbSet<FirstTest_Questions> FirstTest_Questions { get; set; }
        public DbSet<FirstTest_Answers> FirstTest_Answers { get; set; }
        public DbSet<SecondTest_Answers> SecondTest_Answers { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

    }
}


