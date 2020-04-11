using AutoMapper;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp2.Models;

namespace WebApp2
{
    public class WebMapper : Profile
    {
        public WebMapper()
        {
            CreateMap<AuthorModel, AuthorViewModel>();
            CreateMap<ArticleModel, ArticleViewModel>();
        }
    }
}