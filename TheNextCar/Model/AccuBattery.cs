using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Model
{
    class AccuBattery
    {
        private int voltage;
        private bool statOn = false;
        

        public AccuBattery(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.statOn = true;
        }
        public void turnOff()
        {
            this.statOn = false;
        }
        public bool IsOn()
        {
            return this.statOn;
        }
    }
}
