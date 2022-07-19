using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Kalkulator płacowy 
    // Premia za nadgodziny
    // Premia za oddanie każdego projektu
    // Premia za udział w szkoleniu ;-)

    public class SalaryCalculator
    {
        private readonly decimal amountPerHour;
        private readonly decimal bonusPerProject;

        public SalaryCalculator(decimal amountPerHour, decimal bonusPerProject)
        {
            this.amountPerHour = amountPerHour;
            this.bonusPerProject = bonusPerProject;
        }

        public decimal CalculateSalary(Employee employee)
        {
            // pensja zasadnicza
            var salary = new JuniorSalary();

            var amount = salary.GetSalary();

            // premia za nadgodziny (overtime)
            amount += (decimal) employee.OvertimeSalary.TotalHours * amountPerHour;

            // premia za oddanie każdego projektu
            for (int i = 0; i < employee.NumberOfProjects; i++)
            {
                amount += bonusPerProject;
            }

            // premia za udział w szkoleniu
            // etc. ...

            return amount;           
           
        }
    }

}
