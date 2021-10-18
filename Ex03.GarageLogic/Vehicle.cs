using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly float r_MaxAirPressure;
        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        protected Vehicle(int i_NumberOfWheels, float i_MaxAP)
        {
            m_LicenseNumber = null;
            m_ModelName = null;
            m_Wheels = new List<Wheel>(i_NumberOfWheels);
            r_MaxAirPressure = i_MaxAP;
            m_Engine = null;
        }

        public static bool operator ==(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_Vehicle1.LicenseNumber == i_Vehicle2.LicenseNumber;
        }

        public static bool operator !=(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return !(i_Vehicle1.LicenseNumber == i_Vehicle2.LicenseNumber);
        }

        public virtual void Init(string i_ModelName, string i_LicenseNum)
        {
            m_LicenseNumber = i_LicenseNum;
            m_ModelName = i_ModelName;
        }
        
        public void InflatingToMax()
        {
            foreach (Wheel myWheel in m_Wheels)
            {
                myWheel.InflatingToMax(r_MaxAirPressure);
            }
        }

        public virtual void AddWheel(string i_MfrName, float i_currentAP, float i_MaxAP)
        {
            if ((r_MaxAirPressure <= i_MaxAP) && (i_currentAP <= i_MaxAP))
            {
                m_Wheels.Add(new Wheel(i_MfrName, i_currentAP, i_MaxAP));
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.r_MaxAirPressure);
            }
        }

        public float EnergyPrecent
        {
            get
            {
                return m_Engine.EnergyPrecent;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return m_Wheels.Capacity;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public Wheel this[int i]
        {
            get
            {
                return m_Wheels[i];
            }

            set
            {
                m_Wheels[i] = value;
            }
        }

        private string showWheels()
        {
            StringBuilder wheelsToPrintSB = new StringBuilder(256);

            wheelsToPrintSB.Append("Wheels Description:\n");
            foreach (Wheel myWheel in m_Wheels)
            {
                wheelsToPrintSB.AppendLine(myWheel.ToString());
            }
            
            return wheelsToPrintSB.ToString();
        }

        public override string ToString()
        {
            string vehicleToString = string.Format(@"Model name: {0}, License Number: {1}.
{2}", m_ModelName, m_LicenseNumber, showWheels());

            return vehicleToString;
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if ((obj as Vehicle).LicenseNumber == this.m_LicenseNumber)
            {
                isEqual = true;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            int myHashCode;
            bool parseSuccess = int.TryParse(m_LicenseNumber, out myHashCode);
            if (!parseSuccess)
            {
                throw new FormatException("An error occurred while trying to Hash the vehicle");
            }

            return myHashCode;
        }
    }
}
