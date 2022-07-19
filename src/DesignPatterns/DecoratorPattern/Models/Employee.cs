using System;

namespace DecoratorPattern
{
    // Abstract component
    public abstract class Employee
    {
        public TimeSpan OvertimeSalary { get; set; }
        public int NumberOfProjects { get; set; }
    
    }

    // Abstract component
    public abstract class Salary
    {
        public abstract decimal GetSalary();
    }

    // Concrete component
    public class JuniorSalary : Salary
    {
        public override decimal GetSalary() => 1000m;
    }

    public class SeniorSalary : Salary
    {
        public override decimal GetSalary() => 2000m;
    }

    public abstract class SalaryDecorator : Salary
    {
        private readonly Salary salary;

        protected SalaryDecorator(Salary salary)
        {
            this.salary = salary;
        }

        public override decimal GetSalary()
        {
            return salary.GetSalary();
        }
    }

    public class OvertimeSalaryDecorator : SalaryDecorator
    {
        private readonly decimal amountPerHour;
        private readonly TimeSpan overtime;

        public OvertimeSalaryDecorator(Salary salary, decimal amountPerHour, TimeSpan overtime) : base(salary)
        {
            this.amountPerHour = amountPerHour;
            this.overtime = overtime;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal) overtime.TotalHours * amountPerHour;
        }
    }

    public class ProjectSalaryDecorator : SalaryDecorator
    {
        private readonly decimal bonusPerProject;
        private readonly int numberOfProjects;

        public ProjectSalaryDecorator(Salary salary, decimal bonusPerProject, int numberOfProjects) : base(salary)
        {
            this.bonusPerProject = bonusPerProject;
            this.numberOfProjects = numberOfProjects;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + bonusPerProject * numberOfProjects;
        }
    }
}
