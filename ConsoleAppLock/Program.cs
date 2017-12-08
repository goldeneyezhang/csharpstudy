using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppLock
{
    class Program
    {
        static void Main(string[] args)
        {
			Task[] threads = new Task[10];
			Account acc = new Account(1000);
			for(int i=0;i<10;i++)
			{
				var task = new Task(acc.DoTransactions);
				threads[i] = task;
			}
			for(int i=0;i<10;i++)
			{
				threads[i].Start();
			}
			Console.Read();
        }
    }
}
