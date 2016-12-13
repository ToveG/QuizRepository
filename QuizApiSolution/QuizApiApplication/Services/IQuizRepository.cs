using QuizApiApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApiApplication.Services
{
    public interface IQuizRepository
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        List<Quiz> GetAllQuiz();
        Quiz GetQuizById(int id);
        Question CreateQuestion(Question question);
        Answer CreateAnswer(Answer answer);
        Quiz CreateQuiz(Quiz quiz);
        List<Person> GetAllPersons();
        Person GetPersonById(int id);
        Person CreatePerson(Person person);
        AnswerRegister CreateRegisterAnswer(AnswerRegister answerRegister);
        List <AnswerRegister> GetAllRegisterdQuiz(Quiz quiz);
        List<AnswerRegister> GetRegisterdQuizByPersonId(int quizId, int personId);
        List<AnswerRegister> GetQuizReportById(int quizId);
    }
}
