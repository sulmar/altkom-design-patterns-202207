using System;

namespace PrototypePattern
{
    public class InvoiceDetail : ICloneable
    {
        public InvoiceDetail(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
            Amount = product.UnitPrice;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        //public object Clone()
        //{
        //    return new InvoiceDetail(this.Product, this.Quantity) { Amount = this.Amount };
        //}

        public object Clone()
        {
            return this.MemberwiseClone();  // płytka kopia (shallow copy)
        }

        // głęboka kopia (Deep copy)



        public override string ToString()
        {
            return $"- {Product} {Quantity} {Amount:C2}";
        }
    }


}
