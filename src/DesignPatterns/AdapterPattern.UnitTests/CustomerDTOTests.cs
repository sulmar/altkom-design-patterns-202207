using AdapterPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterPattern.UnitTests
{
    [TestClass]
    public class CustomerDTOTests
    {
        [TestMethod]
        public void Convert_Customer_ShouldReturnCustomerDTO()
        {
            // Arrange
            var customer = new Customer { FirstName = "John", LastName = "Smith", HashedPassword = "a2#" };

            // Act
            CustomerDTO customerDto = CustomerMapper.Map(customer);

            // Assert
            Assert.AreEqual("John Smith", customerDto.FullName);

        }

        [TestMethod]
        public void Convert_CustomerDTO_ShouldReturnCustomer()
        {
            // Arrange
            CustomerDTO customerDto = new CustomerDTO { FullName = "John Smith" };

            // Act
            Customer customer = CustomerMapper.Map(customerDto);

            // Assert
            Assert.AreEqual("John", customer.FirstName);
            Assert.AreEqual("Smith", customer.LastName);
        }
    }
}
