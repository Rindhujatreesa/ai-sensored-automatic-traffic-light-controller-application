using System.Device.Gpio;

namespace TrafficSignalControl.Services
{
    public class MockGpioController : IGpioController
    {
        public void OpenPin(int pinNumber, PinMode mode)
        {
            Console.WriteLine($"Mock: OpenPin {pinNumber} in {mode} mode.");
        }

        public PinValue Read(int pinNumber)
        {
            Console.WriteLine($"Mock: Read from pin {pinNumber}");
            return PinValue.High;
        }

        public void Write(int pinNumber, PinValue value)
        {
            Console.WriteLine($"Mock: Write {value} to pin {pinNumber}");
        }
    }
}