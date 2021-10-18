namespace Ex03.GarageLogic
{
    public struct Owner
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;

        public Owner(string i_Name, string i_PhoneNumber)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            string ownerToString = string.Format("Owner's Name: {0}, Phone Number: {1}", r_Name, r_PhoneNumber);

            return ownerToString;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }
    }
}