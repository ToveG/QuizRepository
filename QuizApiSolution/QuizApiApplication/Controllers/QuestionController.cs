using AutoMapper;
using QuizApiApplication.Entities;
using QuizApiApplication.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class QuestionController : ApiController
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

        [Route("api/questions")]
        public IHttpActionResult Get()
        {
            var questions = QuizRepository.GetAllQuestions();
            return Ok(Mapper.Map<IEnumerable<Models.Question>>(questions));
        }

        [Route("api/questions/{id}")]
        public IHttpActionResult GetSpecificQuestion(int id)
        {
            var question = QuizRepository.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Models.Question>(question));
        }

        [Route("api/questions/quiz/{quizId}")]
        [HttpPost]
        public IHttpActionResult CreateQuestion(int quizId,
            [FromBody] Models.CreateQuestion questionItem)
        {
            var quiz = QuizRepository.GetQuizById(quizId);
            if(quiz == null)
            {
                return NotFound();
            }

            if (questionItem == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToInsert = new Question()
            {
                QuestionTitle = questionItem.Title,
                quiz = quiz
            };

            var question = QuizRepository.CreateQuestion(itemToInsert);

            return Created("Created", Mapper.Map<Models.Question>(question));

        }

    }
}
