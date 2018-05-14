using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsa3
{
	class Transaction
	{
		private DateTime transactionStamp ;
		private Guid carID;
		private double withdrawnMoney;

		public Transaction(Car car)
		{
			transactionStamp = DateTime.Now;
			carID = car.CarID;
			withdrawnMoney = (int)car.carType +  car.debt; // Settings.Fine *
			car.Balance = car.Balance - withdrawnMoney;
			car.debt = 0;			
		}

		//public void DisplayTransactionInfo()
		//{
		//	Console.WriteLine("{0}\t{1}\t{2}", carID, transactionStamp,  withdrawnMoney);
		//}

		public DateTime TransactionStamp
		{
			get { return transactionStamp; }
		}

		public double WithDrawMoney
		{
			get { return withdrawnMoney; }
		}

		public Guid CarID
		{
			get { return carID; }
		}
	}
}
