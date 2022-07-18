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
}
