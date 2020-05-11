using AutoMapper;
using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLMapper : Profile
    {
        public BLMapper()
        {
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<UserData, UserDataModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
