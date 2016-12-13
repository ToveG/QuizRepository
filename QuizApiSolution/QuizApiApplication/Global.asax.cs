using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace QuizApiApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            InitializeAutoMapper();
        }

        public static void InitializeAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Answer, Models.Answer>();
                cfg.CreateMap<Models.Answer, Entities.Answer>();
                cfg.CreateMap<Entities.Quiz, Models.Quiz>();
                cfg.CreateMap<Models.Quiz, Entities.Quiz>();
                cfg.CreateMap<Entities.Question, Models.Question>();
                cfg.CreateMap<Models.Question, Entities.Question>();
                cfg.CreateMap<Entities.Person, Models.Person>();
                cfg.CreateMap<Models.Person, Entities.Person>();
                cfg.CreateMap<Models.RegisterAnswer, Entities.AnswerRegister>();
                cfg.CreateMap<Entities.AnswerRegister, Models.RegisterAnswer    >();
            });
        }
    }
}
