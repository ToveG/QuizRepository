using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class ViewQuizResultModel
    {
        public string QuizName { get; set; }
        public string AnsweredBy { get; set; }
        public DateTime AnsweredDate { get; set; }
    }
}