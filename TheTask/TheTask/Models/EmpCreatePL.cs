using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheTask.Models
{
    public class EmpCreatePL
    {
        [Required(ErrorMessage = "Input EMPNO")]
        public decimal EMPNO { get; set; }
        [Required(ErrorMessage = "Input ENAME")]
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public Nullable<decimal> MGR { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> HIREDATE { get; set; }
        [Required(ErrorMessage = "Input SAL")]
        public Nullable<decimal> SAL { get; set; }
        public Nullable<decimal> COMM { get; set; }
        public Nullable<decimal> DEPTNO { get; set; }
        public string DEPTNAME { get; set; }
        public int SALGRADE { get; set; }

        public IEnumerable<SelectListItem> ListDept { get; set; }
        public IEnumerable<SelectListItem> ListMgr { get; set; }
        public IEnumerable<SelectListItem> ListJob { get; set; }
    }
}