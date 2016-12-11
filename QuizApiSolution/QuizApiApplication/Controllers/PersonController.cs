using AutoMapper;
using QuizApiApplication.Entities;
using QuizApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class PersonController : ApiController
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

        [Route("api/person")]
        [HttpPost]
        public IHttpActionResult CreatePerson(
            [FromBody] CreatePerson person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personToInsert = new Person()
            {
                Name = person.Name
            };

            var p = QuizRepository.CreatePerson(personToInsert);

            return Created("Created", Mapper.Map<Models.Person>(p));
        }



    }
}
