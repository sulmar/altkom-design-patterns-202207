using System;

namespace TemplateMethodPattern
{
    // Happy Hours - 10% upustu w godzinach od 8:30 do 15
    public class HappyHoursPercentageOrderCalculator : TemplateOrderCalculator
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal percentage;

        public HappyHoursPercentageOrderCalculator(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;            
        }

        public override bool CanDiscount(Order order) => order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        public override decimal Discount(Order order) => order.Amount * percentage;

    }

}
