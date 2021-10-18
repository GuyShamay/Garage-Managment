namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergySource;
        private float m_RemainingEnergySource;

        protected Engine(float i_MaxEnergySource)
        {
            r_MaxEnergySource = i_MaxEnergySource;
            m_RemainingEnergySource = 0;
        }

        public void AddEnergy(float i_EnergyToAdd)
        {
            if (m_RemainingEnergySource + i_EnergyToAdd <= r_MaxEnergySource)
            {
                m_RemainingEnergySource += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergySource);
            }
        }

        public override string ToString()
        {
            string engineToString = string.Format(@"Energy Status: {0}%", this.EnergyPrecent);

            return engineToString;
        }

        public float EnergyPrecent
        {
            get
            {
                return (m_RemainingEnergySource / r_MaxEnergySource) * 100;
            }
        }

        public float MaxEnergySource
        {
            get
            {
                return r_MaxEnergySource;
            }
        }

        public float RemainingEnergySource
        {
            get
            {
                return m_RemainingEnergySource;
            }

            set
            {
                m_RemainingEnergySource = value;
            }
        }
    }
}