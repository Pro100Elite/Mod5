using Autofac;
using DAL;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLAutofacConfig: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyContext>().As<IMyContext>();

            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<UserDataRepository>().As<IUserDataRepository>();
            //builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
        }
    }
}
