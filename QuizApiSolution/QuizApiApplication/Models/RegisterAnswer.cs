using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class RegisterAnswer
    {
        [Required]
        public int nameId { get; set; }
        //[Required]
        //public int questionId { get; set; }
        //[Required]
        //public int answerId { get; set; }

        [Required]
        public List<SelectedOption> selectedAnswerPerQuestion { get; set; }
    }
}