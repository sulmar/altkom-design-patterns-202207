using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public interface IFrom
    {
        ITo From(string number);
    }

    public interface ITo
    {
        ISubject To(string number);
    }

    public interface IToOrCall : ITo, ICall
    {
    }

    public interface ISubject : IToOrCall
    {
        ICall WithSubject(string subject);
    }

    public interface ICall
    {
        void Call();
    }

    public class FluentPhone : IFrom, ITo, ICall, IToOrCall, ISubject
    {
        private string from;
        private ICollection<string> tos;
        private string subject;

        protected FluentPhone()
        {
            tos = new List<string>();
        }  

        public static IFrom HangUp()
        {
            return new FluentPhone();
        }

        public ITo From(string number)
        {
            this.from = number;

            return this;
        }

        public ISubject To(string number)
        {
            this.tos.Add(number);

            return this;
        }

        public ICall WithSubject(string subject)
        {
            this.subject = subject;

            return this;
        }

        public void Call()
        {
            foreach (var to in tos)
            {
                if (string.IsNullOrEmpty(subject))
                {
                    Console.WriteLine($"Calling from {from} to {to}");
                }
                else
                {
                    Console.WriteLine($"Calling from {from} to {to} with subject {subject}");
                }
            }
           
        }
    }

    public class Phone
    {
        public void Call(string from, string to, string subject)
        {
            Console.WriteLine($"Calling from {from} to {to} with subject {subject}");
        }

        public void Call(string from, string to)
        {
            Console.WriteLine($"Calling from {from} to {to}");
        }

        public void Call(string from, IEnumerable<string> tos, string subject)
        {
            foreach (var to in tos)
            {
                Call(from, to, subject);
            }
        }
    }

}