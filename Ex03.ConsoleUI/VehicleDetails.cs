using System;

namespace Ex03.ConsoleUI
{
    using GarageLogic;

    internal static class VehicleDetails
    {
        public static void GetDetailsOnVehicle()
        {
            string vehicleDetails = null;
            string licensePlateNumber = null;
            Console.WriteLine(
                "Please enter the license plate number of the vehicle that you would like to see details on: ");
            licensePlateNumber = Console.ReadLine();
            try
            {
                vehicleDetails = GarageLogic.GetVehicleFullDetails(licensePlateNumber);
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetDetailsOnVehicle();
            }

            Console.Clear();
            Console.WriteLine(string.Format("The details of this vehicle are:\n{0}", vehicleDetails));
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}