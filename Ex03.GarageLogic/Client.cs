using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Client
    {
        private readonly string r_Name;
        private readonly string r_Phone;

        internal eVehicleStatus VehicleStatus { get; set; }

        internal Vehicle Vehicle { get; }

        internal enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        internal Client(string i_Phone, string i_Name, eVehicleStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            r_Phone = i_Phone;
            r_Name = i_Name;
            VehicleStatus = i_VehicleStatus;
            Vehicle = i_Vehicle;
        }

        internal string GetLicensePlate()
        {
            return Vehicle.LicensePlate;
        }

        public override string ToString()
        {
            StringBuilder clientDescription = new StringBuilder();
            clientDescription.AppendFormat("Owner name:         {0} {1}", r_Name, Environment.NewLine);
            clientDescription.AppendFormat("Owner phone number: {0} {1}", r_Phone, Environment.NewLine);
            clientDescription.AppendFormat(
                "Vehicle status:     {0} {1}",
                VehicleStatus.ToString(),
                Environment.NewLine);
            return clientDescription + Vehicle.ToString();
        }
    }
}