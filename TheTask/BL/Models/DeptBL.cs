using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class DeptBL
    {
        public decimal DEPTNO { get; set; }
        public string DNAME { get; set; }
        public string LOC { get; set; }

        public ICollection<EmpBL> EMPs { get; set; }
    }
}
