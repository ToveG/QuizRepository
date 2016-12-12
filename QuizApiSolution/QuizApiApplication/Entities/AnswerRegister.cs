using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Entities
{
    public class AnswerRegister
    {
        public int Id { get; set; }
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Person Person { get; set; }
        public DateTime AnsweredDate { get; set; }
        public bool Answered { get; set; }
    }
}