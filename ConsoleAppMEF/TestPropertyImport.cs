using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMEF
{
	public class TestPropertyImport
	{
		[Export("TestProperty")]
		public string TestMmport
		{
			get
			{
				return "测试属性可以导入导出";
			}
		}
		[Export("helloname", typeof(Action<string>))]
		public void GetHelloName(string name)
		{
			Console.WriteLine($"Hello：{name}");
		}
	}
}
