using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class EmpHierarchy
    {
        public EmpBL Emp { get; set; }
        public IEnumerable<EmpHierarchy> Subordinates { get; set; }
    }
}
