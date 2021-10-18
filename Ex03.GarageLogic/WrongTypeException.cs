using System;

namespace Ex03.GarageLogic
{
    public class WrongTypeException : Exception
    {
        private readonly string r_TypeOf;

        public WrongTypeException(string i_TypeOf) : base(string.Format("An error occurred, while entering a wrong type of : {0}", i_TypeOf))
        {
            r_TypeOf = i_TypeOf;
        }
    }
}
