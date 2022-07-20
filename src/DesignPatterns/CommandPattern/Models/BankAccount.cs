using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class DepositCommand : ICommand
    {
        private BankAccount bankAccount;
        private readonly decimal amount;

        public DepositCommand(BankAccount bankAccount, decimal amount)
        {
            this.bankAccount = bankAccount;
            this.amount = amount;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            bankAccount.Balance += amount;
        }
    }

    public class OverlimitException : ApplicationException
    {
        public decimal Limit { get; set; }

        public OverlimitException(decimal limit, string message)
            : base(message)
        {
            Limit = limit;
        }
    }

    public class WithdrawCommand : ICommand
    {
        private BankAccount bankAccount;
        private readonly decimal amount;

        public WithdrawCommand(BankAccount bankAccount, decimal amount)
        {
            this.bankAccount = bankAccount;
            this.amount = amount;
        }

        public bool CanExecute()
        {
            return bankAccount.Balance - amount >= BankAccount.OverdraftLimit;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                bankAccount.Balance -= amount;
            }
            else
            {
                throw new OverlimitException(BankAccount.OverdraftLimit, "Przekroczono limit");
            }
        }
    }

    public class BankAccount
    {
        public const decimal OverdraftLimit = -500;
        public decimal Balance { get; set; }
    }
}
