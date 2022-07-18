using System;
using System.Collections.Generic;
using System.Linq;

namespace PrototypePattern
{
    public class Invoice : ICloneable
    {
        public Invoice(string number, DateTime createDate, PaymentType paymentType, Customer customer)
        {
            Number = number;
            CreateDate = createDate;
            PaymentType = paymentType;
            Customer = customer;
        }

        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public Customer Customer { get; set; }

        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Amount);

        public IList<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();

        public override string ToString()
        {
            return $"Invoice No {Number} {TotalAmount:C2} {Customer.FullName} payment method {PaymentType}";
        }

        private Invoice CreateCopy()
        {
            Invoice invoiceCopy = new Invoice(this.Number, DateTime.Today, this.PaymentType, this.Customer);

            foreach (InvoiceDetail detail in this.Details)
            {
                invoiceCopy.Details.Add((InvoiceDetail) detail.Clone());
            }

            return invoiceCopy;
        }

        public object Clone()
        {
            return CreateCopy();
        }
    }

    public enum PaymentType
    {
        Cash,
        Transfer
    }


}
