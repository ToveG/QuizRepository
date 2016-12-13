using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class ReportViewModel
    {
        public string QuizName { get; set; }
        public int AmountOfAnswers { get; set; }
        public int MaximumScoore { get; set; }
        public decimal AverageScoore { get; set; }

    }
}