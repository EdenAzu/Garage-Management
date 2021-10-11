using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly int r_EngineCapacity;
        private readonly eLicenseType r_LicenseType;
        internal const float k_MaximumWheelPressure = 30f;
        internal const int k_NumberOfWheels = 2;
        internal const InternalCombustionDriveSystem.eFuelType k_FuelType =
            InternalCombustionDriveSystem.eFuelType.Octan98;
        internal const float k_MaximumFuelTankCapacity = 6f;
        internal const float k_MaximumBatteryCapacity = 1.8f;

        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }

        public Motorcycle(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            int i_EngineCapacity,
            eLicenseType i_LicenseType,
            InternalCombustionDriveSystem i_InternalCombustionDriveSystem)
            : base(i_Model, i_LicensePlate, i_Wheels, i_InternalCombustionDriveSystem)
        {
            r_EngineCapacity = i_EngineCapacity;
            r_LicenseType = i_LicenseType;
        }

        public Motorcycle(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            int i_EngineCapacity,
            eLicenseType i_LicenseType,
            ElectricDriveSystem i_ElectricDriveSystem)
            : base(i_Model, i_LicensePlate, i_Wheels, i_ElectricDriveSystem)
        {
            r_EngineCapacity = i_EngineCapacity;
            r_LicenseType = i_LicenseType;
        }

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder motorcycleDescription = new StringBuilder();
            motorcycleDescription.AppendFormat("Type license:  {0} {1}", r_LicenseType, Environment.NewLine);
            motorcycleDescription.AppendFormat("Engine volume in cc: {0} {1}", r_EngineCapacity, Environment.NewLine);
            vehicleDescription += motorcycleDescription.ToString();
            return vehicleDescription;
        }
    }
}