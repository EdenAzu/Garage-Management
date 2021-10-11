using System;
using System.Collections.Generic;

// $G$ CSS-018 (-5) You should have used enumerations in the dictionary type data and not const values.

namespace Ex03.GarageLogic
{
    internal static class VehicleParser
    {
        private static string[] s_MissingParams;

        internal static string ParseModel(Dictionary<string, string> i_InitializationDictionary)
        {
            return i_InitializationDictionary["i_Model"];
        }

        internal static string ParseLicencesPlate(Dictionary<string, string> i_InitializationDictionary)
        {
            return i_InitializationDictionary["i_LicensePlate"];
        }

        internal static Motorcycle.eLicenseType LicensesType(Dictionary<string, string> i_InitializationDictionary)
        {
            return ParseEnum<Motorcycle.eLicenseType>(i_InitializationDictionary["i_LicenseType"]);
        }

        internal static Car.eColors Color(Dictionary<string, string> i_InitializationDictionary)
        {
            return ParseEnum<Car.eColors>(i_InitializationDictionary["i_Color"]);
        }

        internal static Car.eDoors NumberOfDoors(Dictionary<string, string> i_InitializationDictionary)
        {
            return ParseEnum<Car.eDoors>(i_InitializationDictionary["i_NumberOfDoors"]);
        }

        internal static int EngineCapacity(Dictionary<string, string> i_InitializationDictionary)
        {
            bool parseSuccessful = int.TryParse(i_InitializationDictionary["i_EngineCapacity"], out int engineCapacity);
            if (!parseSuccessful)
            {
                throw new FormatException("Cannot Parse to engine capacity");
            }

            return engineCapacity;
        }

        internal static float RemainingBatteryTimeInHours(Dictionary<string, string> i_InitializationDictionary)
        {
            bool parseSuccessful = float.TryParse(
                i_InitializationDictionary["i_RemainingBatteryTimeInHours"],
                out float remainingBatteryTimeInHours);
            if (!parseSuccessful)
            {
                throw new FormatException("Cannot Parse to remaining Battery Time In Hours (int)");
            }

            return remainingBatteryTimeInHours;
        }

        internal static float RemainingFuelInLiters(Dictionary<string, string> i_InitializationDictionary)
        {
            bool parseSuccessful = float.TryParse(
                i_InitializationDictionary["i_RemainingFuelInLiters"],
                out float remainingFuelInLiters);
            if (!parseSuccessful)
            {
                throw new FormatException("Cannot Parse to Remaining Fuel In Liters (int)");
            }

            return remainingFuelInLiters;
        }

        internal static bool IsCarryingHazardousMaterials(Dictionary<string, string> i_InitializationDictionary)
        {
            bool parseSuccessful = bool.TryParse(
                i_InitializationDictionary["i_IsCarryingHazardousMaterials"],
                out bool isCarryingHazardousMaterials);
            if (!parseSuccessful)
            {
                throw new FormatException("Cannot Parse to is Carrying Hazardous Materials (True/False)");
            }

            return isCarryingHazardousMaterials;
        }

        internal static float MaximumCarryWeight(Dictionary<string, string> i_InitializationDictionary)
        {
            bool parseSuccessful = float.TryParse(
                i_InitializationDictionary["i_MaximumCarryWeight"],
                out float maximumCarryWeight);
            if (!parseSuccessful)
            {
                throw new FormatException("Cannot Parse to is maximumCarryWeight");
            }

            return maximumCarryWeight;
        }

        public static string[] GetVehicleMissingKeys(string i_VehicleType)
        {
            string[] dictionaryKeys = mapDictionaryKeysToConstructor(i_VehicleType);
            return dictionaryKeys;
        }

        private static string[] mapDictionaryKeysToConstructor(string i_VehicleType)
        {
            List<string> keys = new List<string>() { "i_Model", "i_LicensePlate" };

            bool isElectric = true;
            string[] keysToAdd;

            switch (ParseEnum<VehicleFactory.eVehicleType>(i_VehicleType))
            {
                case VehicleFactory.eVehicleType.GasMotorcycle:
                    isElectric = false;
                    keysToAdd = motorcycleMapDictionaryKeysToConstructor();
                    break;
                case VehicleFactory.eVehicleType.GasCar:
                    isElectric = false;
                    keysToAdd = carMapDictionaryKeysToConstructor();
                    break;
                case VehicleFactory.eVehicleType.GasTruck:
                    isElectric = false;
                    keysToAdd = truckMapDictionaryKeysToConstructor();
                    break;
                case VehicleFactory.eVehicleType.ElectricCar:
                    keysToAdd = carMapDictionaryKeysToConstructor();
                    break;
                case VehicleFactory.eVehicleType.ElectricMotorcycle:
                    keysToAdd = motorcycleMapDictionaryKeysToConstructor();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(i_VehicleType),
                        i_VehicleType,
                        "Cant find Vehicle to create from input");
            }

            foreach (string key in keysToAdd)
            {
                keys.Add(key);
            }

            foreach (string key in wheelMapDictionaryKeysToConstructor())
            {
                keys.Add(key);
            }

            keys.Add(isElectric ? "i_RemainingBatteryTimeInHours" : "i_RemainingFuelInLiters");

            s_MissingParams = keys.ToArray();
            return s_MissingParams;
        }

        private static string[] wheelMapDictionaryKeysToConstructor()
        {
            string[] keys = { "i_WheelPressure", "i_WheelManufacturer" };
            return keys;
        }

        private static string[] carMapDictionaryKeysToConstructor()
        {
            List<string> keys = new List<string>() { "i_Color", "i_NumberOfDoors" };

            return keys.ToArray();
        }

        private static string[] motorcycleMapDictionaryKeysToConstructor()
        {
            List<string> keys = new List<string>() { "i_EngineCapacity", "i_LicenseType" };

            return keys.ToArray();
        }

        private static string[] truckMapDictionaryKeysToConstructor()
        {
            List<string> keys = new List<string>() { "i_IsCarryingHazardousMaterials", "i_MaximumCarryWeight" };

            return keys.ToArray();
        }

        internal static T ParseEnum<T>(string i_Status)
            where T : struct
        {
            bool parseSuccessful = Enum.TryParse(i_Status, out T vehicleStatus);
            string options = "\n";
            foreach (T option in Enum.GetValues(typeof(T)))
            {
                options += option + "\n";
            }

            if (!parseSuccessful)
            {
                throw new FormatException($"Cannot Parse to enum your input : {i_Status}.\nOptions are: {options}");
            }

            return vehicleStatus;
        }

        public static VehicleFactory.eVehicleType ParseVehicleType(string i_VehicleType)
        {
            return ParseEnum<VehicleFactory.eVehicleType>(i_VehicleType);
        }
    }
}