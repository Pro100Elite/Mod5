using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SOLID.SRP;

namespace SOLID
{
    class OCP
    {
        public class EmployeeReport
        {
            public string TypeReport { get; set; }

            public void GenerateReport(Employee em)
            {
                if (TypeReport == "CSV")
                {
                    // Генерация отчета в формате CSV
                }

                if (TypeReport == "PDF")
                {
                    // Генерация отчета в формате PDF
                }
            }
        }
        // решение

        public class IEmployeeReport
        {
            /// Метод для создания отчета
            public virtual void GenerateReport(Employee em)
            {
                // Базовая реализация, которую нельзя модифицировать
            }
        }
        public class EmployeeCSVReport : IEmployeeReport
        {
            public override void GenerateReport(Employee em)
            {
                // Генерация отчета в формате CSV
            }
        }
        public class EmployeePDFReport : IEmployeeReport
        {
            public override void GenerateReport(Employee em)
            {
                // Генерация отчета в формате PDF
            }
        }
    }
}
