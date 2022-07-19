using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class InfraredRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class InfraredRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            IsSwitchOn = true; 
            Console.WriteLine("Sony: Switch On");
            
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");            
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            IsSwitchOn = true;
            Console.WriteLine("Sony: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }

    public class WifiRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by Wifi");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by Wifi");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by Wifi");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }


    // Abstract implementor
    public interface ILedTv
    {
        bool On { get; set; }
        byte CurrentChannel { get; set; }

        void SwitchOn();
        void SwitchOff();
        void SetChannel(byte number);
    }

    public class SamsungLedTv : ILedTv
    {
        public bool On { get; set; }
        public byte CurrentChannel { get; set; }

        public void SetChannel(byte number)
        {
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }

        public void SwitchOn()
        {
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
    }

    public class SonyLedTv : ILedTv
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public bool On { get => IsSwitchOn; set => IsSwitchOn = value; }
        public byte CurrentChannel { get => SelectedChannel; set => SelectedChannel = value; }

        public void SetChannel(byte number)
        {
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");
        }

        public void SwitchOn()
        {
            IsSwitchOn = true;
            Console.WriteLine("Sony: Switch On");
        }
    }

    // Abstraction
    public abstract class AbstractRemoteControl
    {
        // Implementor
        protected ILedTv ledTv;

        protected AbstractRemoteControl(ILedTv ledTv)
        {
            this.ledTv = ledTv;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(byte number);
    }

    public class InfraredRemoteControl : AbstractRemoteControl
    {
        public InfraredRemoteControl(ILedTv ledTv) : base(ledTv)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            ledTv.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            ledTv.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            ledTv.SwitchOn();
        }
    }

    public class BluetoothRemoteControl : AbstractRemoteControl
    {        
        public BluetoothRemoteControl(ILedTv ledTv) : base(ledTv)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            ledTv.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            ledTv.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            ledTv.SwitchOn();
        }
    }
}
