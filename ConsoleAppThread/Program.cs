using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppThread
{
	class Program
	{
		static void Main(string[] args)
		{
			//Thread oGetArgThread = new Thread(new ThreadStart(Test));
			//oGetArgThread.IsBackground = true;
			//oGetArgThread.Start();
			//oGetArgThread.Join();
			//for (var i = 0; i < 100; i++)
			//{
			//	Console.WriteLine("主线程计数" + i);
			//	Thread.Sleep(10);
			//}
			MySemaphore mythrd1 = new MySemaphore("Thrd #1");
			MySemaphore mythrd2 = new MySemaphore("Thrd #2");
			MySemaphore mythrd3 = new MySemaphore("Thrd #3");
			MySemaphore mythrd4 = new MySemaphore("Thrd #4");
			mythrd1.thrd.Join();
			mythrd2.thrd.Join();
			mythrd3.thrd.Join();
			mythrd4.thrd.Join();
			Console.ReadKey();
		}
		private static void Test()
		{
			for (var i = 0; i < 100; i++)
			{
				Console.WriteLine("后台线程计数" + i);
				Thread.Sleep(10);
			}
		}
		
	}
}
