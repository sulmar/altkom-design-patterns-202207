using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatePattern.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Confirm_CreatedOrder_ShouldCompletion()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.Confirm();

            // Assert
            Assert.AreEqual(OrderStatus.Completion, order.Status);

        }

        [TestMethod]
        public void Confirm_CompletionOrder_ShouldSent()
        {
            // Arrange
            Order order = new Order();
            order.Confirm();

            // Act
            order.Confirm();

            // Assert
            Assert.AreEqual(OrderStatus.Sent, order.Status);

        }

        [TestMethod]
        public void Confirm_SentOrder_ShouldDone()
        {
            // Arrange
            Order order = new Order();
            order.Confirm();
            order.Confirm();

            // Act
            order.Confirm();

            // Assert
            Assert.AreEqual(OrderStatus.Done, order.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cancel_DoneOrder_ShouldDone()
        {
            // Arrange
            Order order = new Order(OrderStatus.Done);

            // Act
            order.Cancel();

            // Assert
            
        }

    }
}
