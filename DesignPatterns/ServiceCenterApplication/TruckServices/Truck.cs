using ServiceCenterApplication.Factories.Interfaces;

namespace ServiceCenterApplication.TruckServices
{
    class Truck : Vehicle
    {
        public void Service()
        {
            EngineDiagnostics();
            CargoInspection();
        }

        private void EngineDiagnostics()
        {
            Console.WriteLine("Truck Service: Heavy-duty engine diagnostics");
        }

        private void CargoInspection()
        {
            Console.WriteLine("Truck Service: Cargo inspection");
        }
    }
}