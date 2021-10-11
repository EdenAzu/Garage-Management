using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    internal static class VehicleFactory
    {
        internal enum eVehicleType
        {
            GasMotorcycle,
            GasCar,
            GasTruck,
            ElectricCar,
            ElectricMotorcycle
        }

        // $G$ DSN-007 (-5) This method is too long, it should have been split into several methods.
        public static Vehicle CreateVehicle(string i_VehicleType, Dictionary<string, string> i_InitializationDictionary)
        {
            eVehicleType vehicleType = VehicleParser.ParseVehicleType(i_VehicleType);
            Wheel[] vehicleWheels = wheelFactory(vehicleType, i_InitializationDictionary);
            Vehicle newVehicle;
            InternalCombustionDriveSystem internalCombustionDriveSystem;
            ElectricDriveSystem electricDriveSystem;
            int engineCapacity;
            Motorcycle.eLicenseType licensesType;
            Car.eDoors doors;
            Car.eColors color;
            float remainingBattery;
            float remainingFuel;

            string model = VehicleParser.ParseModel(i_InitializationDictionary);
            string licencesPlate = VehicleParser.ParseLicencesPlate(i_InitializationDictionary);
            switch (vehicleType)
            {
                case eVehicleType.GasMotorcycle:
                    remainingFuel = VehicleParser.RemainingFuelInLiters(i_InitializationDictionary);
                    licensesType = VehicleParser.LicensesType(i_InitializationDictionary);
                    engineCapacity = VehicleParser.EngineCapacity(i_InitializationDictionary);
                    internalCombustionDriveSystem = new InternalCombustionDriveSystem(
                        remainingFuel,
                        Motorcycle.k_MaximumFuelTankCapacity,
                        Motorcycle.k_FuelType);

                    newVehicle = new Motorcycle(
                        model,
                        licencesPlate,
                        vehicleWheels,
                        engineCapacity,
                        licensesType,
                        internalCombustionDriveSystem);
                    break;
                case eVehicleType.GasCar:
                    remainingFuel = VehicleParser.RemainingFuelInLiters(i_InitializationDictionary);
                    color = VehicleParser.Color(i_InitializationDictionary);
                    doors = VehicleParser.NumberOfDoors(i_InitializationDictionary);
                    internalCombustionDriveSystem = new InternalCombustionDriveSystem(
                        remainingFuel,
                        Car.k_MaximumFuelTankCapacity,
                        Car.k_FuelType);
                    newVehicle = new Car(
                        model,
                        licencesPlate,
                        vehicleWheels,
                        internalCombustionDriveSystem,
                        color,
                        doors);
                    break;
                case eVehicleType.GasTruck:
                    bool isCarryingHazardousMaterials =
                        VehicleParser.IsCarryingHazardousMaterials(i_InitializationDictionary);
                    float maximumCarryWeight = VehicleParser.MaximumCarryWeight(i_InitializationDictionary);
                    remainingFuel = VehicleParser.RemainingFuelInLiters(i_InitializationDictionary);
                    internalCombustionDriveSystem = new InternalCombustionDriveSystem(
                        remainingFuel,
                        Truck.k_MaximumFuelTankCapacity,
                        Truck.k_FuelType);
                    newVehicle = new Truck(
                        model,
                        licencesPlate,
                        vehicleWheels,
                        isCarryingHazardousMaterials,
                        maximumCarryWeight,
                        internalCombustionDriveSystem);
                    break;
                case eVehicleType.ElectricCar:
                    color = VehicleParser.Color(i_InitializationDictionary);
                    doors = VehicleParser.NumberOfDoors(i_InitializationDictionary);
                    remainingBattery = VehicleParser.RemainingBatteryTimeInHours(i_InitializationDictionary);
                    electricDriveSystem = new ElectricDriveSystem(remainingBattery, Car.k_MaximumBatteryCapacity);
                    newVehicle = new Car(model, licencesPlate, vehicleWheels, electricDriveSystem, color, doors);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    licensesType = VehicleParser.LicensesType(i_InitializationDictionary);
                    engineCapacity = VehicleParser.EngineCapacity(i_InitializationDictionary);
                    remainingBattery = VehicleParser.RemainingBatteryTimeInHours(i_InitializationDictionary);
                    electricDriveSystem = new ElectricDriveSystem(
                        remainingBattery,
                        Motorcycle.k_MaximumBatteryCapacity);
                    newVehicle = new Motorcycle(
                        model,
                        licencesPlate,
                        vehicleWheels,
                        engineCapacity,
                        licensesType,
                        electricDriveSystem);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(i_VehicleType),
                        i_VehicleType,
                        "Cant find Vehicle to create from input");
            }

            return newVehicle;
        }

        private static Wheel[] wheelFactory(
            eVehicleType i_VehicleType,
            Dictionary<string, string> i_InitializationDictionary)
        {
            LinkedList<Wheel> wheels = new LinkedList<Wheel>();
            bool parseSuccessful = float.TryParse(
                i_InitializationDictionary[Wheel.MapDictionaryKeysToConstructor()[0]],
                out float wheelPressure);
            if (!parseSuccessful)
            {
                throw new FormatException("Could not Parse wheel pressure");
            }

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.GasMotorcycle:
                    for (int i = 0; i < Motorcycle.k_NumberOfWheels; i++)
                    {
                        wheels.AddFirst(
                            new Wheel(
                                Motorcycle.k_MaximumWheelPressure,
                                wheelPressure,
                                i_InitializationDictionary[Wheel.MapDictionaryKeysToConstructor()[1]]));
                    }

                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.GasCar:
                    for (int i = 0; i < Car.k_NumberOfWheels; i++)
                    {
                        wheels.AddFirst(
                            new Wheel(
                                Car.k_MaximumWheelPressure,
                                wheelPressure,
                                i_InitializationDictionary[Wheel.MapDictionaryKeysToConstructor()[1]]));
                    }

                    break;
                case eVehicleType.GasTruck:
                    for (int i = 0; i < Truck.k_NumberOfWheels; i++)
                    {
                        wheels.AddFirst(
                            new Wheel(
                                Truck.k_MaximumWheelPressure,
                                wheelPressure,
                                i_InitializationDictionary[Wheel.MapDictionaryKeysToConstructor()[1]]));
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(i_VehicleType),
                        i_VehicleType,
                        "Cant find Vehicle to create from input");
            }

            return wheels.ToArray();
        }
    }
}