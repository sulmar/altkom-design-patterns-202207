using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class OrderCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly ICalculateDiscountStrategy calculateDiscountStrategy;

        public OrderCalculator(ICanDiscountStrategy canDiscountStrategy, ICalculateDiscountStrategy calculateDiscountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy;
            this.calculateDiscountStrategy = calculateDiscountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))
            {
                return calculateDiscountStrategy.CalculateDiscount(order);
            }
            else
                return decimal.Zero;
        }

    }

    public class RuntimeOrderCalculator
    {
        public IOrderDiscountStrategy OrderDiscountStrategy { get; set; }
       
        public decimal CalculateDiscount(Order order)
        {
            if (OrderDiscountStrategy.CanDiscount(order))
            {
                return OrderDiscountStrategy.CalculateDiscount(order);
            }
            else
                return decimal.Zero;
        }

    }

    // Abstract strategy
    public interface IOrderDiscountStrategy
    {
        bool CanDiscount(Order order);
        decimal CalculateDiscount(Order order);
    }

    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

    public interface ICalculateDiscountStrategy
    {
        decimal CalculateDiscount(Order order);
    }

    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly Gender gender;

        public GenderCanDiscountStrategy(Gender gender)
        {
            this.gender = gender;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }
    }

    public class HappyHoursDiscountStrategy : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
        }
    }

    public class PercentageCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageCalculateDiscountStrategy(decimal percentage) => this.percentage = percentage;
        public decimal CalculateDiscount(Order order) => order.Amount * percentage;
    }

    public class FixedCalculateDiscountStrategy : ICalculateDiscountStrategy
    {
        private readonly decimal amount;

        public FixedCalculateDiscountStrategy(decimal amount) => this.amount = amount;
        public decimal CalculateDiscount(Order order) => amount;
    }

    // DRY (Don't Repeate Yourself)

    // Concrete strategy
    public class PercentageGenderOrderDiscountStrategy : IOrderDiscountStrategy
    {
        private readonly Gender gender;
        private readonly decimal percentage;

        public PercentageGenderOrderDiscountStrategy(Gender gender, decimal percentage)
        {
            this.gender = gender;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }

        public decimal CalculateDiscount(Order order)
        {
            return order.Amount * percentage;
        }        
    }

    public class FixedGenderOrderDiscountStrategy : IOrderDiscountStrategy
    {
        private readonly Gender gender;
        private readonly decimal discount;

        public FixedGenderOrderDiscountStrategy(Gender gender, decimal discount)
        {
            this.gender = gender;
            this.discount = discount;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }

        public decimal CalculateDiscount(Order order)
        {
            return discount;
        }
    }

    public class PercentageHappyHoursDiscountStrategy : IOrderDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal percentage;

        public PercentageHappyHoursDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            return order.Amount * percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
        }
    }

    public class FixedHappyHoursDiscountStrategy : IOrderDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal discount;

        public FixedHappyHoursDiscountStrategy(TimeSpan from, TimeSpan to, decimal discount)
        {
            this.from = from;
            this.to = to;
            this.discount = discount;
        }

        public decimal CalculateDiscount(Order order)
        {
            return discount;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to;
        }
    }
}
