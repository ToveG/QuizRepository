using AutoMapper;
using QuizApiApplication.Entities;
using QuizApiApplication.Services;
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

        
        
        ////[Route("api/answer/question/{questionId}")]
        //[Route("api/answer/question")]
        //[HttpPost]
        ////public IHttpActionResult CreateAnswer(int questionId,
        //public IHttpActionResult CreateAnswer(
        //[FromBody] Models.CreateAnswer answer)
        //    {
            
        //    if (answer == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var question = QuizRepository.GetQuestionById(answer.QuestionId);
        //    //var question = QuizRepository.GetQuestionById(questionId);

        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    var answerToInsert = new Answer()
        //    {
        //        AnswerAlternative = answer.AnswerAlternative,
        //        CorrectAnswer = answer.CorrectAnswer,
        //        question = question
        //    };

        //    var item = QuizRepository.CreateAnswer(answerToInsert);

        //    return Created("Created", Mapper.Map<Models.Answer>(item));
        //}
    }
}
