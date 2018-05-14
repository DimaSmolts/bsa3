using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace bsa3
{
	public class Car
	{
		public enum EnumCarType { Motorcycle = 1, Bus = 2, PassengerCar = 3, Truck = 4}

		private Guid carID;
		public readonly EnumCarType carType;
		private double balance;
		public double debt; //борг


		public Car(int type, double balance)
		{
			carID = Guid.NewGuid();
			switch (type)
			{
				case 1:
					carType = EnumCarType.Motorcycle;
					break;
				case 2:
					carType = EnumCarType.Bus;
					break;
				case 3:
					carType = EnumCarType.PassengerCar;
					break;
				case 4:
					carType = EnumCarType.Truck;
					break;
				default:
					carType = EnumCarType.PassengerCar;
					break;
			}
			this.balance = balance;
			debt = 0;	
		}
		public override string ToString()
		{
			return string.Format("{0}\t{1,16}\t{2,8}\t{3,8}", carID, carType, balance, debt);
		}
		public Guid CarID
		{
			get { return carID; }
		}
		public double Balance
		{
			get { return balance; }
			set
			{
				if (value < 0)
					balance = 0;
				else
					balance = value; 
			}
		}
	}
}
