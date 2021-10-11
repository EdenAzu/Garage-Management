using System;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class RechargeAnElectricVehicle
    {
        public static void GetElectricVehicleAndChargeIt()
        {
            string licensePlateNumber = null;
            string inputAmountToChargeInMinutes = null;

            Console.WriteLine("Please enter the license plate number of the vehicle that you want to recharge: ");
            licensePlateNumber = Console.ReadLine();
            Console.WriteLine("Please enter the amount to charge in minutes that you want: ");
            inputAmountToChargeInMinutes = Console.ReadLine();
            bool parseSuccessful = float.TryParse(inputAmountToChargeInMinutes, out float amountToChargeInMinutes);
            if (!parseSuccessful)
            {
                Console.WriteLine($"{amountToChargeInMinutes} is not a valid float. Please retry");
                GetElectricVehicleAndChargeIt();
            }

            try
            {
                GarageLogic.Charge(licensePlateNumber, amountToChargeInMinutes);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetElectricVehicleAndChargeIt();
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetElectricVehicleAndChargeIt();
            }

            Console.Clear();
            Console.WriteLine("The vehicle was successfully loaded ");
            Thread.Sleep(2000);
        }
    }
}