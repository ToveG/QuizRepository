using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class ViewRegistredQuizForSpecificPersonModel
    {
        public string QuizName { get; set; }
        public string AnsweredBy { get; set; }
        public string AnsweredDate { get; set; }
        public List<Question> question { get; set; }
        //public List<string> question { get; set; }
        //public List<string> answer { get; set; }
    }
}