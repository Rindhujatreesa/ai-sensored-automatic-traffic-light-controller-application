// Takes care of the input signal from the pins.
// This class IGpioController is used as the interface for both Real and Mock GPIO functionalities
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