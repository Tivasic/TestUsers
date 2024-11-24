using System.ComponentModel.DataAnnotations;
using System;

namespace TestUsers
{
    public class TestResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PercentageCorrectAnswers { get; set; }

        [Required]
        public DateTime TestDate { get; set; }

        [Required]
        public TimeSpan TestDuration { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users User { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}


