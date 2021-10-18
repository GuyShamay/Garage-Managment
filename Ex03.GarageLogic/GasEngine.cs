namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public GasEngine(float i_MaxFuel, eFuelType i_FuelType) : base(i_MaxFuel)
        {
            r_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType == r_FuelType)
            {
                AddEnergy(i_FuelToAdd);
            }
            else
            {
                throw new WrongTypeException("Fuel");
            }
        }

        public override string ToString()
        {
            string engineToString = string.Format(@"Fuel Type: {0}, {1}", r_FuelType, base.ToString());

            return engineToString;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }
    }
}
