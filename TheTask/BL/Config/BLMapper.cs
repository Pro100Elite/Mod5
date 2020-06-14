using AutoMapper;
using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Config
{
    public class BLMapper : Profile
    {
        public BLMapper()
        {
            CreateMap<DEPT, DeptBL>().ReverseMap();
            CreateMap<EMP, EmpBL>();
            CreateMap<EmpBL, EMP>().ForMember(dest => dest.DEPT, opt => opt.Ignore());
            CreateMap<SALGRADE, SalGradeBL>().ReverseMap();
        }
    }
}
