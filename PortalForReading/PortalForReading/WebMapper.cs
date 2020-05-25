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

            CreateMap<ArticleModel, ArticleView>().ForMember(dest => dest.Categories, 
                opt => opt.MapFrom(src => src.ArticleCategories.Select(c => c.Category))).ReverseMap();

            CreateMap<ArticleModel, ArticleCreateView>().ForMember(dest => dest.Categories, 
                opt => opt.MapFrom(src => src.ArticleCategories.Select(c => c.Category))).ReverseMap();

            CreateMap<ArticleModel, ArticleEditorView>().ReverseMap();
            CreateMap<ArticleReadModel, ArticleBookView>().ReverseMap();
            CreateMap<ArticleModel, ArticleBookView>().ReverseMap();
            CreateMap<CategoryModel, CategoryView>().ReverseMap();

        }
    }
}