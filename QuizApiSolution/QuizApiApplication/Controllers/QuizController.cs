using QuizApiApplication.Services;
using QuizApiApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace QuizApiApplication.Controllers
{
    public class QuizController : ApiController
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

        public IHttpActionResult Get()
        {
            var allQuiz = QuizRepository.GetAllQuiz();
            foreach (var quiz in allQuiz)
            {
                var questionCount = quiz.Questions.Count();
                quiz.totalAmountOfQuestions = questionCount;
            }

            return Ok(Mapper.Map<IEnumerable<QuizApplication.Dto.Quiz>>(allQuiz));
        }

        [Route("api/quiz/{id}")]
        public IHttpActionResult GetSpecificQuiz(int id)
        {
            var selectedQuiz = QuizRepository.GetQuizById(id);
            if (selectedQuiz == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<QuizApplication.Dto.Quiz>(selectedQuiz));
        }
    }
}
