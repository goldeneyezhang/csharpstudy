using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppThread
{
	class MySemaphore
	{
		public Thread thrd;

		//创建一个可授权2个许可证的信号量，且初始值为2
		static Semaphore sem = new Semaphore(2, 2);

		public MySemaphore(string name)
		{
			thrd = new Thread(this.Run)
			{
				Name = name
			};
			thrd.Start();
		}

		void Run()
		{
			Console.WriteLine(thrd.Name+"正在等待一个许可证……");
			//申请一个许可证
			sem.WaitOne();
			Console.WriteLine(thrd.Name+"申请许可证……");
			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine(thrd.Name+":  "+i);
				Thread.Sleep(1000);
			}
			Console.WriteLine(thrd.Name+"释放许可证……");
			//释放
			sem.Release();
		}
	
}
}
