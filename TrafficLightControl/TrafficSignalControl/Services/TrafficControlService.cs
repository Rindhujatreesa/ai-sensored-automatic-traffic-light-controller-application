using System.Device.Gpio;
using TrafficSignalControl.Models;

namespace TrafficSignalControl.Services
{
    public class TrafficControlService
    {
        private IGpioController _controller;
        private int _redPin = 17;
        private int _greenPin = 27;
        private int _sensorPin = 22;

        public TrafficControlService(IGpioController controller)
        {
            _controller = controller;
            _controller.OpenPin(_redPin, PinMode.Output);
            _controller.OpenPin(_greenPin, PinMode.Output);
            _controller.OpenPin(_sensorPin, PinMode.Input);
        }

        public void ControlTraffic()
        {
            while (true)
            {
                if (_controller.Read(_sensorPin) == PinValue.Low)
                {
                    _controller.Write(_redPin, PinValue.Low);
                    _controller.Write(_greenPin, PinValue.High);
                }
                else
                {
                    _controller.Write(_greenPin, PinValue.Low);
                    _controller.Write(_redPin, PinValue.High);
                }
                Thread.Sleep(1000);
            }
        }
    }
}