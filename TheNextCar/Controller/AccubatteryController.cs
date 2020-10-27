using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubatteryController
    {
        private AccuBattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new AccuBattery(12);
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "Power Is On");
        }

        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "Power Is OFF");
        }
        public bool accubatteryIsOn()
        {
            return this.accubattery.IsOn();
        }
    }

    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
