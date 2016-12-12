using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class QuestionAnswered
    {
        public int Id { get; set; }
        public bool Answered { get; set; }
    }
}