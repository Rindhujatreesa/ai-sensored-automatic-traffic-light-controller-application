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