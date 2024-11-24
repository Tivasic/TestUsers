using Microsoft.EntityFrameworkCore;

namespace TestUsers.models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<TrueAnswer> TrueAnswers { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=test_db2;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи "один ко многим" между Test и Question
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи "один ко многим" между Question и Answer
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи "один к одному" между Question и TrueAnswer
            modelBuilder.Entity<TrueAnswer>()
                .HasKey(ta => ta.QuestionId);

            modelBuilder.Entity<TrueAnswer>()
                .HasOne(ta => ta.Question)
                .WithOne(q => q.TrueAnswer)
                .HasForeignKey<TrueAnswer>(ta => ta.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrueAnswer>()
                .HasOne(ta => ta.Answer)
                .WithMany()
                .HasForeignKey(ta => ta.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Настройка связи "один ко многим" между Users и TestResults
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.User)
                .WithMany(u => u.TestResults)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи "один ко многим" между Tests и TestResults
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany(t => t.TestResults)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
