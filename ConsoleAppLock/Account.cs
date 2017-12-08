using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLock
{
	class Account
	{
		private Object thisLock = new Object();
		int balance;
		Random r = new Random();
		public Account(int initial)
		{
			balance = initial;
		}
		int Withdraw(int amount)
		{
			//This condition will never be true unless the lock statement is commented ount
			if (balance < 0)
			{
				throw new Exception("Negative Balance");
			}
			//Comment out the next line to see the effect of leaving out
			//the lock keyword
			lock (thisLock)
			{
				if (balance >= amount)
				{
					Console.WriteLine($"Balance before Withdraw:{balance}");
					Console.WriteLine($"Amount to withdraw:{amount}");
					balance = balance - amount;
					Console.WriteLine($"Balance after Withdraw:" + balance);
					return amount;
				}
				else
				{
					return 0;
				}
			}
		}
		public void DoTransactions()
		{
			for(int i=0;i<2;i++)
			{
				Withdraw(r.Next(1, 100));
			}
		}
	}
}
