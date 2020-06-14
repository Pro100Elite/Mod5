using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class EmpService: GenericService<EmpBL, EMP>, IEmpService
    {
        public EmpService(IGenericRepository<EMP> repository, IMapper mapper):
            base(repository, mapper)
        {

        }

        public IEnumerable<EmpHierarchy> GetEmpHierarchy()
        {
            ICollection<EmpHierarchy> hierarchy = new List<EmpHierarchy>();

            var entities = _repository.Get();
            var allEmp = _mapper.Map<IEnumerable<EmpBL>>(entities);
            var presidents = allEmp.Where(x => x.MGR == null);

            foreach (var president in presidents)
            {
                var pres = new EmpHierarchy();

                pres.Emp = president;
                pres.Subordinates = GetHierarchyForEmp(allEmp, president);

                hierarchy.Add(pres);
            }

            return hierarchy;
        }

        private IEnumerable<EmpHierarchy> GetHierarchyForEmp(IEnumerable<EmpBL> allEmp, EmpBL parentEmp)
        {            
            decimal? parentEmpNo = null;

            if (parentEmp != null)
                parentEmpNo = parentEmp.EMPNO;

            var childEmp = allEmp.Where(emp => emp.MGR == parentEmpNo);

            ICollection<EmpHierarchy> hierarchy = new List<EmpHierarchy>();

            foreach (var emp in childEmp)
            {
                EmpHierarchy EmpHierarchy = new EmpHierarchy();
                EmpHierarchy.Emp = emp;
                EmpHierarchy.Subordinates = GetHierarchyForEmp(allEmp, emp);
                hierarchy.Add(EmpHierarchy);
            }

            return hierarchy;
        }
    }
}
