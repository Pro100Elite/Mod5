using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using BL;
using BL.Interfaces;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp2
{
    public class WebAutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new WebMapper(), new BLMapper()}));
            builder.Register(c => config.CreateMapper());

            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();

            builder.RegisterModule<BLAutofacConfig>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}