using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTask.Models
{
    public class EmpHierarchyPL
    {
        public EmpPL Emp { get; set; }
        public IEnumerable<EmpHierarchyPL> Subordinates { get; set; }
    }
}