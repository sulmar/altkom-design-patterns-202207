using System;

namespace StatePattern
{
    public class Lamp
    {
        public bool IsOn { get; private set; }

        public Lamp()
        {
            IsOn = false;
        }

        public void PushDown()
        {
            if (!IsOn)
            {
                IsOn = true;
            }
            else
                throw new InvalidOperationException($"{IsOn}");
        }


        public void PushUp()
        {
            if (IsOn)
            {
                IsOn = false;
            }
            else
                throw new InvalidOperationException($"{IsOn}");

        }

    }

}
