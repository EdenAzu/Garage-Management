using System;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class ListOfVehicleLicensePlateNumbers
    {
        private enum eMenuListVehicleLicenseNumbers
        {
            AllVehicles = 1,
            TheVehiclesUnderRepair,
            TheVehiclesWereRepaired,
            TheVehicleThatHaveAlreadyPaid,
            Exit,
        }

        public static void GetListVehicleLicenseNumbers()
        {
            string[] ListVehicleLicenseNumbers;
            int userSelectionOfList = getUserSelectionList();

            while (userSelectionOfList != (int)eMenuListVehicleLicenseNumbers.Exit)
            {
                ListVehicleLicenseNumbers = getStatusForList(userSelectionOfList);
                Console.Clear();
                presentVehiclesNumberList(ListVehicleLicenseNumbers);
                Thread.Sleep(3000);
                userSelectionOfList = getUserSelectionList();
            }

            Console.Clear();
        }

        private static string[] getStatusForList(int i_UserSelection)
        {
            string[] listVehicleLicenseNumbers = null;

            switch (i_UserSelection)
            {
                case (int)eMenuListVehicleLicenseNumbers.AllVehicles:
                    {
                        listVehicleLicenseNumbers = GarageLogic.GetLicensePlates();
                        break;
                    }
                case (int)eMenuListVehicleLicenseNumbers.TheVehiclesUnderRepair:
                    {
                        listVehicleLicenseNumbers = GarageLogic.GetLicensePlatesByStatus("InRepair");
                        break;
                    }
                case (int)eMenuListVehicleLicenseNumbers.TheVehiclesWereRepaired:
                    {
                        listVehicleLicenseNumbers = GarageLogic.GetLicensePlatesByStatus("Repaired");
                        break;
                    }
                case (int)eMenuListVehicleLicenseNumbers.TheVehicleThatHaveAlreadyPaid:
                    {
                        listVehicleLicenseNumbers = GarageLogic.GetLicensePlatesByStatus("Paid");
                        break;
                    }
            }

            return listVehicleLicenseNumbers;
        }

        private static int getUserSelectionList()
        {
            int userSelection = 0;
            bool validSelection = false;
            string inputSelection;

            Console.Clear();
            inputMenuSelectionList();
            while (!validSelection)
            {
                inputSelection = Console.ReadLine();
                validSelection = int.TryParse(inputSelection, out userSelection);
                if (validSelection)
                {
                    if (userSelection < 1 || userSelection > 6)
                    {
                        validSelection = false;
                    }
                }

                if (!validSelection)
                {
                    MainMenuAndOpenGarage.InvalidInput();
                }
            }

            return userSelection;
        }

        private static void inputMenuSelectionList()
        {
            Console.WriteLine(
                @"Please select the list you would like to see: 
1. All vehicles
2. The vehicles under repair
3. The vehicles were repaired
4. The vehicles that have already paid
5. Exit");
        }

        private static void presentVehiclesNumberList(string[] i_Vehicles)
        {
            foreach (string vehicleLicenseNumbers in i_Vehicles)
            {
                Console.WriteLine(string.Format("{0} ", vehicleLicenseNumbers));
            }
        }
    }
}