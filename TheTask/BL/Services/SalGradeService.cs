using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SalGradeService : GenericService<SalGradeBL, SALGRADE>, ISalGradeService
    {
        public SalGradeService(IGenericRepository<SALGRADE> repository, IMapper mapper):
            base(repository, mapper)
        {

        }
    }
}
