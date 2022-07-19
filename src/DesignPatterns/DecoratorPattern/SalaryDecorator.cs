using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Abstract decorator
    public abstract class SalaryEmployeeDecorator : Employee
    {
        protected Employee employee;

        public SalaryEmployeeDecorator(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            this.employee = employee;
        }

        public override decimal GetSalary()
        {            
            return employee.GetSalary();
            
        }
    }

    // Concrete decorator
    public class OvertimeSalaryEmployeeDecorator : SalaryEmployeeDecorator
    {
        private readonly decimal amountPerHour;

        public OvertimeSalaryEmployeeDecorator(Employee employee, decimal amountPerHour) : base(employee)
        {
            this.amountPerHour = amountPerHour;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal) employee.OvertimeSalary.TotalHours * amountPerHour; 
        }
    }

    // Concrete decorator
    public class ProjectSalaryEmployeeDecorator : SalaryEmployeeDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectSalaryEmployeeDecorator(Employee employee, decimal bonusPerProject) : base(employee)
        {
            this.bonusPerProject = bonusPerProject;
        }

        public override decimal GetSalary()
        {            
            return base.GetSalary() + bonusPerProject * employee.NumberOfProjects;
        }
    }
}
