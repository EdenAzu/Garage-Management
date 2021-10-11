using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private readonly string r_Model;
        private float m_RemainingEnergySource;
        private readonly Wheel[] r_Wheels;
        private readonly InternalCombustionDriveSystem r_InternalCombustionDriveSystem = null;
        private readonly ElectricDriveSystem r_ElectricDriveSystem = null;

        internal string LicensePlate { get; }

        protected Vehicle(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            InternalCombustionDriveSystem i_InternalCombustionDriveSystem)
        {
            r_Model = i_Model;
            LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            r_InternalCombustionDriveSystem = i_InternalCombustionDriveSystem;
            m_RemainingEnergySource = r_InternalCombustionDriveSystem.GetFuelGauge();
        }

        protected Vehicle(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            ElectricDriveSystem i_ElectricDriveSystem)
        {
            r_Model = i_Model;
            LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            r_ElectricDriveSystem = i_ElectricDriveSystem;
            m_RemainingEnergySource = r_ElectricDriveSystem.GetFuelGauge();
        }

        internal static void FillSomething(
            float i_MaxValue,
            float i_AmountToAdd,
            ref float io_ToFillIn,
            float i_MinVale = 0)
        {
            if (io_ToFillIn + i_AmountToAdd <= i_MaxValue)
            {
                io_ToFillIn += i_AmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(i_MinVale, i_MaxValue);
            }
        }

        internal void FillFuelTank(InternalCombustionDriveSystem.eFuelType i_FuelType, float i_AmountToFillInLiters)
        {
            if (r_InternalCombustionDriveSystem != null)
            {
                r_InternalCombustionDriveSystem.FillFuelTank(i_FuelType, i_AmountToFillInLiters);
                m_RemainingEnergySource = r_InternalCombustionDriveSystem.GetFuelGauge();
            }
            else
            {
                throw new ArgumentException(
                    $"This vehicle ({r_Model}) does not contain Internal Combustion Drive System");
            }
        }

        internal void ChargeBattery(float i_AmountToChargeInMinutes)
        {
            if (r_ElectricDriveSystem != null)
            {
                r_ElectricDriveSystem.ChargeBattery(convertMinutesToHours(i_AmountToChargeInMinutes));
                m_RemainingEnergySource = r_ElectricDriveSystem.GetFuelGauge();
            }
            else
            {
                throw new ArgumentException(
                    $"This vehicle ({r_Model}) does not contain Electric Drive System and therefore cannot charge");
            }
        }

        private static float convertMinutesToHours(float i_AmountToChargeInMinutes)
        {
            return i_AmountToChargeInMinutes / 60f;
        }

        public override string ToString()
        {
            StringBuilder vehicleDescription = new StringBuilder();
            vehicleDescription.AppendLine("Vehicle description : ");
            vehicleDescription.AppendFormat("Vehicle Model          {0} {1}", r_Model, Environment.NewLine);
            vehicleDescription.AppendFormat("License plate number: {0} {1}", LicensePlate, Environment.NewLine);
            vehicleDescription.AppendFormat(
                "Energy left :{0:00.00}% {1}",
                m_RemainingEnergySource,
                Environment.NewLine);
            vehicleDescription.AppendFormat(r_Wheels[0].ToString());
            vehicleDescription.AppendFormat(
                r_InternalCombustionDriveSystem != null
                    ? r_InternalCombustionDriveSystem.ToString()
                    : r_ElectricDriveSystem.ToString());

            return vehicleDescription.ToString();
        }

        internal void InflateTyresToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateWheel();
            }
        }
    }
}