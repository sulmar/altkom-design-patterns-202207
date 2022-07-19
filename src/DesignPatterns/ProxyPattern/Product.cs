namespace ProxyPattern
{
    public class Product
    {
        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CacheHit { get; set; }
    }

    // Subject
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Number { get; set; }
        public virtual Customer Customer { get; set; }
    }
    
    // Proxy
    public class InvoiceProxy : Invoice
    {
        public override Customer Customer
        {
            get
            {
                // TODO: execute sql
                return base.Customer;
            }
            set
            {
                base.Customer = value;
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
