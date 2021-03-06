﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerAlternative { get; set; }
        public bool CorrectAnswer { get; set; }

        public virtual Question question { get; set; }
        public int questionId { get; set; }

    }
}