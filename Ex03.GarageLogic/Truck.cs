namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    { 
        private const int k_NumOfWheels = 16;
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuel = 120;
        private const float k_MaxAirPressure = 26;
        private bool m_IsCarryHazardousMaterials;
        private float m_MaxCarryWeight;

        public Truck() : base(k_NumOfWheels, k_MaxAirPressure)
        {
            this.VehicleEngine = new GasEngine(k_MaxFuel, k_FuelType);
            m_MaxCarryWeight = 0;
            m_IsCarryHazardousMaterials = false;
        }

        public override string ToString()
        {
            string gasMotoToString = string.Format(@"{0}{1}
Max Carry Weight: {2}, Does carry hazardous materials: {3}",
                base.ToString(), VehicleEngine.ToString(), m_MaxCarryWeight, (m_IsCarryHazardousMaterials == false) ? "No" : "Yes");

            return gasMotoToString;
        }

        public bool IsHazardousMaterials
        {
            get
            {
                return m_IsCarryHazardousMaterials;
            }

            set
            {
                m_IsCarryHazardousMaterials = value;
            }
        }

        public float MaxCarryWeight
        {
            get
            {
                return m_MaxCarryWeight;
            }

            set
            {
                m_MaxCarryWeight = value;
            }
        }
    }
}
