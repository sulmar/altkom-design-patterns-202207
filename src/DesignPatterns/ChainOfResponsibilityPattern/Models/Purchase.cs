using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models
{
    public class Purchase
    {
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public Approver ApprovedBy { get; set; }

        public Purchase(decimal amount, string purpose)
        {
            Amount = amount;
            Purpose = purpose;
        }
    }

    // Abstract Handler
    public abstract class Approver
    {
        protected Approver successor;
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }

    // Concrete Handler
    public class ProductManager : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 1000)
            {
                Console.WriteLine("ProductManager approved request");
                purchase.ApprovedBy = this;
            }
            else if (successor !=null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // Concrete Handler
    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 5000)
            {
                Console.WriteLine("Director approved request");
                purchase.ApprovedBy = this;
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // Concrete Handler
    public class CEO : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000)
            {
                Console.WriteLine("Director approved request");
                purchase.ApprovedBy = this;
            }
            else if (successor != null)
            {
                Console.WriteLine("Request requires an executive meeting!");
            }
        }
    }
}
