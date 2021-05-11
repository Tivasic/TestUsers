using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestUsers
{
    public class SmartTruck_Answers
    {
        public int id { get; set; }
        private string answer_1, answer_2, answer_3, answer_4;

        public string Answer_1
        {
            get { return answer_1; }
            set
            {
                if (value == answer_1) return;
                answer_1 = value;
            }
        }

        public string Answer_2
        {
            get { return answer_2; }
            set
            {
                if (value == answer_2) return;
                answer_2 = value;
            }
        }
        public string Answer_3
        {
            get { return answer_3; }
            set
            {
                if (value == answer_3) return;
                answer_3 = value;
            }
        }
        public string Answer_4
        {
            get { return answer_4; }
            set
            {
                if (value == answer_4) return;
                answer_4 = value;
            }
        }

        public SmartTruck_Answers() { }

        public SmartTruck_Answers(int id, string answer_1, string answer_2, string answer_3, string answer_4)
        {
            this.id = id;
            this.answer_1 = answer_1;
            this.answer_2 = answer_2;
            this.answer_3 = answer_3;
            this.answer_4 = answer_4;
        }
    }
}

