using ServiceCenterApplication.Enums;
using ServiceCenterApplication.Factories.Interfaces;

namespace ServiceCenterApplication.Factories
{
    class VehicleFactory
    {
        public static Vehicle GetVehicle(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car:
                    return new Car();
                case VehicleType.Bike:
                    return new Bike();
                case VehicleType.Truck:
                    return new Truck();
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}