using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricDriveSystem
    {
        private float m_RemainingBatteryTimeInHours;
        private readonly float r_BatteryTimeWhenFullInHours;

        internal ElectricDriveSystem(float i_RemainingBatteryTime, float i_BatteryTimeWhenFull)
        {
            m_RemainingBatteryTimeInHours = i_RemainingBatteryTime;
            r_BatteryTimeWhenFullInHours = i_BatteryTimeWhenFull;
        }

        public void ChargeBattery(float i_TimeToAddToBattery)
        {
            Vehicle.FillSomething(
                r_BatteryTimeWhenFullInHours,
                i_TimeToAddToBattery,
                ref m_RemainingBatteryTimeInHours);
        }

        internal float GetFuelGauge()
        {
            return (m_RemainingBatteryTimeInHours / r_BatteryTimeWhenFullInHours) * 100;
        }

        public override string ToString()
        {
            StringBuilder engineDescription = new StringBuilder();
            engineDescription.AppendFormat(
                "The current remaining Charge in Hours:    {0} {1}",
                m_RemainingBatteryTimeInHours,
                Environment.NewLine);
            engineDescription.AppendFormat(
                "The battery time when full in Hours:    {0} {1}",
                r_BatteryTimeWhenFullInHours,
                Environment.NewLine);

            return engineDescription.ToString();
        }
    }
}