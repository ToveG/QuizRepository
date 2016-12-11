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
        List<Question> IQuizRepository.GetAllQuestions()
        {
            return null;
        }
    }
}
