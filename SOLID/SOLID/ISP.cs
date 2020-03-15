using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class ISP
    {
        public interface IEmployee
        {
            bool AddDetailsEmployee();
            bool ShowDetailsEmployee(int id);
        }
        //решение

        public interface IOperationAdd
        {
            bool AddDetailsEmployee();
        }

        public interface IOperationGet
        {
            bool ShowDetailsEmployee(int id);
        }
    }
}
