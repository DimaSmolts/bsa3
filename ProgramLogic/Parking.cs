using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace bsa3
{
	class Parking
	{
		private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

		public static Parking Instance { get { return lazy.Value; } }

		public List<Car> parkingLot{get;set;}
		private List<Transaction> transactionLog;
		public double balance {get;set;}

		private Timer PayTime;
		private Timer ClearTime;

		static object locker;

		private Parking()
		{
			parkingLot = new List<Car>();
			transactionLog = new List<Transaction>();

			TimerCallback tc1 = new TimerCallback(Pay);
			PayTime = new Timer(tc1, 0, 0, 3000);

			TimerCallback tc2 = new TimerCallback(LogFileOutPut);
			ClearTime = new Timer(tc2, 0, 0, 60000);

			locker = new object();

		}


		public void AddCar(Car t)
		{
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

		//public void DisplayCars()
		//	{
		///	if (parkingLot.Count > 0)
		//	{
		//		Console.WriteLine();
		//		Console.WriteLine("{0,3}\t{1,36}\t{2,16}\t{3,8}\t{4,8}",
		//			"#",
		//			"ID",
		//			"Type",
		//			"Balance",
		//			"Debt");
		//		Console.WriteLine();
		//		for (int i = 0; i < parkingLot.Count; i++)				
		//			Console.WriteLine("{0,3}\t{1}", i, parkingLot[i].ToString());
		//	}
		//	else
		//	{
		///		Console.WriteLine("Parking Lot is empty!");
		//	}
		//}

		//public void DisplayBalance()
		//{
		//	double totalDebt = 0;
		//	foreach (Car c in parkingLot)
		//		totalDebt += c.debt;
		//	Console.WriteLine("\nBalance of Parking Lot is {0} $\nTotal debt in {1} $", balance,totalDebt);
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

			lock (locker)
			{

				foreach (Transaction t in transactionLog)
				{
					double temp = DateTime.Now.Subtract(t.TransactionStamp).TotalSeconds;
					if (temp < 60)
						tempList.Add(t);
				}
			
				transactionLog = tempList;

				FileStream file1 = new FileStream(Settings.logFileName, FileMode.Append);
				StreamWriter sw = new StreamWriter(file1);

				sw.WriteLine();
				foreach (Transaction t in tempList)
				{
					sw.WriteLine(string.Format("{0}   {1}   {2}\n", t.CarID, t.TransactionStamp, t.WithDrawMoney));
				}
				sw.WriteLine();
				sw.WriteLine(DateTime.Now.ToString());
				sw.Close();
			}
		}

		public List<string> DisplayTransactions()
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
			List<string> x = new List<string>();
			foreach(Transaction t in tempList)
				x.Add(t.ToString());
			return x;
		}

		public List<string> DisplayOneTransactions(int id)
		{
			double sum=0;
			List<Transaction> tempList = new List<Transaction>();
			foreach (Transaction t in transactionLog)
			{
				double temp = DateTime.Now.Subtract(t.TransactionStamp).TotalSeconds;
				if (temp <= 60)
				{
					if(t.CarID == parkingLot[id].CarID)
					{
						tempList.Add(t);
						sum += t.WithDrawMoney;
					}
				}								
			}
			transactionLog = tempList;
			List<string> x = new List<string>();
			foreach(Transaction t in tempList)
				x.Add(t.ToString());
			return x;
		}


		public List<string> LogFileInPut()
		{
			lock (locker)
			{
				List<string> tempList = new List<string>();
				FileStream file1 = new FileStream(Settings.logFileName, FileMode.Open);
				
				Guid g;
				DateTime t;
				int x;
				
				using (StreamReader sr = new StreamReader(file1))
				{
					while(true)
					{
						string temp = sr.ReadLine();
						if(temp==null)
						{
							break;
						}
						if(temp!="")
							tempList.Add(temp);
					}
				}


				//Console.Write(sr.ReadToEnd());
				//sr.Close();
				return tempList;
			}
		}
	}
}
