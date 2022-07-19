using System;

namespace TemplateMethodPattern
{
    // Gender - 20% upustu dla kobiet
    public class GenderPercentageOrderCalculator : TemplateOrderCalculator
    {
        private readonly Gender gender;

        private readonly decimal percentage;

        public GenderPercentageOrderCalculator(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public override bool CanDiscount(Order order) => order.Customer.Gender == gender;
        public override decimal Discount(Order order) => order.Amount * percentage;
    }

    

    // Szablon metody (Template Method)
    public abstract class TemplateOrderCalculator
    {
        public abstract bool CanDiscount(Order order);
        public abstract decimal Discount(Order order);
        public virtual decimal NoDiscount()
        {
            return decimal.Zero;
        }

        public decimal CalculateDiscount(Order order)
        {


            if (CanDiscount(order))            // warunek (predykat)
            {
                return Discount(order);        // obliczenie upustu
            }
            else
                return NoDiscount();                // brak upustu
        }
    }

    //public class GenderDelegateTemplateOrderCalculator : DelegateTemplateOrderCalculator
    //{
    //    private readonly decimal percentage;

    //    public GenderDelegateTemplateOrderCalculator(decimal percentage) : base(
    //            order => order.Customer.Gender == Gender.Female,
    //            order => order.Amount * percentage
    //    )
    //    {
    //    }
    //}

    public class DelegateTemplateOrderCalculator
    {
        private readonly Predicate<Order> canDiscount;
        private readonly Func<Order, decimal> discount;

        public DelegateTemplateOrderCalculator(Predicate<Order> CanDiscount, Func<Order, decimal> Discount)
        {
            canDiscount = CanDiscount;
            discount = Discount;
        }

        public virtual decimal NoDiscount()
        {
            return decimal.Zero;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscount(order))            // warunek (predykat)
            {
                return discount(order);        // obliczenie upustu
            }
            else
                return NoDiscount();                // brak upustu
        }
    }




}
