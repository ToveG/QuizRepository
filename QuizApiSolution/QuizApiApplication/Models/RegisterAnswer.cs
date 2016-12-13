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
        public int questionId { get; set; }
        public int answerId { get; set; }
    }
}