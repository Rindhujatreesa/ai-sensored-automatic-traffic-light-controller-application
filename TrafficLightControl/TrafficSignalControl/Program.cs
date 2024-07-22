//This C# file is the execution file that enables the application to run
// It identifies the type of OS and assigns the right GPIO Controller 
//finally it creates an instance of TrafficControlService namespace and runs the ControlTraffic() method
using TrafficSignalControl.Services;

namespace TrafficSignalControl
{
    class Program
    {
        static void Main(string[] args)
        {
            IGpioController gpioController;

            if (OperatingSystem.IsMacOS())
            {
                gpioController = new MockGpioController();
            }
            else
            {
                gpioController = new RealGpioController();
            }

            var trafficControlService = new TrafficControlService(gpioController);
            trafficControlService.ControlTraffic();
        }
    }
}