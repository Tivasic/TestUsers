﻿using TestUsers;

namespace TestUsers
{
    public class TrueAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}