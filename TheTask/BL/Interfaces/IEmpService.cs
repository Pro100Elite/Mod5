using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Services.EmpService;

namespace BL.Interfaces
{
    public interface IEmpService : IGenericService<EmpBL>
    {
        IEnumerable<EmpHierarchy> GetEmpHierarchy(IEnumerable<SalGradeBL> salGradeBL);
        IEnumerable<EmpBL> Get(IEnumerable<SalGradeBL> salGradeBL);
    }
}
