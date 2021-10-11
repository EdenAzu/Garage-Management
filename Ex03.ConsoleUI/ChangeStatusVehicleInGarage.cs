using System;
using System.Threading;


namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class ChangeStatusVehicleInGarage
    {
        public static void GetLicensePlateNumberAndStatusFromUser()
        {
            string licensePlateNumber;
            string newStatus;

            Console.WriteLine("Please enter the license plate number of the vehicle that you want to change is status: ");
            licensePlateNumber = Console.ReadLine();
            Console.WriteLine(@"Please enter the new status for this vehicle:
InRepair
Repaired
Paid");
            newStatus = Console.ReadLine();
            try
            {
                GarageLogic.SetVehicleStatus(licensePlateNumber, newStatus);
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                formatCatchException();
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                formatCatchException();
            }
            Console.Clear();
            Console.WriteLine("The condition of the vehicle in the garage is successfully changed. ");
            Thread.Sleep(2000);
        }

        private static void formatCatchException()
        {
            Thread.Sleep(1000);
            Console.Clear();
            GetLicensePlateNumberAndStatusFromUser();
        }
    }
}
