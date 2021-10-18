namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_Mfr, float i_CurrentAirPressure, float i__MaxAirPressure)
        {
            r_ManufacturerName = i_Mfr;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i__MaxAirPressure;
        }

        public void InflateWheel(float i_AirPressureToAdd)
        {
            if(m_CurrentAirPressure + i_AirPressureToAdd <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure);
            }
        }

        public override string ToString()
        {
            string wheelToString = string.Format("Manufacturer: {0}, Air Pressure: {1}", r_ManufacturerName, m_CurrentAirPressure);

            return wheelToString;
        }

        public void InflatingToMax(float i_AirPressure)
        {
            m_CurrentAirPressure = i_AirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
    }
}
