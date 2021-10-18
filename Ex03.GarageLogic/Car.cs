namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected eDoors m_NumOfDoors;

        protected Car(int i_NumOfWheels, float i_MaxAP) : base(i_NumOfWheels, i_MaxAP)
        {
        }

        public override string ToString()
        {
            string carToString = string.Format(@"{0}{1}
Number Of Doors: {2}, Car's Color: {3}", base.ToString(), VehicleEngine.ToString(), this.Doors, this.Color);

            return carToString;
        }

        public eCarColor Color
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public eDoors Doors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }
    }
}
