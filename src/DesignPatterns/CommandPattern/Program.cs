using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            //if (message.CanPrint())
            //{
            //    message.Print();
            //}

            //if (message.CanSend())
            //{
            //    message.Send();
            //}    

            // ICommand command = new PrintCommand("555000123", "555888000", "Hello World!", 3);

            //ICommand command = new SendCommand("555000123", "555888000", "Hello World!");

            Queue<ICommand> commands = new Queue<ICommand>();
            commands.Enqueue(new PrintCommand("555000123", "555888000", "Hello World!", 3));
            commands.Enqueue(new SendCommand("555000123", "555888000", "Hello World!"));


            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                    command.Execute();
            }



        }
    }

}
