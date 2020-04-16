using ApiWebAppl2.Models;
using AutoMapper;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebAppl2
{
    public class WebMapperApi : Profile
    {
        public WebMapperApi()
        {
            CreateMap<AuthorModel, AuthorApi>().ReverseMap();
            CreateMap<ArticleModel, ArticleApi>().ReverseMap();
        }
    }
}