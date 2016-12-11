﻿using QuizApiApplication.Services;
using QuizApiApplication.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using QuizApiApplication.Models;

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

        [Route("api/quiz")]
        public IHttpActionResult Get()
        {
            var allQuiz = QuizRepository.GetAllQuiz();
            foreach (var quiz in allQuiz)
            {
                var questionCount = quiz.Questions.Count();
                quiz.totalAmountOfQuestions = questionCount;
            }

            return Ok(Mapper.Map<IEnumerable<Models.Quiz>>(allQuiz));
        }

        [Route("api/quiz/{id}")]
        public IHttpActionResult GetSpecificQuiz(int id)
        {
            var selectedQuiz = QuizRepository.GetQuizById(id);
            if (selectedQuiz == null)
            {
                return NotFound();
            }



            return Ok(Mapper.Map<Models.Quiz>(selectedQuiz));
        }

        [Route("api/quiz")]
        [HttpPost]
        public IHttpActionResult CreateQuiz(
            [FromBody] CreateQuiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quizToInsert = new Entities.Quiz()
            {
                Name = quiz.Name
            };

            var item = QuizRepository.CreateQuiz(quizToInsert);

            return Created("Created", Mapper.Map<Models.Quiz>(item));
        }
    }
}
