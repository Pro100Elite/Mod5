using AutoMapper;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp2.Models;

namespace WebApp2
{
    public abstract class WebMapper
    {
       public WebMapper()
       {
            var config = new MapperConfiguration(con =>
            {
                con.CreateMap<AuthorModel, AuthorViewModel>();
                con.CreateMap<ArticleModel, ArticleViewModel>();
            });

            var mapper = new Mapper(config);
       }

        public abstract AuthorViewModel Map(ArticleModel articleModel);
        public abstract ArticleModel ReMap(ArticleViewModel articleViewModel);

        public abstract List<AuthorViewModel> Map(List<ArticleModel> articleModel);
        public abstract List<ArticleModel> ReMap(List<ArticleViewModel> articleViewModel);
    }
}