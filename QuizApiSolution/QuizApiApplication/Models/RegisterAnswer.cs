using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class RegisterAnswer
    {
        public int nameId { get; set; }
        public int questionId { get; set; }
        public int answerId { get; set; }
    }
}