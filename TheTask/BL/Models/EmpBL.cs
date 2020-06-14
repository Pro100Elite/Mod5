using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class EmpBL
    {
        public decimal EMPNO { get; set; }
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public Nullable<decimal> MGR { get; set; }
        public Nullable<System.DateTime> HIREDATE { get; set; }
        public Nullable<decimal> SAL { get; set; }
        public Nullable<decimal> COMM { get; set; }
        public Nullable<decimal> DEPTNO { get; set; }
        public int SALGRADE { get; set; }

        public DeptBL DEPT { get; set; }
    }
}
