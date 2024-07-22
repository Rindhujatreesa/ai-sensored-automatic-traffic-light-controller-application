// This C# file defines the modes of operation for each pin in GPIO.
// While Red(17) and Green(27) pins are output signals, the sensor(22) pin is the input signal that determines the output

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

// Red light or the red pin gives an output when the sensor pin has a Low PinValue, indicating the absense of any vehicles; 
// Similarly, Green pin lights when the sensor pin has a High PinValue, indicating that the image sensors have detected a vehicle
// The sensor is activated every 1000ms, i.e., every one second.
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