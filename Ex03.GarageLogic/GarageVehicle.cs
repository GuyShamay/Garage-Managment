using System;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Owner? m_Owner;
        private eGarageVehicleStatus m_Status;
        private Vehicle m_Vehicle;

        public GarageVehicle(eVehicleType i_VehicleType)
        {
            m_Vehicle = CreateVehicle.Create(i_VehicleType);
            m_Status = eGarageVehicleStatus.InWorkshop;
            m_Owner = null;
        }

        public void UpdateOwner(string i_OwnerName, string i_OwnerPhone)
        {
            m_Owner = new Owner(i_OwnerName, i_OwnerPhone);
        }

        public override string ToString()
        {
              string gvToString =
                  string.Format(@"{0}
{1}
Status: {2}", m_Vehicle.ToString(), m_Owner.ToString(), m_Status);
              
            return gvToString;
        }

        public void InitVehicle(string i_ModelName, string i_LicenseNum)
        {
            m_Vehicle.Init(i_ModelName, i_LicenseNum);
        }

        public void AddSameWheelForAll(string i_MfrName, float i_currentAP, float i_MaxAP)
        {
            for (int i = 0; i < this.GetVehicle.NumberOfWheels; i++)
            {
                AddWheel(i_MfrName, i_currentAP, i_MaxAP);
            }
        }

        public void AddWheel(string i_MfrName, float i_currentAP, float i_MaxAP)
        {
            try
            {
                this.GetVehicle.AddWheel(i_MfrName, i_currentAP, i_MaxAP);
            }
            catch (ValueOutOfRangeException vorex)
            {
                throw new Exception("Failed updating wheel to vehicle", vorex);
            }
        }

        public Vehicle GetVehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public Owner Owner
        {
            get
            {
                return m_Owner ?? throw new Exception("Owner doesn't exist");
            }
        }

        public eGarageVehicleStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_Vehicle.LicenseNumber;
            }
        }

        public float RemainingEnergy
        {
            get
            {
                return m_Vehicle.VehicleEngine.RemainingEnergySource;
            }

            set
            {
                if (value <= this.GetVehicle.VehicleEngine.MaxEnergySource)
                {
                    m_Vehicle.VehicleEngine.RemainingEnergySource = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, this.GetVehicle.VehicleEngine.MaxEnergySource);
                }
            }
        }
    }
}
