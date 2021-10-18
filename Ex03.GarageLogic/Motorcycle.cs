namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngingCapacity;

        protected Motorcycle(int i_NumOfWheels, float i_MaxAP) : base(i_NumOfWheels, i_MaxAP)
        {
            m_EngingCapacity = 0;
        }

        public override string ToString()
        {
            string motorToString = string.Format(@"{0}{1}
License Type: {2}, Engine Capacity: {3}", base.ToString(), VehicleEngine.ToString(), this.LicenseType, this.EngineCapacity);

            return motorToString;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngingCapacity;
            }

            set
            {
                m_EngingCapacity = value;
            }
        }
    }
}
