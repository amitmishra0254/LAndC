using ServiceCenterApplication.Constants;
using ServiceCenterApplication.Enums;
using ServiceCenterApplication.Factories;
using ServiceCenterApplication.Factories.Interfaces;

namespace ServiceCenterApplication
{
    public class ServiceCenter
    {
        public static void Main(string[] args)
        {
            try
            {
                int vehicleType = PrintMenu();

                VehicleType parsedVehicleType = (VehicleType)vehicleType;

                Vehicle vehicle = VehicleFactory.GetVehicle(parsedVehicleType);

                vehicle.Service();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static int PrintMenu()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(ApplicationConstants.Menu + "Enter your choice (1-3): ");
            int vehicleType = int.Parse(Console.ReadLine());
            if (vehicleType <= (int)VehicleType.Truck && vehicleType > 0)
            {
                return vehicleType;
            }
            else
            {
                Console.WriteLine(ApplicationConstants.InvalidUserInput);
                return PrintMenu();
            }
        }
    }
}