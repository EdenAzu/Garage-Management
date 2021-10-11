using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class InternalCombustionDriveSystem
    {
        private readonly eFuelType r_FuelType;
        private float m_RemainingFuelInLiters;
        private readonly float r_MaxFuelCapacityInLiters;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        internal InternalCombustionDriveSystem(
            float i_RemainingFuelInLiters,
            float i_MaxFuelCapacityInLiters,
            eFuelType i_FuelType)
        {
            m_RemainingFuelInLiters = i_RemainingFuelInLiters;
            r_MaxFuelCapacityInLiters = i_MaxFuelCapacityInLiters;
            r_FuelType = i_FuelType;
        }

        internal float GetFuelGauge()
        {
            return (m_RemainingFuelInLiters / r_MaxFuelCapacityInLiters) * 100;
        }

        public void FillFuelTank(eFuelType i_FuelType, float i_AmountToFillInLiters)
        {
            if (i_FuelType == r_FuelType)
            {
                Vehicle.FillSomething(r_MaxFuelCapacityInLiters, i_AmountToFillInLiters, ref m_RemainingFuelInLiters);
            }
            else
            {
                throw new ArgumentException(
                    $"Wrong Fuel Type, Expected {r_FuelType.ToString()} and got {i_FuelType.ToString()}");
            }
        }

        public override string ToString()
        {
            StringBuilder engineDescription = new StringBuilder();
            engineDescription.AppendFormat("Fuel type:     {0} {1}", r_FuelType, Environment.NewLine);
            engineDescription.AppendFormat(
                "The current amount of fuel in liters:    {0} {1}",
                m_RemainingFuelInLiters,
                Environment.NewLine);
            engineDescription.AppendFormat(
                "The maximum amount of fuel in liters:    {0} {1}",
                r_MaxFuelCapacityInLiters,
                Environment.NewLine);

            return engineDescription.ToString();
        }
    }
}