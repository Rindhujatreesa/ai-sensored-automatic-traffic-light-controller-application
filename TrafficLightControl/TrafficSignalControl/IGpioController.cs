using System.Device.Gpio;

namespace TrafficSignalControl.Services
{
    public interface IGpioController
    {
        void OpenPin(int pinNumber, PinMode mode);
        PinValue Read(int pinNumber);
        void Write(int pinNumber, PinValue value);
    }
}