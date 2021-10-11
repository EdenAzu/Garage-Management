using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_IsCarryingHazardousMaterials;
        private readonly float r_MaximumCarryWeight;
        internal const float k_MaximumWheelPressure = 26;
        internal const int k_NumberOfWheels = 16;
        internal const float k_MaximumFuelTankCapacity = 120f;
        internal const InternalCombustionDriveSystem.eFuelType k_FuelType =
            InternalCombustionDriveSystem.eFuelType.Soler;

        internal Truck(
            string i_Model,
            string i_LicensePlate,
            Wheel[] i_Wheels,
            bool i_IsCarryingHazardousMaterials,
            float i_MaximumCarryWeight,
            InternalCombustionDriveSystem i_InternalCombustionDriveSystem)
            : base(i_Model, i_LicensePlate, i_Wheels, i_InternalCombustionDriveSystem)
        {
            r_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            r_MaximumCarryWeight = i_MaximumCarryWeight;
        }

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder truckDescription = new StringBuilder();
            string hazardousMaterials = r_IsCarryingHazardousMaterials ? "yes" : "no";
            truckDescription.AppendFormat(
                "Transport hazardous materials:  {0} {1}",
                hazardousMaterials,
                Environment.NewLine);
            truckDescription.AppendFormat(
                "Maximum carrying weight:        {0} {1}",
                r_MaximumCarryWeight,
                Environment.NewLine);

            vehicleDescription += truckDescription.ToString();
            return vehicleDescription;
        }
    }
}