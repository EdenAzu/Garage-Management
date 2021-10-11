using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class InsertNewVehicleToGarage
    {
        public static void CreateNewVehicleInGarage()
        {
            string inputSelectionTypeVehicle = null;
            string[] vehicleMissingKeys = null;
            Dictionary<string, string> vehicleParams = new Dictionary<string, string>();
            Console.WriteLine("Please insert your name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please insert your phone number:");
            string ownerPhoneNumber = Console.ReadLine();
            inputSelectionTypeVehicle = getSelectionVehicleType();
            try
            {
                vehicleMissingKeys = GarageLogic.GetVehicleParamsNeededFromUser(inputSelectionTypeVehicle);
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                CreateNewVehicleInGarage();
            }

            foreach (string missingKey in vehicleMissingKeys)
            {
                string splitOnceMissingKey = dropUninteresting(missingKey);
                string splitTwiceMissingKey = insertSpaceBeforeUpperCaseAndChangeToLower(splitOnceMissingKey);
                Console.WriteLine(String.Format("Please Enter {0}: ", splitTwiceMissingKey));
                string inputValue = Console.ReadLine();
                vehicleParams.Add(missingKey, inputValue);
            }

            try
            {
                GarageLogic.InsertNewVehicleToGarage(
                    inputSelectionTypeVehicle,
                    ownerName,
                    ownerPhoneNumber,
                    vehicleParams);
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                CreateNewVehicleInGarage();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                CreateNewVehicleInGarage();
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                CreateNewVehicleInGarage();
            }

            Console.Clear();
            Console.WriteLine("The vehicle successfully entered the garage. ");
            Thread.Sleep(2000);
        }

        private static string getSelectionVehicleType()
        {
            string inputUserSelection;

            menuTypeVehicles();
            inputUserSelection = Console.ReadLine();
            return inputUserSelection;
        }

        private static void menuTypeVehicles()
        {
            Console.WriteLine(
                @"Please select the type of vehicle you would like to bring into the garage:
GasMotorcycle
GasCar
GasTruck
ElectricCar
ElectricMotorcycle");
        }

        private static string dropUninteresting(string i_MissingKey)
        {
            return i_MissingKey.Split('_')[1];
        }

        private static string insertSpaceBeforeUpperCaseAndChangeToLower(this string i_MissingKey)
        {
            StringBuilder detailInVehicle = new StringBuilder();
            char previousChar = char.MinValue;

            foreach (char charUpperCase in i_MissingKey)
            {
                if (char.IsUpper(charUpperCase))
                {
                    if (detailInVehicle.Length != 0 && previousChar != ' ')
                    {
                        detailInVehicle.Append(' ');
                    }

                    detailInVehicle.Append(char.ToLowerInvariant(charUpperCase));
                }
                else
                {
                    detailInVehicle.Append(charUpperCase);
                }

                previousChar = charUpperCase;
            }

            return detailInVehicle.ToString();
        }
    }
}