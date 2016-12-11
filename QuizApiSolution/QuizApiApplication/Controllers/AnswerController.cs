using QuizApiApplication.Entities;
using QuizApiApplication.Services;
using QuizApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class AnswerController : ApiController
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

        [Route("api/questions/{questionId}/answer")]
        [HttpPost]
        public IHttpActionResult CreateAnswer(int _questionId,
         [FromBody] CreateAnswer answer)
            {
            
            if (answer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var question = QuizRepository.GetQuestionById(_questionId);

            if (question == null)
            {
                return NotFound();
            }

            var answerToInsert = new Entities.Answer()
            {
                AnswerAlternetive = answer.AnswerAlternetive,
                CorrectAnswer = answer.CorrectAnswer,
                question = question
            };

            var item = QuizRepository.CreateAnswer(answerToInsert);

            return Created("GetResponseOption", Mapper.Map<Models.ResponseOption>(item));
        }

    }
}
