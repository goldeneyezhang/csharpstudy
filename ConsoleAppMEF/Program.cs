using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppMEF
{
	class Program
	{
		//导入对象使用
		[Import("american_hello")]
		public IPerson oPerson { get; set; }
		[Import("TestProperty")]
		public string ConsoleTest { get; set; }
		[Import("helloname")]
		public Action<string> TestFuncImport { get; set; }
		static void Main(string[] args)
		{
			var oProgram=new Program();
			oProgram.MyComposePart();
			var strRes = oProgram.oPerson.SayHello("张一博");
			Console.WriteLine(strRes);
			Console.WriteLine(oProgram.ConsoleTest);
			oProgram.TestFuncImport("Terry");
			Console.Read();
		}
		//宿主MEF并组合部件
		void MyComposePart()
		{
			var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
			var container = new CompositionContainer(catalog);
			//将部件（part）和宿主程序添加到组合容器
			container.ComposeParts(this);
		}
	}
}
