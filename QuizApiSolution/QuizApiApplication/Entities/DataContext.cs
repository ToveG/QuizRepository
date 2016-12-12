using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApiApplication.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<AnswerRegister> AnswerRegister { get; set; }

        public DbSet<Quiz> Quiz { get; set; }

        public DataContext()
            : base("name = Quiz")
        {

        }

    }
}