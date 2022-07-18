using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    // Abstract factory
    public interface IPaymentViewFactory
    {
        PaymentView Create(PaymentType paymentType);
    }

    // Concrete factory
    public class ConsolePaymentViewFactory : IPaymentViewFactory
    {
        public PaymentView Create(PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Cash => new CashPaymentView(),
                PaymentType.CreditCard => new CreditCardPaymentView(),
                PaymentType.BankTransfer => new BankTransferPaymentView(),
                _ => throw new NotSupportedException()
            };
        }
    }

    // Concrete factory
    public class HtmlPaymentViewFactory : IPaymentViewFactory
    {
        public PaymentView Create(PaymentType paymentType)
        {
            throw new NotImplementedException();
        }
    }
}
