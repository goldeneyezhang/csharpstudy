using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppMEF
{
	//声明对象可以导出
	[Export("chinese_hello", typeof(IPerson))]
	public class Chinese : IPerson
	{
		public string SayHello(string name)
		{
			return $"您好：{name}";
		}
	}
}
