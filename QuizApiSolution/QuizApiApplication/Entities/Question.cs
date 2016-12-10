using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public ICollection<Answer> Answers { get; set; }

    }
}