using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DeptService:GenericService<DeptBL, DEPT>, IDeptService 
    {
        public DeptService(IGenericRepository<DEPT> repository, IMapper mapper): 
            base(repository, mapper) 
        { 

        }      
    }
}
