using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Factories;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.ApplicationCore.Services;
using TtopAcademy.API.Infrastructure.Factories.Real;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Real;
using TtopAcademy.API.Infrastructure.Services.Fakes;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().SingleInstance();

            builder.RegisterType<OtpManager>().As<IOtpManager>().SingleInstance();  
            builder.RegisterType<SubjectManager>().As<ISubjectManager>().SingleInstance();
            builder.RegisterType<TopicManager>().As<ITopicManager>().SingleInstance(); 
            builder.RegisterType<VideoManager>().As<IVideoManager>().SingleInstance();  
            builder.RegisterType<PracticeQuestionManager>().As<IPracticeQuestionManager>().SingleInstance(); 

            builder.RegisterType<FakeEmailService>().As<IEmailService>().SingleInstance(); 

            builder.RegisterType<PracticeQuestionFactory>().As<IPracticeQuestionFactory>().SingleInstance(); 

            builder.RegisterType<FakeOtpRepository>().As<IOtpRepository>().SingleInstance(); 
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<CategorySubjectRepository>().As<ICategorySubjectRepository>().SingleInstance();
            builder.RegisterType<CategorySubjectTopicRepository>().As<ICategorySubjectTopicRepository>().SingleInstance();
            builder.RegisterType<CategorySubjectTopicVideoRepository>().As<ICategorySubjectTopicVideoRepository>().SingleInstance();
            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>().SingleInstance();
            builder.RegisterType<TopicRepository>().As<ITopicRepository>().SingleInstance();
            builder.RegisterType<VideoRepository>().As<IVideoRepository>().SingleInstance();
            
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}