using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_Pressure;
        private readonly float r_MaxPressure;

        public Wheel(float i_MaxPressure, float i_Pressure, string i_Manufacturer)
        {
            r_MaxPressure = i_MaxPressure;
            m_Pressure = i_Pressure;
            r_Manufacturer = i_Manufacturer;
        }

        public void InflateWheel()
        {
            m_Pressure = r_MaxPressure;
        }

        internal static string[] MapDictionaryKeysToConstructor()
        {
            string[] keys = { "i_WheelPressure", "i_WheelManufacturer" };
            return keys;
        }

        public override string ToString()
        {
            StringBuilder wheelDescription = new StringBuilder();
            wheelDescription.AppendFormat("Wheel Description:      {0}", Environment.NewLine);
            wheelDescription.AppendFormat("Manufacturer name:      {0} {1}", r_Manufacturer, Environment.NewLine);
            wheelDescription.AppendFormat("Current air pressure:   {0} {1}", m_Pressure, Environment.NewLine);
            wheelDescription.AppendFormat("Maximum air pressure:   {0} {1}", r_MaxPressure, Environment.NewLine);

            return wheelDescription.ToString();
        }
    }
}