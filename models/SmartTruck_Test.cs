using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestUsers
{
    public class SmartTruck_Test
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

        public SmartTruck_Test() { }

        public SmartTruck_Test(int id, string question, string true_answer)
        {
            this.id = id;
            this.question = question;
            this.true_answer = true_answer;
        }
    }
}

