using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Dto
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public ICollection<Answer> Answers { get; set; }


        public virtual Quiz quiz { get; set; }
        public int quizId { get; set; }
    }
}
