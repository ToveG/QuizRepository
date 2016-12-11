using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApiApplication.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerAlternative { get; set; }
        public bool CorrectAnswer { get; set; }

    }
}
