using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BuilderPattern.UnitTests
{
    [TestClass]
    public class SalesReportBuilderTests
    {
        private ISalesReportBuilder salesReportBuilder;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            FakeOrdersService ordersService = new FakeOrdersService();
            var orders = ordersService.Get();

            salesReportBuilder = new SalesReportBuilder(orders);
        }

        [TestMethod]
        public void Build_WithHeaderAndGenderAndProductSections_ShouldReturnsSalesReport()
        {
            // Arrange                        
            salesReportBuilder.AddHeader("Raport sprzeda퓓");
            salesReportBuilder.AddGenderSection();
            salesReportBuilder.AddProductSection();

            // Act
            SalesReport salesReport = salesReportBuilder.Build();

            // Assert
            Assert.IsNotNull(salesReport);
            Assert.AreEqual("Raport sprzeda퓓", salesReport.Title);
            Assert.IsNotNull(salesReport.GenderDetails);
            Assert.IsNotNull(salesReport.ProductDetails);
            Assert.AreEqual(2, salesReport.GenderDetails.Count());
            Assert.AreEqual(3, salesReport.ProductDetails.Count());
        }

        [TestMethod]
        public void Build_WithHeaderAndGenderSection_ShouldReturnsSalesReport()
        {
            // Arrange
            salesReportBuilder.AddHeader("Raport sprzeda퓓");
            salesReportBuilder.AddGenderSection();            

            // Act
            SalesReport salesReport = salesReportBuilder.Build();

            // Assert
            Assert.IsNotNull(salesReport);
            Assert.AreEqual("Raport sprzeda퓓", salesReport.Title);
            Assert.IsNotNull(salesReport.GenderDetails);
            Assert.IsNull(salesReport.ProductDetails);
            Assert.AreEqual(2, salesReport.GenderDetails.Count());
            
        }

        [TestMethod]
        public void Build_WithHeaderAndProductSection_ShouldReturnsSalesReport()
        {
            // Arrange
            salesReportBuilder.AddHeader("Raport sprzeda퓓");
            salesReportBuilder.AddProductSection();

            // Act
            SalesReport salesReport = salesReportBuilder.Build();

            // Assert
            Assert.IsNotNull(salesReport);
            Assert.AreEqual("Raport sprzeda퓓", salesReport.Title);
            Assert.IsNull(salesReport.GenderDetails);
            Assert.IsNotNull(salesReport.ProductDetails);
            Assert.AreEqual(3, salesReport.ProductDetails.Count());

        }
    }
}
