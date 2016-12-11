using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using QuizApplication.Dto;

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
                cfg.CreateMap<Entities.Question, Question>();
                cfg.CreateMap<Question, Entities.Question>();
                cfg.CreateMap<Entities.Answer, Answer>();
                cfg.CreateMap<Answer, Entities.Answer>();
            });
        }
    }
}
