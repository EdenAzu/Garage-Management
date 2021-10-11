using System;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class FuelVehicleInGasoline
    {
        public static void GetDetailsOfVehiclesFuelInGas()
        {
            string licensePlateNumber = null;
            string fuelTypeForRefilling = null;
            string inputQuantityToFill = null;

            Console.WriteLine("Please enter the license plate number of the vehicle that you want to fill in gas: ");
            licensePlateNumber = Console.ReadLine();
            Console.WriteLine("Please enter the fuel type for refilling: ");
            fuelTypeForRefilling = Console.ReadLine();
            Console.WriteLine("Please enter the quantity that you want to fill: ");
            inputQuantityToFill = Console.ReadLine();
            bool parseSuccessful = float.TryParse(inputQuantityToFill, out float quantityToFill);
            if (!parseSuccessful)
            {
                Console.WriteLine($"{inputQuantityToFill} is not a valid float. Please retry");
                GetDetailsOfVehiclesFuelInGas();
            }

            try
            {
                GarageLogic.FillFuel(licensePlateNumber, fuelTypeForRefilling, quantityToFill);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetDetailsOfVehiclesFuelInGas();
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetDetailsOfVehiclesFuelInGas();
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetDetailsOfVehiclesFuelInGas();
            }

            Console.Clear();
            Console.WriteLine("The vehicle was successfully refueled ");
            Thread.Sleep(2000);
        }
    }
}