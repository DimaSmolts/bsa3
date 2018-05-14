using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace bsa3
{
	class Parking
	{
		private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

		public static Parking Instance { get { return lazy.Value; } }

		public List<Car> parkingLot{get;set;}
		private List<Transaction> transactionLog;
		private double balance;

		private Timer PayTime;
		private Timer ClearTime;

		static object locker;

		private Parking()
		{
			parkingLot = new List<Car>();
			transactionLog = new List<Transaction>();

			TimerCallback tc1 = new TimerCallback(Pay);
			PayTime = new Timer(tc1, 0, 0, 3000);

			//TimerCallback tc2 = new TimerCallback(LogFileOutPut);
			//ClearTime = new Timer(tc2, 0, 0, 60000);

			locker = new object();

		}

	//	public void AddCar(int carType,double balance)
	//	{
	//		if(carType == 1 || carType == 2 || carType == 3 || carType == 4 )
//						parkingLot.Add(new Car(carType,balance));
	//	}

		public void AddCar(Car t)
		{
			//if(carType == 1 || carType == 2 || carType == 3 || carType == 4 )
						parkingLot.Add(t);
		}


		public void DeleteCar(int index)
		{
			if ( parkingLot.Count > index)
				if (parkingLot[index].debt == 0)
				{
					parkingLot.Remove(parkingLot[index]);
				}
		}
		public void Recharge(int index,double sum)
		{
			if ( parkingLot.Count > index)
				parkingLot[index].Balance += sum;
		}

		public void DisplayCars()
		{
			if (parkingLot.Count > 0)
			{
				Console.WriteLine();
				Console.WriteLine("{0,3}\t{1,36}\t{2,16}\t{3,8}\t{4,8}",
					"#",
					"ID",
					"Type",
					"Balance",
					"Debt");
				Console.WriteLine();
				for (int i = 0; i < parkingLot.Count; i++)				
					Console.WriteLine("{0,3}\t{1}", i, parkingLot[i].ToString());
			}
			else
			{
				Console.WriteLine("Parking Lot is empty!");
			}
		}

		public void DisplayBalance()
		{
			double totalDebt = 0;
			foreach (Car c in parkingLot)
				totalDebt += c.debt;
			Console.WriteLine("\nBalance of Parking Lot is {0} $\nTotal debt in {1} $", balance,totalDebt);
		}

		//public void DisplayFreePlaces()
		//{
		//	Console.WriteLine("\nFree places: {0}",Settings.ParkingSpace-parkingLot.Count);
		//}
		public void Pay(object obj)
		{
			lock (locker)
			{
				foreach (Car c in parkingLot)
				{
					if (c.Balance > (int)c.carType + c.debt)
					{
						Transaction temp = new Transaction(c);
						transactionLog.Add(temp);						
						balance += temp.WithDrawMoney;
					}
					else
					{
						c.debt += Settings.Fine * (int)c.carType;
					}
				}
			}
		}

		public void LogFileOutPut(object obj)
		{
			 List<Transaction> tempList = new List<Transaction>();


			foreach (Transaction t in transactionLog)
			{
				double temp = DateTime.Now.Subtract(t.TransactionStamp).TotalSeconds;
				if (temp < 60)
					tempList.Add(t);
			}
			
			transactionLog = tempList;

			lock (locker)
			{
				FileStream file1 = new FileStream(Settings.logFileName, FileMode.Append);
				StreamWriter sw = new StreamWriter(file1);

				sw.WriteLine();
				foreach (Transaction t in tempList)
				{
					sw.WriteLine(string.Format("{0}\t{1}\t{2}\n", t.CarID, t.TransactionStamp, t.WithDrawMoney));
				}
				sw.WriteLine();
				sw.WriteLine(DateTime.Now.ToString());
				sw.Close();
			}
		}

		public List<Transaction> DisplayTransactions()
		{
			double sum=0;
			List<Transaction> tempList = new List<Transaction>();
			foreach (Transaction t in transactionLog)
			{
				double temp = DateTime.Now.Subtract(t.TransactionStamp).TotalSeconds;
				if (temp <= 60)
				{
					tempList.Add(t);
					sum += t.WithDrawMoney;
				}								
			}
			transactionLog = tempList;
			return tempList;
		}
		public List<string> LogFileInPut()
		{
			lock (locker)
			{
				List<string> tempList = new List<string>();
				FileStream file1 = new FileStream(Settings.logFileName, FileMode.Open);
				StreamReader sr = new StreamReader(file1);

				tempList.Add(sr.ReadLine());

				//Console.Write(sr.ReadToEnd());
				sr.Close();
				return tempList;
			}
		}
	}
}
