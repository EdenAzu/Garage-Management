using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public static class GarageLogic
    {
        private static readonly List<Client> sr_Clients = new List<Client>();
        private const Client.eVehicleStatus k_DefaultNewVehicleStatus = Client.eVehicleStatus.InRepair;

        public static void InsertNewVehicleToGarage(
            string i_VehicleType,
            string i_ClientName,
            string i_ClientPhone,
            Dictionary<string, string> i_VehicleInitializationDictionary)
        {
            Vehicle newVehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_VehicleInitializationDictionary);
            validateVehicleIsNotAlreadyInSystem(newVehicle.LicensePlate);
            sr_Clients.Add(
                new Client(
                    i_ClientPhone,
                    i_ClientName,
                    k_DefaultNewVehicleStatus,
                    newVehicle));
        }

        private static bool validateVehicleIsNotAlreadyInSystem(string i_NewVehicleLicensePlate)
        {
            try
            {
                findClientByLicensesPlate(i_NewVehicleLicensePlate);
            }
            catch (ArgumentException e)
            {
                return true;
            }

            throw new ArgumentException("A car with same license plate is all ready in the system");
        }

        public static string[] GetVehicleParamsNeededFromUser(string i_VehicleType)
        {
            return VehicleParser.GetVehicleMissingKeys(i_VehicleType);
        }

        public static string[] GetLicensePlates()
        {
            LinkedList<string> licensePlates = new LinkedList<string>();
            foreach (Client client in sr_Clients)
            {
                licensePlates.AddLast(client.GetLicensePlate());
            }

            return licensePlates.ToArray();
        }

        public static string[] GetLicensePlatesByStatus(string i_Status)
        {
            return filterByVehicleStatus(VehicleParser.ParseEnum<Client.eVehicleStatus>(i_Status)).ToArray();
        }

        public static void SetVehicleStatus(string i_LicensesPlate, string i_Status)
        {
            findClientByLicensesPlate(i_LicensesPlate).VehicleStatus =
                VehicleParser.ParseEnum<Client.eVehicleStatus>(i_Status);
        }

        public static void InflateTyresToMax(string i_LicensesPlate)
        {
            findClientByLicensesPlate(i_LicensesPlate).Vehicle.InflateTyresToMax();
        }

        public static void FillFuel(string i_LicensesPlate, string i_FuelType, float i_AmountToFill)
        {
            findClientByLicensesPlate(i_LicensesPlate)
                .Vehicle.FillFuelTank(
                    VehicleParser.ParseEnum<InternalCombustionDriveSystem.eFuelType>(i_FuelType),
                    i_AmountToFill);
        }

        public static void Charge(string i_LicensesPlate, float i_AmountToChargeInMinutes)
        {
            findClientByLicensesPlate(i_LicensesPlate).Vehicle.ChargeBattery(i_AmountToChargeInMinutes);
        }

        public static string GetVehicleFullDetails(string i_LicensesPlate)
        {
            return findClientByLicensesPlate(i_LicensesPlate).ToString();
        }

        private static LinkedList<string> filterByVehicleStatus(Client.eVehicleStatus i_VehicleStatus)
        {
            LinkedList<string> licensePlates = new LinkedList<string>();

            foreach (Client client in sr_Clients)
            {
                if (client.VehicleStatus == i_VehicleStatus) licensePlates.AddFirst(client.GetLicensePlate());
            }

            return licensePlates;
        }

        private static Client findClientByLicensesPlate(string i_LicensesPlate)
        {
            Client outputClient = null;

            foreach (Client client in sr_Clients)
            {
                if (client.GetLicensePlate() == i_LicensesPlate)
                {
                    outputClient = client;
                }
            }

            if (outputClient == null)
            {
                throw new ArgumentException("Didn't find License Plate");
            }

            return outputClient;
        }
    }
}