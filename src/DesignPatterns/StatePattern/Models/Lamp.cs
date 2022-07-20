using Stateless;
using System;
using System.Diagnostics;

namespace StatePattern
{
    public class Lamp
    {
        public byte Volume => stateMachine.State;

        private StateMachine<byte, LampTrigger> stateMachine;

        public string Graph => Stateless.Graph.UmlDotGraph.Format(stateMachine.GetInfo());

        public Lamp()
        {
            stateMachine = new StateMachine<byte, LampTrigger>(0);

            stateMachine.Configure(0)
                .Permit(LampTrigger.PushDown, 50);

            stateMachine.Configure(50)
                .OnEntry(()=> DisplayVolume(50), "DisplayVolume")
                .Permit(LampTrigger.PushDown, 100)
                .Permit(LampTrigger.PushUp, 0);

            stateMachine.Configure(100)
                .Permit(LampTrigger.PushUp, 0);

            stateMachine.OnTransitioned(t => Trace.WriteLine($"{t.Trigger} : {t.Source} -> {t.Destination}"));
        }

        private void DisplayVolume(byte volume)
        {
            Console.WriteLine($"{volume:P0}");
        }

        public void PushDown() => stateMachine.Fire(LampTrigger.PushDown);
        public bool CanPushDown() => stateMachine.CanFire(LampTrigger.PushDown);

        public void PushUp() => stateMachine.Fire(LampTrigger.PushUp);


        public enum LampTrigger
        {
            PushDown,
            PushUp
        }

    }

}
