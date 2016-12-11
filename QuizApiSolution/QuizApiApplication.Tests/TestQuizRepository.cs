using QuizApiApplication.Entities;
using QuizApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApiApplication.Tests
{
    class TestQuizRepository :IQuizRepository 
    {
        public Answer CreateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Question CreateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Quiz CreateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public List<Quiz> GetAllQuiz()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuizById(int id)
        {
            throw new NotImplementedException();
        }

        List<Question> IQuizRepository.GetAllQuestions()
        {
            return null;
        }
    }
}
