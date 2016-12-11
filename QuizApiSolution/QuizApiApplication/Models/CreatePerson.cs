using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace QuizApiApplication.Models
{
    public class CreatePerson
    {
        [Required]
        public string Name { get; set; }
    }
}