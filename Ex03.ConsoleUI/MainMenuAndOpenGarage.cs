using System;

// $G$ DSN-999 (-7) Why static? it's not object-oriented. You should have had an instance of this class created by the Main and 
// call a Run() method. This class should have members (such as Logic class) and not local variables within a method.

namespace Ex03.ConsoleUI
{
    internal static class MainMenuAndOpenGarage
    {
        private enum eMainMenu
        {
            InsertNewVehicleToGarage = 1,
            ViewListOfVehicleLicenseNumbers,
            ChangeStatusVehicleInGarage,
            InflateAirWheelsVehicle,
            FuelAVehicle,
            RechargeAnElectricVehicle,
            ViewFullDataVehicle,
            Exit
        }

        public static void RunMainMenuAndOpenGarage()
        {
            int inputUserSelection = 0;

            while (inputUserSelection != (int)eMainMenu.Exit)
            {
                inputUserSelection = getSelectionUser();
                Console.Clear();
                runUserSelection(inputUserSelection);
            }
        }

        private static int getSelectionUser()
        {
            int userSelection = 0;
            string inputUserSelection;
            bool validUserSelection = false;

            mainMenu();
            while (!validUserSelection)
            {
                inputUserSelection = Console.ReadLine();
                validUserSelection = int.TryParse(inputUserSelection, out userSelection);
                if (validUserSelection)
                {
                    // $G$ CSS-999 (-3) If you use number as condition --> then you should have use constant here.
                    if (userSelection < 1 || userSelection > 8)
                    {
                        validUserSelection = false;
                    }
                }

                if (!validUserSelection)
                {
                    InvalidInput();
                }
            }

            return userSelection;
        }

        public static void InvalidInput()
        {
            Console.WriteLine("\nThis input is invalid, please select again.\n");
        }

        private static void mainMenu()
        {
            Console.WriteLine(
                @"Please select the action number that you want to perform:
1. Insert new vehicle to the garage
2. Display the list of vehicle license numbers in the garage
3. Change the condition of a vehicle in the garage
4. To inflate air in the wheels of a vehicle to a maximum
5. To refuel a vehicle that is powered by fuel
6. Charge an electric vehicle
7. View complete vehicle data 
8. Exit");
        }

        private static void runUserSelection(int i_UserSelection)
        {
            switch (i_UserSelection)
            {
                case (int)eMainMenu.InsertNewVehicleToGarage:
                    {
                        InsertNewVehicleToGarage.CreateNewVehicleInGarage();
                        break;
                    }
                case (int)eMainMenu.ViewListOfVehicleLicenseNumbers:
                    {
                        ListOfVehicleLicensePlateNumbers.GetListVehicleLicenseNumbers();
                        break;
                    }
                case (int)eMainMenu.ChangeStatusVehicleInGarage:
                    {
                        ChangeStatusVehicleInGarage.GetLicensePlateNumberAndStatusFromUser();
                        break;
                    }
                case (int)eMainMenu.InflateAirWheelsVehicle:
                    {
                        InflateAirWheelsInVehicle.GetLicensePlateNumberAndInflateAirWheels();
                        break;
                    }
                case (int)eMainMenu.FuelAVehicle:
                    {
                        FuelVehicleInGasoline.GetDetailsOfVehiclesFuelInGas();
                        break;
                    }
                case (int)eMainMenu.RechargeAnElectricVehicle:
                    {
                        RechargeAnElectricVehicle.GetElectricVehicleAndChargeIt();
                        break;
                    }
                case (int)eMainMenu.ViewFullDataVehicle:
                    {
                        VehicleDetails.GetDetailsOnVehicle();
                        break;
                    }
            }

            Console.Clear();
        }
    }
}