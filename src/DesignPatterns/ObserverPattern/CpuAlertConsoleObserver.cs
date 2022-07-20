using System;

namespace ObserverPattern
{
    public class CpuAlertConsoleObserver : IObserver<float>
    {
        private ConsoleColor color;

        public CpuAlertConsoleObserver(ConsoleColor color)
        {
            this.color = color;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(float cpu)
        {
            Console.BackgroundColor = color;
            Console.WriteLine($"CPU {cpu} %");
            Console.ResetColor();
        }
    }
}
