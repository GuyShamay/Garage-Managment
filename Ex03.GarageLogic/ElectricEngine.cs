namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBattery) : base(i_MaxBattery)
        {
        }

        public void ChargeBattery(float i_BatteryToAdd)
        {
            this.AddEnergy(i_BatteryToAdd);
        }
    }
}