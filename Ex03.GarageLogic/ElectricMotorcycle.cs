namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBattery = 1.8f;
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 30;

        public ElectricMotorcycle()
            : base(k_NumOfWheels, k_MaxAirPressure)
        {
            this.VehicleEngine = new ElectricEngine(k_MaxBattery);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}