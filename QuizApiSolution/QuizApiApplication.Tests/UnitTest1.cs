using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApiApplication.Controllers;
using System.Web.Http;
using QuizApiApplication.Entities;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace QuizApiApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllQuestions()
        {
            var questions = questionController.Get() as OkNegotiatedContentResult<IEnumerable<Question>>;
            Assert.IsNull(questions);    
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            WebApiApplication.InitializeAutoMapper();
            questionController = new QuestionController();

            repository = new TestQuizRepository();
            questionController.QuizRepository = repository;
        }

        TestQuizRepository repository;
        QuestionController questionController;
    }
}
