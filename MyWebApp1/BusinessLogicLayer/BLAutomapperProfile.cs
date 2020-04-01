using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<ArticleModel, Article>().ReverseMap();
        }
    }
}
