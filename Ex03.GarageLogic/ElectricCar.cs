namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxBattery = 3.2f;
        private const float k_MaxAirPressure = 32;

        public ElectricCar() : base(k_NumOfWheels, k_MaxAirPressure)
        {
            this.VehicleEngine = new ElectricEngine(k_MaxBattery);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}