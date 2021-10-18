using System;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private enum eEnergyType
        {
            Electric = 1,
            Gas
        }

        private enum eGetWheels
        {
            OneByOne = 1, 
            AllByOne
        }

        private enum eMenuChoice
        {
            AddVehicle = 1,
            ShowLicense,
            ChangeStatus,
            Inflate,
            Refuel,
            Recharge,
            ShowData, 
            Exit
        }

        public static void Manage()
        {
            bool exitGarage = false;
            Garage myGarage = new Garage();

            while (!exitGarage)
            {
                eMenuChoice choice = menu(getMainMenuString(), 8);

                try
                {
                    switch (choice)
                    {
                        case eMenuChoice.AddVehicle:
                            addVehicle(myGarage);
                            break;
                        case eMenuChoice.ShowLicense:
                            showLicenses(myGarage);
                            break;
                        case eMenuChoice.ChangeStatus:
                            changeVehicleStatus(myGarage);
                            break;
                        case eMenuChoice.Inflate:
                            inflateWheels(myGarage);
                            break;
                        case eMenuChoice.Refuel:
                            addEnergy(myGarage, eEnergyType.Gas);
                            break;
                        case eMenuChoice.Recharge:
                            addEnergy(myGarage, eEnergyType.Electric);
                            break;
                        case eMenuChoice.ShowData:
                            showVehicleData(myGarage);
                            break;
                        case eMenuChoice.Exit:
                            exitGarage = true;
                            break;
                    }
                }
                catch (WrongTypeException wtex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(wtex.Message);
                }
                catch (ValueOutOfRangeException vorex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(vorex.Message);
                }
                catch (Exception ex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(ex.Message);
                }
            }
        }

        private static void addVehicle(Garage io_MyGarage)
        {
            ConsoleIO.PrintStr("Add Vehicle:");
            if(isVehicleInGarage(io_MyGarage, out string licensePlate))
            {
                io_MyGarage[licensePlate].Status = eGarageVehicleStatus.InWorkshop;
                ConsoleIO.Clear();
                ConsoleIO.PrintStr("Vehicle already exist, and its status changed to - 'InWorkshop'.");
            }
            else
            {
                addNewVehicle(io_MyGarage, licensePlate);
                ConsoleIO.Clear();
                ConsoleIO.PrintStr(string.Format("{0} added successfully.", io_MyGarage[licensePlate].GetVehicle.GetType().Name));
            }
        }

        private static void addNewVehicle(Garage io_MyGarage, string i_LicenseNum)
        {
            eVehicleType myVehicleType;
            bool addSuccess = false;

            myVehicleType = (eVehicleType)ConsoleIO.ChooseEnum(typeof(eVehicleType));
            GarageVehicle myGarageVehicle = new GarageVehicle(myVehicleType);
            updateVehicleData(myGarageVehicle, i_LicenseNum);
            updateWheels(myGarageVehicle);
            while (!addSuccess)
            {
                try
                {
                    updateRemainingFuel(myGarageVehicle);
                    updateSpecificVehicleFeatures(myGarageVehicle, myVehicleType);
                    addSuccess = true;
                }
                catch (Exception ex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(ex.Message);
                    if (ex.InnerException != null)
                    {
                        ConsoleIO.PrintStr(ex.InnerException.Message);
                    }
                }
            }

            io_MyGarage.VehicleList.Add(i_LicenseNum, myGarageVehicle);
        }

        private static void showLicenses(Garage io_MyGarage)
        {
            int secondChoice;

            ConsoleIO.PrintStr("Show Vehicles by status:");
            secondChoice = ConsoleIO.ChooseEnum(typeof(eGarageVehicleStatus));
            io_MyGarage.ShowLicenses(secondChoice);
            ConsoleIO.Pause();
        }

        private static void inflateWheels(Garage io_MyGarage)
        {
            ConsoleIO.PrintStr("Inflate Wheels To Max:");
            if (isVehicleInGarage(io_MyGarage, out string licensePlate))
            {
                io_MyGarage.InflateWheels(licensePlate);
            }
            else
            {
                throw new Exception("Vehicle doesn't exist in garage.");
            }

            ConsoleIO.Clear();
            ConsoleIO.PrintStr("Vehicle wheels were successfully inflated to maximum air pressure");
        }

        private static eMenuChoice menu(string i_Menu, int i_maxRange)
        {
            int choice;

            ConsoleIO.PrintStr(i_Menu);
            choice = ConsoleIO.GetChoiceWithRange(1, i_maxRange);
            ConsoleIO.Clear();
            return (eMenuChoice)choice;
        }

        private static string getMainMenuString()
        {
            return string.Format(@"
Main Garage Menu:

1. Add vehicle
2. Show License Number of all vehicles.
3. Change vehicle status.
4. Inflating wheels to max air pressure.
5. Refuel.
6. Recharge.
7. Show vehicle data.
8. Exit");
        }

        private static void updateOwner(GarageVehicle io_GarVehicle)
        {
            string ownerName, ownerPhone;

            ConsoleIO.PrintStr("Enter Owner's name:");
            ownerName = ConsoleIO.GetName();
            ConsoleIO.PrintStr("Enter Owner's phone number:");
            ownerPhone = ConsoleIO.GetNumberAsString();
            io_GarVehicle.UpdateOwner(ownerName, ownerPhone);
        }

        private static string getModel(GarageVehicle io_GarVehicle)
        {
            ConsoleIO.PrintStr("Enter Vehicle's Model:");
           return ConsoleIO.GetName();
        }
        
        private static void updateVehicleData(GarageVehicle io_GarVehicle, string i_LicenseNum)
        {
            string modelName;

            updateOwner(io_GarVehicle);
            modelName = getModel(io_GarVehicle);
            io_GarVehicle.InitVehicle(modelName, i_LicenseNum);
        }
        
        private static void updateSpecificVehicleFeatures(GarageVehicle io_GarageVehicle, eVehicleType i_VehicleType)
        {
            StringBuilder fieldNameSB = new StringBuilder();

            Type vehicleType = io_GarageVehicle.GetVehicle.GetType();
            foreach (FieldInfo field in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (!field.IsLiteral)
                {
                    fieldNameSB.Clear();
                        fieldNameSB.Append(field.Name);
                        fieldNameSB.Remove(0, 2);
                    if (field.FieldType.IsEnum)
                    {
                        ConsoleIO.PrintStr(string.Format("{0}:", fieldNameSB));
                        field.SetValue(io_GarageVehicle.GetVehicle, ConsoleIO.ChooseEnum(field.FieldType));
                    }
                    
                    if (field.FieldType == typeof(bool))
                    {
                        ConsoleIO.PrintStr(string.Format("{0}? 0 - No, 1 - Yes", fieldNameSB));
                        field.SetValue(io_GarageVehicle.GetVehicle, ConsoleIO.GetBooleanChoice());
                    }
                    else if (field.FieldType == typeof(int))
                    {
                        ConsoleIO.PrintStr(string.Format("Enter {0}:", fieldNameSB));
                        field.SetValue(io_GarageVehicle.GetVehicle, ConsoleIO.StringToInt());
                    }
                    else if (field.FieldType == typeof(float) || field.FieldType == typeof(double))
                    {
                        ConsoleIO.PrintStr(string.Format("Enter {0}:", fieldNameSB));
                        field.SetValue(io_GarageVehicle.GetVehicle, ConsoleIO.GetFloat());
                    }
                }
            }
        }

        private static void updateRemainingFuel(GarageVehicle io_GarVehicle)
        {
            float remainingEnergy;

            ConsoleIO.PrintStr("Enter Amount of remaining energy:");
            remainingEnergy = ConsoleIO.GetFloat();
            io_GarVehicle.RemainingEnergy = remainingEnergy;
        }

        private static void updateWheels(GarageVehicle io_GarVehicle)
        {
            eGetWheels getWheelsChoice;

            ConsoleIO.PrintStr("How do you want to update Wheels?");
            getWheelsChoice = (eGetWheels) ConsoleIO.ChooseEnum(typeof(eGetWheels));
            switch (getWheelsChoice)
            {
                case eGetWheels.OneByOne:
                    getWheelsOneByOne(io_GarVehicle);
                    break;
                case eGetWheels.AllByOne:
                    getWheelsAllByOne(io_GarVehicle);
                    break;
            }
        }

        private static void getWheelsAllByOne(GarageVehicle io_GarVehicle)
        {
            string manufacturerName;
            float currentAP, maxAP;
            bool addWheelSuccess = false;

            while (!addWheelSuccess)
            {
                ConsoleIO.PrintStr("Manufacturer Name:");
                manufacturerName = ConsoleIO.GetName();
                ConsoleIO.PrintStr("Max Air Pressure:");
                maxAP = ConsoleIO.GetFloat();
                ConsoleIO.PrintStr("Current Air Pressure:");
                currentAP = ConsoleIO.GetFloat();
                try
                {
                    io_GarVehicle.AddSameWheelForAll(manufacturerName, currentAP, maxAP);
                    addWheelSuccess = true;
                }
                catch (ValueOutOfRangeException vorex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(vorex.Message);
                }
            }
        }

        private static void getWheelsOneByOne(GarageVehicle io_GarVehicle)
        {
            string manufacturerName;
            float currentAP, maxAP;
            bool addOneWheelSuccess = false;
            for (int i = 0; i < io_GarVehicle.GetVehicle.NumberOfWheels; i++, addOneWheelSuccess = false)
            {
                while (!addOneWheelSuccess)
                {
                    ConsoleIO.PrintStr("Manufacturer Name:");
                    manufacturerName = ConsoleIO.GetName();
                    ConsoleIO.PrintStr("Max Air Pressure:");
                    maxAP = ConsoleIO.GetFloat();
                    ConsoleIO.PrintStr("Current Air Pressure:");
                    currentAP = ConsoleIO.GetFloat();
                    try
                    {
                        io_GarVehicle.AddWheel(manufacturerName, currentAP, maxAP);
                        addOneWheelSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        ConsoleIO.Clear();
                        ConsoleIO.PrintStr(ex.Message);
                        if (ex.InnerException != null)
                        {
                            ConsoleIO.PrintStr(ex.InnerException.Message);
                        }
                    }
                }
            }
        }
       
        private static void addEnergy(Garage io_MyGarage, eEnergyType i_EnergyType)
        {
            ConsoleIO.PrintStr("Add energy to vehicle:");
            if (isVehicleInGarage(io_MyGarage, out string licensePlate))
            {
                switch (i_EnergyType)
                {
                    case eEnergyType.Electric:
                        reChargeVehicle(io_MyGarage, licensePlate);
                        break;
                    case eEnergyType.Gas:
                        reFuelVehicle(io_MyGarage, licensePlate);
                        break;
                }
            }
            else
            {
                throw new Exception("Vehicle doesn't exist in garage.");
            }
        }

        private static void changeVehicleStatus(Garage io_MyGarage)
        {
            ConsoleIO.PrintStr("Change Vehicle's status:");
            if (isVehicleInGarage(io_MyGarage, out string licensePlate))
            {
                eGarageVehicleStatus newVehicleStatus =
                    (eGarageVehicleStatus) ConsoleIO.ChooseEnum(typeof(eGarageVehicleStatus));

                io_MyGarage[licensePlate].Status = newVehicleStatus;
                ConsoleIO.Clear();
                ConsoleIO.PrintStr("Vehicle's Status changed successfully!");
            }
            else
            {
                throw new Exception("Vehicle doesn't exist in garage.");
            }
        }

        private static void reChargeVehicle(Garage io_MyGarage, string i_LicensePlate)
        {
            float minutesToCharge;

            if (io_MyGarage[i_LicensePlate].GetVehicle.VehicleEngine is ElectricEngine)
            {
                ConsoleIO.PrintStr("Insert the amount of minutes to charge: ");
                minutesToCharge = ConsoleIO.GetFloat();
                try
                {
                    (io_MyGarage[i_LicensePlate].GetVehicle.VehicleEngine as ElectricEngine).ChargeBattery(
                        ConsoleIO.MinutesToHours(minutesToCharge));
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr("The vehicle was successfully charged ");
                }
                catch (ValueOutOfRangeException vorex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(vorex.Message);
                }
            }
            else
            {
                throw new WrongTypeException("Engine");
            }
        }

        private static void reFuelVehicle(Garage io_MyGarage, string i_LicensePlate)
        {   
            float literToFuel;

            if (io_MyGarage[i_LicensePlate].GetVehicle.VehicleEngine is GasEngine)
            {
                ConsoleIO.PrintStr("Insert the amount of liters to fuel: ");
                literToFuel = ConsoleIO.GetFloat();
                ConsoleIO.PrintStr("Enter Fuel Type:");
                eFuelType fuelType = (eFuelType)ConsoleIO.ChooseEnum(typeof(eFuelType));
                try
                {
                    (io_MyGarage[i_LicensePlate].GetVehicle.VehicleEngine as GasEngine).Refuel(literToFuel, fuelType);
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr("The vehicle was successfully refueled.");
                }
                catch (ValueOutOfRangeException vorex)
                {
                    ConsoleIO.Clear();
                    ConsoleIO.PrintStr(vorex.Message);
                }
            }
            else
            {
                throw new WrongTypeException("Engine");
            }
        }

        private static void showVehicleData(Garage io_MyGarage)
        {
            ConsoleIO.PrintStr("Show Vehicle Data:");
            if (isVehicleInGarage(io_MyGarage, out string LicensePlate))
            {
                ConsoleIO.PrintStr(io_MyGarage[LicensePlate].ToString());
                ConsoleIO.Pause();
            }
            else
            {
                throw new Exception("Vehicle doesn't exist in garage.");
            }
        }

        private static bool isVehicleInGarage(Garage io_MyGarage, out string io_LicensePlate)
        {
            ConsoleIO.PrintStr("Please insert the vehicle license plate number: ");

            io_LicensePlate = ConsoleIO.GetLicensePlate();

            return io_MyGarage.Find(io_LicensePlate);
        }
    }
}
