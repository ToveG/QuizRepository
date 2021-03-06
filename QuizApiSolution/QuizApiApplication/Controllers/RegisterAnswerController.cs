﻿using AutoMapper;
using QuizApiApplication.Entities;
using QuizApiApplication.Models;
using QuizApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class RegisterAnswerController : ApiController
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

        [Route("api/regiser/quiz/{quizid}")]
        [HttpPost]
        public IHttpActionResult RegisterAnswer(int quizId,
            [FromBody] RegisterAnswer regAnswer)
        {
             var quiz = QuizRepository.GetQuizById(quizId);
             if(quiz == null)
            {
                return NotFound();
            }

            var questionCount = quiz.Questions.Count();
            var amountOfAnswerdQuestions = regAnswer.selectedAnswerPerQuestion.Count();
            if(amountOfAnswerdQuestions < questionCount)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }

            var person = QuizRepository.GetPersonById(regAnswer.nameId);
     
            foreach (var a in regAnswer.selectedAnswerPerQuestion)
            {
                var question = quiz.Questions.SingleOrDefault(q => q.Id == a.questionId);
                if (question == null)
                {
                    return NotFound();
                }
                var selectedQuestion = QuizRepository.GetQuestionById(question.Id);
                if (selectedQuestion == null)
                {
                    return NotFound();
                }
                var answer = selectedQuestion.Answers.SingleOrDefault(d => d.Id == a.answerId);
                if (answer == null)
                {
                    return NotFound();
                }

                AnswerRegister answerRegister = new AnswerRegister()
                {
                    Question = question,
                    Person = person,
                    Quiz = quiz,
                    AnsweredDate = DateTime.Now.ToString("yyyyMMdd"),
                    Answered = true,
                    Answer = answer

                };
                var _item = QuizRepository.CreateRegisterAnswer(answerRegister);
            }

            return Ok();
        }

        [Route("api/registerAnswer/{quizid}")]
        public IHttpActionResult GetRegisterAnswerByQuizId(int quizId)
        {
            var quiz = QuizRepository.GetQuizById(quizId);
            List<ViewQuizResultModel> listView = new List<ViewQuizResultModel>();
            if(quiz == null)
            {
                return NotFound();
            }
            try
            {
                listView = GetResultForSpecificQuiz(quiz);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(listView);
        }

        [Route("api/registerAnswer/quiz/{quizid}/person/{personid}")]
        public IHttpActionResult GetRegisterAnswerForPersonById(int quizId, int personId)
        {
            var quiz = QuizRepository.GetQuizById(quizId);
            if(quiz == null)
            {
                return NotFound();
            }

            var person = QuizRepository.GetPersonById(personId);
            if(person == null)
            {
                return NotFound();
            }

            var q = QuizRepository.GetRegisterdQuizByPersonId(quizId, personId);
            if(q == null)
            {
                return NotFound();
            }
            List<Entities.Question> questionList = new List<Entities.Question>();
            List<Entities.Answer> answerList = new List<Entities.Answer>();
            ViewRegistredQuizForSpecificPersonModel viewModel = new ViewRegistredQuizForSpecificPersonModel();
            viewModel.AnsweredBy = person.Name;
            viewModel.QuizName = quiz.Name;

            foreach(var item in q)
            {
                viewModel.AnsweredDate = item.AnsweredDate;
                questionList.Add(item.Question);
                answerList.Add(item.Answer);
            }
            viewModel.question = Mapper.Map<List<Models.Question>>(questionList);
            return Ok(viewModel);
        }

        public List<ViewQuizResultModel> GetResultForSpecificQuiz(Entities.Quiz q)
        {
            var allQuizAnswers = QuizRepository.GetAllRegisterdQuiz(q);
            if (allQuizAnswers == null)
            {
                throw new Exception();
            }

            var groupByPerson = allQuizAnswers.GroupBy(a => a.Person).
               Select(group =>
               new
               {
                   Name = group.Key,
               }).ToArray();

            List<ViewQuizResultModel> myList = new List<ViewQuizResultModel>();
            foreach (var name in groupByPerson)
            {
                var g = allQuizAnswers.FirstOrDefault(a => a.AnsweredDate != null && a.Person == name.Name);
                ViewQuizResultModel vqrm = new ViewQuizResultModel();
                vqrm.AnsweredBy = name.Name.Name;
                vqrm.QuizName = q.Name;
                vqrm.AnsweredDate = g.AnsweredDate;
                
                myList.Add(vqrm);
            }
            return myList;
        }

        [Route("api/report/quiz/{quizid}")]
        public IHttpActionResult GetReportForSpecificQuiz(int quizId)
        {
            var quiz = QuizRepository.GetQuizById(quizId);
            if (quiz == null)
            {
                return NotFound();
            }

            var results = QuizRepository.GetQuizReportById(quizId);
            if (results == null)
            {
                return NotFound();
            }

            var correctAnswers = results.Where(a => a.Answer.CorrectAnswer).Count();
            var personCount = results.GroupBy(a => a.Person).Count();
            decimal average = 0;
            if (personCount > 0)
            {
                average = (decimal)correctAnswers / personCount;
            }
            
            ReportViewModel report = new ReportViewModel();
            report.AmountOfAnswers = personCount;
            report.MaximumScoore = quiz.Questions.Count();
            report.QuizName = quiz.Name;
            report.AverageScoore = average;

            return Ok(report);
        }
      }
    }

