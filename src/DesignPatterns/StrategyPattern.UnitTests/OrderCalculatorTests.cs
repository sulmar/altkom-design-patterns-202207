using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrategyPattern.UnitTests
{
    [TestClass]
    public class OrderCalculatorTests
    {
        [TestMethod]
        public void CalculateDiscount_PercentageHappyHours_ShouldDiscount()
        {
            // Arrange
            ICanDiscountStrategy canDiscountStrategy = new HappyHoursDiscountStrategy(TimeSpan.Parse("09:00"), TimeSpan.Parse("15:00"));
            ICalculateDiscountStrategy calculateDiscountStrategy = new PercentageCalculateDiscountStrategy(0.1m);

            OrderCalculator orderCalculator = new OrderCalculator(canDiscountStrategy, calculateDiscountStrategy);

            Order order = new Order(DateTime.Parse("2020-06-12 14:59"), new Customer(), 100);

            // Act
            var discount = orderCalculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(10, discount);
        }
    }
}
