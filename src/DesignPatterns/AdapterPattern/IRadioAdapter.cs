using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    // Abstract adapter
    public interface IRadioAdapter
    {
        void Send(string message, byte channel);        
    }

    public class MotorolaRadioClassAdapter : MotorolaRadio, IRadioAdapter
    {
        private string pincode;

        public MotorolaRadioClassAdapter(string pincode)
        {
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            PowerOn(pincode);
            SelectChannel(channel);
            Send(message);
            PowerOff();
        }
    }

    public class HyteraRadioClassAdapter : HyteraRadio, IRadioAdapter
    {
        public void Send(string message, byte channel)
        {   
            Init();
            SendMessage(channel, message);
            Release();
        }
    }

    // Concrete adapter
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private MotorolaRadio radio;

        private string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            this.pincode = pincode;

            radio = new MotorolaRadio();            
        }

        public void Send(string message, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }
    }

    // Concrete adapter
    public class HyteraRadioAdapter : IRadioAdapter
    {
        private HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(string message, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }
}
