using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestUsers
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionText { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public TrueAnswer TrueAnswer { get; set; }
    }
}