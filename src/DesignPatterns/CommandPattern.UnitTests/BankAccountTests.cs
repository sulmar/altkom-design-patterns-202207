using CommandPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CommandPattern.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void History()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            // Act

            Queue<CommandPattern.Models.ICommand> commands = new Queue<CommandPattern.Models.ICommand>();

            commands.Enqueue(new DepositCommand(bankAccount, 100));
            commands.Enqueue(new WithdrawCommand(bankAccount, 100));
            commands.Enqueue(new DepositCommand(bankAccount, 200));
            commands.Enqueue(new DepositCommand(bankAccount, 100));
            commands.Enqueue(new WithdrawCommand(bankAccount, 50));

            while(commands.Count > 0 )
            {
                CommandPattern.Models.ICommand command = commands.Dequeue();

                try
                {
                    if (command.CanExecute())
                    {
                        command.Execute();
                    }
                }
                catch
                {
                    
                }
            }

            var result = bankAccount.Balance;

            // Assert
            Assert.AreEqual(250, result);
        }

        [TestMethod]
        public void Withdraw_OverdraftLimit_ShouldThrowsApplicationException()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            CommandPattern.Models.ICommand depositCommand = new DepositCommand(bankAccount, 100);

            CommandPattern.Models.ICommand withdrawCommand = new WithdrawCommand(bankAccount, 1000);

            // Act
            Action act = () => withdrawCommand.Execute();

            // Assert
            Assert.ThrowsException<ApplicationException>(act);
        }
    }
}
