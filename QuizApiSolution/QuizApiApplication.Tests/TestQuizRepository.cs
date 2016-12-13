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
            var answers = new List<Answer>();
            answers.Add(answer);

            return answers.SingleOrDefault(a => a.CorrectAnswer == true);
        }

        public Person CreatePerson(Person person)
        {
            var people = new List<Person>();
            people.Add(person);

            return people.SingleOrDefault(p => p.Name == person.Name);
        }

        public Question CreateQuestion(Question question)
        {
            var questions = new List<Question>();
            questions.Add(question);

            return questions.SingleOrDefault(q => q.QuestionTitle == question.QuestionTitle);
        }

        public Quiz CreateQuiz(Quiz quiz)
        {
            var _quiz = new List<Quiz>();
            _quiz.Add(quiz);

            return _quiz.SingleOrDefault(p => p.Name == quiz.Name);
        }

        public AnswerRegister CreateRegisterAnswer(AnswerRegister answerRegister)
        {
            var aRegister = new List<AnswerRegister>();
            aRegister.Add(answerRegister);

            return aRegister.SingleOrDefault(a => a.Id == answerRegister.Id);
        }

        public List<Person> GetAllPersons()
        {
            var peopleList = new List<Person>();
            peopleList.Add(new Person { Name = "test" });
            peopleList.Add(new Person { Name = "test" });

            return peopleList;
        }

        public List<Quiz> GetAllQuiz()
        {
            var quizList = new List<Quiz>();
            List<Question> q = new List<Question>();
            quizList.Add(new Quiz { Name = "test", Questions = q});
            quizList.Add(new Quiz { Name = "test", Questions = q });

            return quizList;

        }

        public List<AnswerRegister> GetAllRegisterdQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public Person GetPersonById(int id)
        {
            var people = new List<Person>();
            people.Add(new Person { Id = 1, Name = "test" });
            people.Add(new Person { Id = 2, Name = "test" });

            var p = people.FirstOrDefault(x => x.Id == id);
            return p;
        }

        public Question GetQuestionById(int id)
        {
            var questions = new List<Question>();
            var answers = new List<Answer>();
            var a = new Answer() { Id = 1 };
            answers.Add(a);
            questions.Add(new Question { Id = 1, QuestionTitle = "test", Answers = answers });
            questions.Add(new Question { Id = 2, QuestionTitle = "test", Answers = answers });

            var q = questions.FirstOrDefault(x => x.Id == id);
            return q;
        }

        public Quiz GetQuizById(int id)
        {
            var quiz = new List<Quiz>();
            var questions = new List<Question>();
            var answers = new List<Answer>();
            var a = new Answer() { Id = 1 };
            answers.Add(a);
            var qu = new Question() { Id = 1, Answers = answers };
            questions.Add(qu);
            quiz.Add(new Quiz { Id = 1, Name = "test", Questions = questions });
            quiz.Add(new Quiz { Id = 2, Name = "_test", Questions = questions });

            var q = quiz.FirstOrDefault(x => x.Id == id);
            return q;

        }

        public List<AnswerRegister> GetQuizReportById(int quizId)
        {
            throw new NotImplementedException();
        }

        public List<AnswerRegister> GetRegisterdQuizByPersonId(int quizId, int personId)
        {
            throw new NotImplementedException();
        }

        List<Question> IQuizRepository.GetAllQuestions()
        {
            var questionList = new List<Question>();
            questionList.Add(new Question { QuestionTitle = "test" });
            questionList.Add(new Question { QuestionTitle = "test" });

            return questionList;
        }
    }
}
