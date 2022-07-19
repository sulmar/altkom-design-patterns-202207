using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DecoratorPattern.UnitTests
{
    [TestClass]
    public class SalaryTests
    {

        [TestMethod]
        public void CalculateSalary_Junior_ShouldCalculateBonus()
        {
            // Arrange            

            Employee employee = new JuniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2), NumberOfProjects = 1};

            Salary salary = new JuniorSalary();

            salary = new OvertimeSalaryDecorator(salary, 50, employee.OvertimeSalary);
            salary = new ProjectSalaryDecorator(salary, 1000, employee.NumberOfProjects);
            
            // Act
            var result = salary.GetSalary();

            // Assert
            Assert.AreEqual(2100, result);
        }

        [TestMethod]
        public void CalculateSalary_Senior_ShouldCalculateBonus()
        {
            // Arrange
            Employee employee = new SeniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2), NumberOfProjects = 2 };

            Salary salary = new SeniorSalary();

            salary = new OvertimeSalaryDecorator(salary, 50, employee.OvertimeSalary);
            salary = new ProjectSalaryDecorator(salary, 1000, employee.NumberOfProjects);

            // Act
            var result = salary.GetSalary();

            // Assert
            Assert.AreEqual(4100, result);
        }
    }
}
