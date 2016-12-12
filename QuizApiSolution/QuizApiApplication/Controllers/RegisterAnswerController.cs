using QuizApiApplication.Entities;
using QuizApiApplication.Models;
using QuizApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class RegisterAnswerController : ApiController
    {
        private IQuizRepository _quizRepository = null;
        private DataContext ctx = new DataContext();

        public IQuizRepository QuizRepository
        {
            get
            {
                if (_quizRepository == null)
                    _quizRepository = new QuizRepository();

                return _quizRepository;
            }
            set { _quizRepository = value; }
        }

        [Route("api/regiser/quiz/{quizid}")]
        [HttpPost]
        public IHttpActionResult RegisterAnswer(int quizId,
            [FromBody] RegisterAnswer regAnswer)
        {
             var quiz = QuizRepository.GetQuizById(quizId);
             if(quiz == null)
            {
                return NotFound();
            }
            var question = quiz.Questions.SingleOrDefault(q => q.Id == regAnswer.questionId);
            if(question == null)
            {
                return NotFound();
            }
            var selectedQuestion = QuizRepository.GetQuestionById(question.Id);
            if(selectedQuestion == null)
            {
                return NotFound();
            }
            var answer = selectedQuestion.Answers.SingleOrDefault(d => d.Id == regAnswer.answerId);
            if(answer == null)
            {
                return NotFound();
            }

            var person = QuizRepository.GetPersonById(regAnswer.nameId);

            AnswerRegister answerRegister = new AnswerRegister()
            {
                Question = question,
                Person = person,
                Quiz = quiz,
                AnsweredDate = DateTime.Now,
                Answered = true
            };
            QuizRepository.CreateRegisterAnswer(answerRegister);
            return Ok();

        }
    }
}
