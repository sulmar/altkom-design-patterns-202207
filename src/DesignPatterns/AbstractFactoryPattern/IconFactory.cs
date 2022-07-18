using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    public class IconFactory
    {
        public static string Create(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Cash: return "[100]";
                case PaymentType.CreditCard: return "[abc]";
                case PaymentType.BankTransfer: return "[-->]";

                default: return string.Empty;
            }
        }
    }

    public class PaymentTypeFactory
    {
        public static PaymentType Create(string input) => input switch
        {
            "G" => PaymentType.Cash,
            "K" => PaymentType.CreditCard,
            "P" => PaymentType.BankTransfer,
            _ => throw new NotSupportedException(),
        };
    }
}
