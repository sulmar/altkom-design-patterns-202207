using AdapterPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class CustomerMapper
    {
        public static CustomerDTO Map(Customer customer)
        {
            return new CustomerDTO { FullName = customer.FirstName + " " + customer.LastName };
        }

        public static Customer Map(CustomerDTO customerDto)
        {
            var names = customerDto.FullName.Split(' ');

            Customer customer = new Customer { FirstName = names[0], LastName = names[1] };

            return customer;
        }
    }
}
