using QuizApiApplication.Services;
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
            if(allQuiz == null)
            {
                return NotFound();
            }
            List<ViewQuiz> quizList = new List<ViewQuiz>(); 
            foreach (var quiz in allQuiz)
            {
                ViewQuiz q = new ViewQuiz();
                q.AmountOfQuestions = quiz.Questions.Count();
                q.QuizName = quiz.Name;
                quizList.Add(q);
            }
            return Ok(quizList);
        }

        [Route("api/quiz/{id}")]
        public IHttpActionResult GetSpecificQuiz(int id)
        {
            var selectedQuiz = QuizRepository.GetQuizById(id);
            if (selectedQuiz == null)
            {
                return NotFound();
            }
            var answers = selectedQuiz.Questions.Select(q => q.Answers);

            //Models.Quiz _quiz = new Models.Quiz();
            //_quiz.Name = selectedQuiz.Name;
            //_quiz.Questions = Mapper.Map<List<Models.Question>>(selectedQuiz.Questions);
            
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
