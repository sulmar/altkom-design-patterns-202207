using System;

namespace AbstractFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

            // VisitCalculateAmountTest();

            PaymentTest();
        }



        private static void PaymentTest()
        {
            while (true)
            {
                Console.Write("Podaj kwotę: ");

                decimal.TryParse(Console.ReadLine(), out decimal totalAmount);

                Console.Write("Wybierz rodzaj płatności: (G)otówka (K)karta płatnicza (P)rzelew: ");

                string input = Console.ReadLine();

                PaymentType paymentType = PaymentTypeFactory.Create(input);

                Payment payment = new Payment(paymentType, totalAmount);
                IPaymentViewFactory paymentViewFactory = new ConsolePaymentViewFactory();

                PaymentView paymentView = paymentViewFactory.Create(paymentType);
                paymentView.Show(payment);

                string icon = IconFactory.Create(payment.PaymentType);
                Console.WriteLine(icon);                
            }

        }

        

        private static void VisitCalculateAmountTest()
        {
            while (true)
            {
                Console.Write("Podaj rodzaj wizyty: (N)FZ (P)rywatna (F)irma: ");
                string visitType = Console.ReadLine();

                Console.Write("Podaj czas wizyty w minutach: ");
                if (double.TryParse(Console.ReadLine(), out double minutes))
                {
                    TimeSpan duration = TimeSpan.FromMinutes(minutes);

                    Visit visit = new Visit(duration, 100);

                    decimal totalAmount = visit.CalculateCost(visitType);

                    if (totalAmount == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                       if (totalAmount >= 200)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }
    }
}
