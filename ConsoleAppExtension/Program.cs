using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExtension
{
	class Program
	{
		static void Main(string[] args)
		{
			string strTest = null;
			var strRes = strTest.GetNotNullStr();
			var oPerson1 = new Person();
			oPerson1.Age = 20;
			var bIsChild = oPerson1.GetBIsChild();
			Console.Read();
		}
	}
}
