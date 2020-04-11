using Autofac;
using Autofac.Integration.Mvc;
using BL.Interfaces;
using BL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL
{
    public class BLAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyContext>().As<IMyContext>();

            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
        }
    }
}
