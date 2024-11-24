using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestUsers
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TestName { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
    }
}