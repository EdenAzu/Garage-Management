using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using Ex03.GarageLogic;

    internal static class InflateAirWheelsInVehicle
    {
        public static void GetLicensePlateNumberAndInflateAirWheels()
        {
            string licensePlateNumber = null;

            Console.WriteLine(
                "Please enter the license plate number of the vehicle that you want to fill his wheels: ");
            licensePlateNumber = Console.ReadLine();
            try
            {
                GarageLogic.InflateTyresToMax(licensePlateNumber);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetLicensePlateNumberAndInflateAirWheels();
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                GetLicensePlateNumberAndInflateAirWheels();
            }

            Console.Clear();
            Console.WriteLine("The vehicle wheels were inflated to the maximum.. ");
            Thread.Sleep(2000);
        }
    }
}