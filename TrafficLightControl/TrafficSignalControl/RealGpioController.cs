using System.Device.Gpio;

namespace TrafficSignalControl.Services
{
    public class RealGpioController : IGpioController
    {
        private GpioController _controller;

        public RealGpioController()
        {
            _controller = new GpioController();
        }

        public void OpenPin(int pinNumber, PinMode mode)
        {
            _controller.OpenPin(pinNumber, mode);
        }

        public PinValue Read(int pinNumber)
        {
            return _controller.Read(pinNumber);
        }

        public void Write(int pinNumber, PinValue value)
        {
            _controller.Write(pinNumber, value);
        }
    }
}