using System;

namespace StatePattern
{
    public class Order
    {
        public Order(OrderStatus status = OrderStatus.Created)
        {
        }

        public OrderStatus Status { get; private set; }

        public void Confirm()
        {
            if (Status == OrderStatus.Created)
            {
                Status = OrderStatus.Completion;                
            }
            else if (Status == OrderStatus.Completion)
            {
                Status = OrderStatus.Sent;
            }
            else if (Status == OrderStatus.Completion)
            {
                Status = OrderStatus.Done;
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Created || Status == OrderStatus.Completion)
            {
                Status = OrderStatus.Canceled;
            }
            else if (Status == OrderStatus.Sent)
            {
                Status = OrderStatus.Sent; // send again
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    public enum OrderStatus
    {
        Created,
        Completion,
        Sent,
        Canceled,
        Done
    }

}
