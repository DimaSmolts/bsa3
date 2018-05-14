using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa3
{
	public static class Settings
	{
		private static int timeOut;
		private static Dictionary<int, string> priceList;
		private static int parkingSpace;
		private static double fine;
		public static readonly string logFileName; 

		static Settings()
		{
			// initializing
			timeOut = 3;

			priceList = new Dictionary<int, string>();
			priceList.Add(1, "Motorcycle");
			priceList.Add(2, "Bus");
			priceList.Add(3, "PassengerCar");
			priceList.Add(4, "Truck");			

			parkingSpace = 100;

			fine = 2.5;

			logFileName = "Transactions.log";
		}

		public static int TimeOut
		{
			get
			{
				return timeOut;
			}
		}
		public static Dictionary<int, string> PriceList
		{
			get
			{
				return priceList;
			}
		}
		public static int ParkingSpace
		{
			get
			{
				return parkingSpace;
			}
		}
		public static double Fine
		{
			get
			{
				return fine;
			}
		}
	}
}
