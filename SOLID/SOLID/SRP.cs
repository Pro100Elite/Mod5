using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class SRP
    {
        // S

        public class Employee
        {
            public int ID { get; set; }
            public string FullName { get; set; }

            public bool Add(Employee emp)
            {
                // Вставить данные сотрудника в таблицу БД
                return true;
            }
            /// Отчет по сотруднику
            public void GenerateReport(Employee em)
            {
                // Генерация отчета по деятельности сотрудника
            }
        }

        // Решение 
        public class Employee1
        {
            public int ID { get; set; }
            public string FullName { get; set; }

            /// <summary>
            /// Данный метод добавляет в БД нового сотрудника
            /// </summary>
            /// <param name="em">Объект для вставки</param>
            /// <returns>Результат вставки новых данных</returns>
            public bool Add(Employee1 emp)
            {
                // Вставить данные сотрудника в таблицу БД
                return true;
            }
        }

        public class EmployeeReport
        {
            /// <summary>
            /// Отчет по сотруднику
            /// </summary>
            public void GenerateReport(Employee1 em)
            {
                // Генерация отчета по деятельности сотрудника
            }
        }
    }
}
