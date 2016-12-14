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
        public void GetAllQuestions_ShouldReturn2Questions()
        {
            var questions = questionController.Get() as OkNegotiatedContentResult<IEnumerable<Question>>;
            Assert.AreEqual(2, new List<Question>(questions.Content).Count);    
        }

        [TestMethod]
        public void GetAllQuiz_ShouldReturn2Quiz()
        {
            var quiz = quizController.Get() as OkNegotiatedContentResult<List<ViewQuiz>>;
            Assert.AreEqual(2, new List<ViewQuiz>(quiz.Content).Count);
        }

        [TestMethod]
        public void GetAllPersons_ShouldReturn2Person()
        {
            var persons = personController.Get() as OkNegotiatedContentResult<IEnumerable<Models.Person>>;
            Assert.AreEqual(2, new List<Models.Person>(persons.Content).Count);
        }

        [TestMethod]
        public void CreatePersons_ShouldReturnCorrectPerson()
        {
            CreatePerson p = new CreatePerson { Name = "test" };

            var x = personController.CreatePerson(p) as CreatedNegotiatedContentResult<Person>;

            Assert.AreEqual(p.Name, x.Content.Name);
        }

        [TestMethod]
        public void CreateQuiz_ShouldReturnCorrectQuiz()
        {
            CreateQuiz q = new CreateQuiz { Name = "test" };

            var x = quizController.CreateQuiz(q) as CreatedNegotiatedContentResult<Quiz>;

            Assert.AreEqual(q.Name, x.Content.Name);
        }

        [TestMethod]
        public void CreateQuestion_ShouldReturnCorrectQuestion()
        {
            List<CreateAnswer> list = new List<Models.CreateAnswer>();
            CreateAnswer a = new Models.CreateAnswer { AnswerAlternative = "test", CorrectAnswer = true };
            list.Add(a);
            CreateQuestion q = new CreateQuestion { Title = "test", Answers = list };

            var x = questionController.CreateQuestion(1,q) as CreatedNegotiatedContentResult<Question>;

            Assert.AreEqual(q.Title, x.Content.QuestionTitle);
        }

        [TestMethod]
        public void CreateAnswer_ShouldReturnCorrectAnswer()
        {
            List<CreateAnswer> list = new List<Models.CreateAnswer>();
            CreateAnswer a = new Models.CreateAnswer { AnswerAlternative = "test", CorrectAnswer = true };
            list.Add(a);
            CreateQuestion q = new CreateQuestion { Title="test", Answers= list };

           var x = questionController.CreateQuestion(1, q) as CreatedNegotiatedContentResult<Question>;

            Assert.AreEqual(true, x.Content.QuestionTitle == "test");
        }

        [TestMethod]
        public void GetSpecificQuestion_ShouldReturnQuestionWithId1()
        {
            var x = questionController.GetSpecificQuestion(1) as OkNegotiatedContentResult<Question>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestMethod]
        public void GetSpecificQuiz_ShouldReturnCorrectQuiz()
        {
            //            CreateQuiz q = new CreateQuiz { Name = "test" };
            var name = "test"; 
            var x = quizController.GetSpecificQuiz(1) as OkNegotiatedContentResult<Quiz>;

            Assert.AreEqual(name, x.Content.Name);
        }

        [TestMethod]
        public void GetSpecificPerson_ShouldReturnPersonWithId1()
        {
            var x = personController.GetSpecificPerson(1) as OkNegotiatedContentResult<Person>;

            Assert.AreEqual(1, x.Content.Id);
        }

        [TestMethod]
        public void CreateRegisterAnswer_ShouldReturnTypeOfOkResult()
        {
            SelectedOption so = new SelectedOption { questionId = 1, answerId = 1 };
            List<SelectedOption> list_so = new List<SelectedOption>();
            list_so.Add(so);
            RegisterAnswer a = new RegisterAnswer { nameId = 1,  selectedAnswerPerQuestion = list_so};

            var x = registerAnswerController.RegisterAnswer(1, a) as OkResult;
            Assert.IsInstanceOfType(x, typeof(OkResult));
        }

        [TestMethod]
        public void GetRegisterAnswerByQuizId_GetObjectAnswerdByAnna()
        {
            ViewQuizResultModel vq = new ViewQuizResultModel() {AnsweredBy= "Anna" };
            var answer = registerAnswerController.GetRegisterAnswerByQuizId(1) as OkNegotiatedContentResult<List<ViewQuizResultModel>>;

            Assert.AreEqual(vq.AnsweredBy, answer.Content[0].AnsweredBy );
        }

        [TestMethod]
        public void GetRegisterAnswerForPersonById()
        {
            Person p = new Person() { Id = 1 , Name = "Anna"};
            var a = registerAnswerController.GetRegisterAnswerForPersonById(1, 1) as OkNegotiatedContentResult<ViewRegistredQuizForSpecificPersonModel>;
            Assert.AreEqual(p.Name, a.Content.AnsweredBy);
        }

        [TestMethod]
        public void GetReportForSpecificQuiz_ShouldReturn1amountOfAnswers()
        {
            ReportViewModel rvm = new ReportViewModel() { AmountOfAnswers = 1 };
            var x = registerAnswerController.GetReportForSpecificQuiz(1) as OkNegotiatedContentResult<ReportViewModel>;
            Assert.AreEqual(x.Content.AmountOfAnswers, rvm.AmountOfAnswers);
        }










        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            questionController = new QuestionController();
            quizController = new QuizController();
            personController = new PersonController();
            registerAnswerController = new RegisterAnswerController();

            repository = new TestQuizRepository();
            questionController.QuizRepository = repository;
            quizController.QuizRepository = repository;
            registerAnswerController.QuizRepository = repository;
            personController.QuizRepository = repository;
        }

        TestQuizRepository repository;
        QuestionController questionController;
        QuizController quizController;
        PersonController personController;
        RegisterAnswerController registerAnswerController;
    }
}
