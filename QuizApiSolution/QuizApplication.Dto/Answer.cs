using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Dto
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerAlternetive { get; set; }
        public bool CorrectAnsswer { get; set; }

    }
}
