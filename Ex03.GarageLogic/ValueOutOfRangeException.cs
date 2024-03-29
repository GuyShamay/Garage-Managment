﻿using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
        
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("An error occurred, the value is out of  the range: {0} - {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
