using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Problem
{
    public class LightSwitch
    {
        public LightSwitchState State { get; set; }

        public void Push()
        {
            if (State == LightSwitchState.Off)
            {
                Console.WriteLine("włącz przekaźnik");

                State = LightSwitchState.On;
                return;
            }

            if (State == LightSwitchState.On)
            {
                Console.WriteLine("wyłącz przekaźnik");

                State = LightSwitchState.Off;
                return;
            }
        }
    }

    public enum LightSwitchState
    {
        On,
        Off
    }
}

namespace StatePattern.Solution
{
    // Abstract State
    public interface LightSwitchState
    {
        // Handle
        void Push(LightSwitch lightSwitch);
    }

    // Concrete State
    public class On : LightSwitchState
    {
        public void Push(LightSwitch lightSwitch)
        {
            Console.WriteLine("wyłącz przekaźnik");

            lightSwitch.SetState(new Off());            
        }
    }

    // Concrete State
    public class Off : LightSwitchState
    {
        public void Push(LightSwitch lightSwitch)
        {
            Console.WriteLine("załącz przekaźnik");

            lightSwitch.SetState(new On());
        }
    }

    // Context
    public class LightSwitch
    {
        public LightSwitchState State { get; private set; }

        public LightSwitch()
        {
            State = new Off();
        }

        public void SetState(LightSwitchState state) => this.State = state;

        // Request
        public void Push() => State.Push(this);
    }
}