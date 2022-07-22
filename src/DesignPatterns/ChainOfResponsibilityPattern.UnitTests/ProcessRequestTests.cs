using ChainOfResponsibilityPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainOfResponsibilityPattern.UnitTests
{
    [TestClass]
    public class ProcessRequestTests
    {
        private Approver manager;
        private Approver director;
        private Approver ceo;

        [TestInitialize]
        public void Init()
        {            
            manager = new ProductManager();
            director = new Director();
            ceo = new CEO();

            manager.SetSuccessor(director);
            director.SetSuccessor(ceo);
        }


        [TestMethod]
        public void ProcessRequest_AmountBelow999_ShouldApprovedByManager()
        {            
            // Arrange
            Purchase purchase = new Purchase(999, "Book Design Pattern in C#");

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.AreSame(manager, purchase.ApprovedBy);
        }

        [TestMethod]
        public void ProcessRequest_AmountBelow4999_ShouldApprovedByDirector()
        {
            // Arrange
            Purchase purchase = new Purchase(4999, "Book Design Pattern in C#");

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.AreSame(director, purchase.ApprovedBy);
        }

        [TestMethod]
        public void ProcessRequest_AmountBelow10000_ShouldApprovedByCEO()
        {
            // Arrange
            Purchase purchase = new Purchase(9999, "Book Design Pattern in C#");

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.AreSame(ceo, purchase.ApprovedBy);
        }

        [TestMethod]
        public void ProcessRequest_AmountAbove10000_ShouldApprovedByEmpty()
        {
            // Arrange
            Purchase purchase = new Purchase(10001, "Book Design Pattern in C#");

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.IsNull(purchase.ApprovedBy);
        }
    }
}
