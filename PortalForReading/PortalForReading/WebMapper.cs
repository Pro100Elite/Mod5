using AutoMapper;
using BL.Models;
using PortalForReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalForReading
{
    public class WebMapper : Profile
    {
        public WebMapper()
        {
            CreateMap<AuthorModel, AuthorView>().ReverseMap();
            CreateMap<ArticleModel, ArticleView>().ReverseMap();
            CreateMap<ArticleModel, ArticleCreateView>().ReverseMap();
            CreateMap<ArticleModel, ArticleBookView>().ReverseMap();
            CreateMap<CategoryModel, CategoryView>().ReverseMap();

        }
    }
}