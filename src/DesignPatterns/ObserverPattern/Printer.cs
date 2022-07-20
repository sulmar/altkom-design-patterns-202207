using System;

namespace ObserverPattern
{
    public class Printer : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Release!");
            Realase();
        }

        public void Print(string content)
        {
            System.IO.File.Create("temp.txt");

            if (content.Length > 3)
            {
                throw new ApplicationException();
            }

            Console.WriteLine($"Printing {content}...");
        }

        private void Realase()
        {
            System.IO.File.Delete("temp.txt");
        }
    }

}
