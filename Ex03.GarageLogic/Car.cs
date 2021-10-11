using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eColors r_Color;
        private readonly eDoors r_NumberOfDoors;
        internal const float k_MaximumBatteryCapacity = 3.2f;
        internal const int k_NumberOfWheels = 4;
        internal const float k_MaximumWheelPressure = 32f;
        internal const float k_MaximumFuelTankCapacity = 45f;
        internal const InternalCombustionDriveSystem.eFuelType k_FuelType =
            InternalCombustionDriveSystem.eFuelType.Octan95;

        internal Car(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            InternalCombustionDriveSystem i_InternalCombustionDriveSystem,
            eColors i_Color,
            eDoors i_NumberOfDoors)
            : base(i_Model, i_LicensePlate, i_Wheels, i_InternalCombustionDriveSystem)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        internal Car(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            ElectricDriveSystem i_ElectricDriveSystem,
            eColors i_Color,
            eDoors i_NumberOfDoors)
            : base(i_Model, i_LicensePlate, i_Wheels, i_ElectricDriveSystem)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        internal enum eColors
        {
            Red,
            Silver,
            White,
            Black
        }

        public enum eDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder carDescription = new StringBuilder();
            carDescription.AppendFormat("Doors color:   {0} {1}", r_Color, Environment.NewLine);
            carDescription.AppendFormat("Number of doors:  {0} {1}", r_NumberOfDoors, Environment.NewLine);
            vehicleDescription += carDescription.ToString();
            return vehicleDescription;
        }
    }
}