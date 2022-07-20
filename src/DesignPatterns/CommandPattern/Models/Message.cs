using System;

namespace CommandPattern
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class SendCommand : ICommand
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Content { get; private set; }

        public SendCommand(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public void Execute()
        {
            Console.WriteLine($"Send message from <{From}> to <{To}> {Content}");
        }

        public bool CanExecute()
        {
            return !(string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To) || string.IsNullOrEmpty(Content));
        }
    }

    public class PrintCommand : ICommand
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Content { get; private set; }
        public int Copies { get; }

        public PrintCommand(string from, string to, string content, int copies)
        {
            From = from;
            To = to;
            Content = content;
            Copies = copies;
        }

        public void Execute()
        {            
            for (int i = 0; i < Copies; i++)
            {
                Console.WriteLine($"Print message from <{From}> to <{To}> {Content}");
            }
        }

        public bool CanExecute()
        {
            return string.IsNullOrEmpty(Content) & string.IsNullOrEmpty(From);
        }
    }

    public class Message
    {
        public Message(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }

     
        public void Send()
        {
            Console.WriteLine($"Send message from <{From}> to <{To}> {Content}");
        }      

        public void Print(byte copies = 1)
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"Print message from <{From}> to <{To}> {Content}");
            }
        }

        public bool CanPrint()
        {
            return string.IsNullOrEmpty(Content) & string.IsNullOrEmpty(From);
        }

        public bool CanSend()
        {
            return !(string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To) || string.IsNullOrEmpty(Content));
        }

    }

}
