using System.ComponentModel.DataAnnotations;

namespace TestUsers
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [Required]
        [MaxLength(300)]
        public string AnswerText { get; set; }
    }
}
