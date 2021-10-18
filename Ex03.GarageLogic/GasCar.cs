namespace Ex03.GarageLogic
{
    public class GasCar : Car
    {
        private const int k_NumOfWheels = 4;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuel = 45;
        private const float k_MaxAirPressure = 32;

        public GasCar() : base(k_NumOfWheels, k_MaxAirPressure)
        {
            this.VehicleEngine = new GasEngine(k_MaxFuel, k_FuelType);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
