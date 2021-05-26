using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TestUsers
{
    [Table("FirstTest_Questions")]
    public class FirstTest_Questions : BaseModelQuestions
    {
    }
    [Table("SecondTest_Questions")]
    public class SecondTest_Questions : BaseModelQuestions
    {
    }
    public class BaseModelQuestions
    {
        public int id { get; set; }
        private string question, true_answer;

        public string Question
        {
            get { return question; }
            set
            {
                if (value == question) return;
                question = value;
            }
        }

        public string True_answer
        {
            get { return true_answer; }
            set
            {
                if (value == true_answer) return;
                true_answer = value;
            }
        }

        public BaseModelQuestions() { }

        public BaseModelQuestions(int id, string question, string true_answer)
        {
            this.id = id;
            this.question = question;
            this.true_answer = true_answer;
        }
    }
}

