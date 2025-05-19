using ServiceCenterApplication.Factories.Interfaces;

namespace ServiceCenterApplication.CarServices
{
    class Car : Vehicle
    {
        public void Service()
        {
            OilChange();
            BrakeInspection();
            TireRotation();
        }

        private void OilChange()
        {
            Console.WriteLine("Car Service: Oil change");
        }

        private void BrakeInspection()
        {
            Console.WriteLine("Car Service: Brake inspection");
        }

        private void TireRotation()
        {
            Console.WriteLine("Car Service: Tire rotation");
        }
    }
}