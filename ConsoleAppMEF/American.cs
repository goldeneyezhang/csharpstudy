using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMEF
{
	[Export("american_hello", typeof(IPerson))]
	public class American : IPerson
	{
		public string SayHello(string name)
		{
			return $"Hello:{name}";
		}
	}
}
