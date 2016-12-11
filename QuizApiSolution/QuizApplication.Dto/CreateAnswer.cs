using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Dto
{
    public class CreateAnswer
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string AnswerAlternetive { get; set; }
        [Required]
        public bool CorrectAnswer { get; set; }
    }
}
