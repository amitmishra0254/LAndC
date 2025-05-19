using ServiceCenterApplication.Factories.Interfaces;

namespace ServiceCenterApplication.BikeServices
{
    class Bike : Vehicle
    {
        public void Service()
        {
            ChainLubrication();
            BrakeTightening();
        }

        private void ChainLubrication()
        {
            Console.WriteLine("Bike Service: Chain lubrication");
        }

        private void BrakeTightening()
        {
            Console.WriteLine("Bike Service: Brake tightening");
        }
    }
}