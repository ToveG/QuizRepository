using AutoMapper;
using QuizApiApplication.Entities;
using QuizApiApplication.Models;
using QuizApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApiApplication.Controllers
{
    public class PersonController : ApiController
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
        [Route("api/person")]
        public IHttpActionResult Get()
        {
            var allPersons = QuizRepository.GetAllPersons();
            if(allPersons == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<IEnumerable<Models.Person>>(allPersons));
        }

        [Route("api/person/{id}")]
        public IHttpActionResult GetSpecificPerson(int id)
        {
            var selectedPerson = QuizRepository.GetPersonById(id);
            if (selectedPerson == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Models.Person>(selectedPerson));
        }

        [Route("api/person")]
        [HttpPost]
        public IHttpActionResult CreatePerson(
            [FromBody] CreatePerson person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personToInsert = new Entities.Person()
            {
                Name = person.Name
            };

            var p = QuizRepository.CreatePerson(personToInsert);

            return Created("Created", Mapper.Map<Models.Person>(p));
        }



    }
}
