//This C# file is called when an operating system is unable to control the General Purpose Input/Output operations
// of a pin, like MacOS
using System.Device.Gpio;

namespace TrafficSignalControl.Services
{
    public class MockGpioController : IGpioController
    {
        public void OpenPin(int pinNumber, PinMode mode)
        {
            Console.WriteLine($"OpenPin {pinNumber} in {mode} mode.");
        }

        public PinValue Read(int pinNumber)
        {
            Console.WriteLine($"Read from pin {pinNumber}");
            return PinValue.High;
        }

        public void Write(int pinNumber, PinValue value)
        {
            Console.WriteLine($"Write {value} to pin {pinNumber}");
        }
    }
}