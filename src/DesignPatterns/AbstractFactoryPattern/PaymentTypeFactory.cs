using System;

namespace AbstractFactoryPattern
{
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
