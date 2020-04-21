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
            //CreateMap<AuthorModel, AuthorViewModel>().ReverseMap();
            CreateMap<ArticleModel, ArticleView>().ReverseMap();
        }
    }
}