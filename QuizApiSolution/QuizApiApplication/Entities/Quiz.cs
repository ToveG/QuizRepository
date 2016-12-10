using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}