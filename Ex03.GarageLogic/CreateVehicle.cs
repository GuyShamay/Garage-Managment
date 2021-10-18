namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        public static Vehicle Create(eVehicleType i_VehicleType)
        {
            Vehicle myVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.GasMotorcycle:
                    myVehicle = new GasMotorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    myVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.GasCar:
                    myVehicle = new GasCar();
                    break;
                case eVehicleType.ElectricCar:
                    myVehicle = new ElectricCar();
                    break;
                case eVehicleType.Truck:
                    myVehicle = new Truck();
                    break;
            }

            return myVehicle;
        }
    }
}