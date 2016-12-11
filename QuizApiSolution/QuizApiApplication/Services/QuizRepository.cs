using QuizApiApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuizApiApplication.Services
{
    public class QuizRepository : IQuizRepository
    {
        private DataContext _ctx = new DataContext();
         
        public List<Question> GetAllQuestions()
        {
            var questions = _ctx.Questions.Include(q => q.Answers).ToList();
            return questions;
        }

        public List<Quiz> GetAllQuiz()
        {
            return _ctx.Quiz.Include(q => q.Questions).ToList();
        }

        public Quiz GetQuizById(int id)
        {
            return _ctx.Quiz.Include(q => q.Questions).SingleOrDefault(q => q.Id == id);
             
        }

        public Question GetQuestionById(int id)
        {
            return _ctx.Questions.Include(q => q.Answers).SingleOrDefault(q => q.Id == id);
        }

        public Question CreateQuestion(Question question)
        {
            var _question = _ctx.Questions.Add(question);
            _ctx.SaveChanges();
            return _ctx.Questions.SingleOrDefault(q => q.Id == _question.Id);
        }
    }
}