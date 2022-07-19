using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Abstract decorator
    public abstract class SalaryDecorator : Employee
    {
        protected Employee employee;

        public SalaryDecorator(Employee employee)
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
    public class OvertimeSalaryDecorator : SalaryDecorator
    {
        private readonly decimal amountPerHour;

        public OvertimeSalaryDecorator(Employee employee, decimal amountPerHour) : base(employee)
        {
            this.amountPerHour = amountPerHour;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal) employee.OvertimeSalary.TotalHours * amountPerHour; 
        }
    }

    // Concrete decorator
    public class ProjectSalaryDecorator : SalaryDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectSalaryDecorator(Employee employee, decimal bonusPerProject) : base(employee)
        {
            this.bonusPerProject = bonusPerProject;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + bonusPerProject * employee.NumberOfProjects;
        }
    }
}
