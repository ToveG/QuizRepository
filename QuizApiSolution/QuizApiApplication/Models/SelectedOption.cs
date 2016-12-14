using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Models
{
    public class SelectedOption
    {
        [Required]
        public int questionId { get; set; }
        [Required]
        public int answerId { get; set; }
    }
}