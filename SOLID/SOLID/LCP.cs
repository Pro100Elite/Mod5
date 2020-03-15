using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class LCP
    {
        public abstract class Employee
        {
            public virtual string GetWorkDetails(int id)
            {
                return "Base Work";
            }

            public virtual string GetEmployeeDetails(int id)
            {
                return "Base Employee";
            }
        }
        public class SeniorEmployee : Employee
        {
            public override string GetWorkDetails(int id)
            {
                return "Senior Work";
            }

            public override string GetEmployeeDetails(int id)
            {
                return "Senior Employee";
            }
        }
        public class JuniorEmployee : Employee
        {
            // Допустим, для Junior’a отсутствует информация
            public override string GetWorkDetails(int id)
            {
                throw new NotImplementedException();
            }
            public override string GetEmployeeDetails(int id)
            {
                return "Junior Employee";

            }
        }
        //решение

        public interface IEmployee1
        {
            string GetEmployeeDetails(int employeeId);
        }

        public interface IWork1
        {
            string GetWorkDetails(int employeeId);
        }
        public class SeniorEmployee1 : IWork1, IEmployee1
        {
            public string GetWorkDetails(int employeeId)
            {
                return "Senior Work";
            }

            public string GetEmployeeDetails(int employeeId)
            {
                return "Senior Employee";
            }
        }
        public class JuniorEmployee1 : IEmployee1
        {
            public string GetEmployeeDetails(int employeeId)
            {
                return "Junior Employee";
            }
        }
    }
}
