using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApiApplication.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using QuizApiApplication.Models;

namespace QuizApiApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllQuestions()
        {
            var questions = questionController.Get() as OkNegotiatedContentResult<IEnumerable<Question>>;
            Assert.AreEqual(2, new List<Question>(questions.Content).Count);    
        }

        [TestMethod]
        public void GetAllQuiz()
        {
            var quiz = quizController.Get() as OkNegotiatedContentResult<List<ViewQuiz>>;
            Assert.AreEqual(2, new List<ViewQuiz>(quiz.Content).Count);
        }

        [TestMethod]
        public void GetAllPersons()
        {
            var persons = personController.Get() as OkNegotiatedContentResult<IEnumerable<Models.Person>>;
            Assert.AreEqual(2, new List<Models.Person>(persons.Content).Count);
            
        }

        [TestMethod]
        public void CreatePersons()
        {
            CreatePerson p = new CreatePerson { Name = "test" };

            var x = personController.CreatePerson(p) as CreatedNegotiatedContentResult<Person>;

            Assert.AreEqual(p.Name, x.Content.Name);
        }

        [TestMethod]
        public void CreateQuiz()
        {
            CreateQuiz q = new CreateQuiz { Name = "test" };

            var x = quizController.CreateQuiz(q) as CreatedNegotiatedContentResult<Quiz>;

            Assert.AreEqual(q.Name, x.Content.Name);
        }

        [TestMethod]
        public void CreateQuestion()
        {
            CreateQuestion q = new CreateQuestion { Title = "test" };

            var x = questionController.CreateQuestion(1,q) as CreatedNegotiatedContentResult<Question>;

            Assert.AreEqual(q.Title, x.Content.QuestionTitle);
        }

        [TestMethod]
        public void CreateAnswer()
        {
            CreateAnswer a = new CreateAnswer { QuestionId = 1, AnswerAlternative = "test", CorrectAnswer = true };

            var x = answerController.CreateAnswer(a) as CreatedNegotiatedContentResult<Answer>;

            Assert.AreEqual(true, x.Content.CorrectAnswer);
        }

        [TestMethod]
        public void GetSpecificQuestion()
        {
            var x = questionController.GetSpecificQuestion(1) as OkNegotiatedContentResult<Question>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestMethod]
        public void GetSpecificQuiz()
        {
            //            CreateQuiz q = new CreateQuiz { Name = "test" };
            var name = "test"; 
            var x = quizController.GetSpecificQuiz(1) as OkNegotiatedContentResult<Quiz>;

            Assert.AreEqual(name, x.Content.Name);
        }

        [TestMethod]
        public void GetSpecificPerson()
        {
            var x = personController.GetSpecificPerson(1) as OkNegotiatedContentResult<Person>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestMethod]
        public void CreateRegisterAnswer()
        {
            RegisterAnswer a = new RegisterAnswer { nameId = 1, questionId = 1, answerId= 1 };

            var x = registerAnswerController.RegisterAnswer(1, a) as CreatedNegotiatedContentResult<RegisterAnswer>;

            Assert.AreEqual(a.answerId, x.Content.answerId);
        }













        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            questionController = new QuestionController();
            quizController = new QuizController();
            personController = new PersonController();
            registerAnswerController = new RegisterAnswerController();
            answerController = new AnswerController();

            repository = new TestQuizRepository();
            questionController.QuizRepository = repository;
            quizController.QuizRepository = repository;
            answerController.QuizRepository = repository;
            registerAnswerController.QuizRepository = repository;
            personController.QuizRepository = repository;
        }

        TestQuizRepository repository;
        QuestionController questionController;
        QuizController quizController;
        PersonController personController;
        AnswerController answerController;
        RegisterAnswerController registerAnswerController;
    }
}
