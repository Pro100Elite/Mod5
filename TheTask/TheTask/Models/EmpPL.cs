using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTask.Models
{
    public class EmpPL
    {
        public decimal EMPNO { get; set; }
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public Nullable<decimal> MGR { get; set; }
        public Nullable<System.DateTime> HIREDATE { get; set; }
        public Nullable<decimal> SAL { get; set; }
        public Nullable<decimal> COMM { get; set; }
        public Nullable<decimal> DEPTNO { get; set; }
        public string DEPTNAME { get; set; }
    }
}