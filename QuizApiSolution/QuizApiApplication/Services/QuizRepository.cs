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

        public List<Person> GetAllPersons()
        {
            return _ctx.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _ctx.Persons.SingleOrDefault(p => p.Id == id);

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

        public Answer CreateAnswer(Answer answer)
        {
            _ctx.Answers.Add(answer);
            _ctx.SaveChanges();
            return _ctx.Answers.SingleOrDefault(a => a.Id == answer.Id);   
        }

        public Quiz CreateQuiz(Quiz quiz)
        {
            _ctx.Quiz.Add(quiz);
            _ctx.SaveChanges();
            return _ctx.Quiz.SingleOrDefault(q => q.Id == quiz.Id);
        }

        public Person CreatePerson(Person person)
        {
            var _person = _ctx.Persons.Add(person);
            _ctx.SaveChanges();
            return _ctx.Persons.SingleOrDefault(p => p.Id == _person.Id);
        }

        public AnswerRegister CreateRegisterAnswer(AnswerRegister answerRegister)
        {
            var _answerRegister = _ctx.AnswerRegister.Add(answerRegister);
            _ctx.SaveChanges();
            return _ctx.AnswerRegister.SingleOrDefault(a => a.Id == _answerRegister.Id);
        }

        public List<AnswerRegister> GetAllRegisterdQuiz(Quiz quiz)
        {
           return _ctx.AnswerRegister.Where(q => q.Quiz.Id == quiz.Id).Include(q => q.Person).ToList();
        }
    }
}