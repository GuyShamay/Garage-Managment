namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> r_VehicleList;

        public Garage()
        {
            r_VehicleList = new Dictionary<string, GarageVehicle>();
        }

        public GarageVehicle this[string i]
        {
            get { return r_VehicleList[i]; }
            set { r_VehicleList[i] = value; }
        }

        public Dictionary<string, GarageVehicle> VehicleList
        {
            get
            {
                return r_VehicleList;
            }
        }

        public bool Find(string i_LicenseNum)
        {
            return r_VehicleList.ContainsKey(i_LicenseNum);
        }

        public void ShowLicenses(int i_Choice)
        {
            if (r_VehicleList.Count > 0)
            {
                foreach (var garageVehicle in r_VehicleList)
                {
                    if (garageVehicle.Value.Status == (eGarageVehicleStatus)i_Choice)
                    {
                        Console.WriteLine(garageVehicle.Value.LicenseNumber);
                    }
                }
            }
            else
            {
                throw new Exception("The Garage is empty.");
            }
        }

        public void InflateWheels(string i_LicensePlate)
        {
            this[i_LicensePlate].GetVehicle.InflatingToMax();
        }
    }
}