using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWindsor
{
	public class MyMain
	{
		private IDependency1 object1;
		private IDependency2 object2;

		public MyMain(IDependency1 dependency1,IDependency2 dependency2)
		{
			object1 = dependency1;
			object2 = dependency2;
		}
		public void DoSomething()
		{
			object1.SomeObject = "Hello World";
			object2.SomeOtherObject = "Hello Mars";
			Console.WriteLine(object1.SomeObject);
			Console.WriteLine(object2.SomeOtherObject);
		}
	}
}
