namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        private const int k_NumOfWheels = 2;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuel = 6;
        private const float k_MaxAirPressure = 30;

        public GasMotorcycle() : base(k_NumOfWheels, k_MaxAirPressure)
        {
            this.VehicleEngine = new GasEngine(k_MaxFuel, k_FuelType);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
