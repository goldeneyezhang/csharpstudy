using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWindsor
{
	class Program
	{

		static void Main(string[] args)
		{
			//create a windsor container object and register the interfaces, AND THEIR CONCRETE IMPLEMENTATIONS.
			var container = new WindsorContainer();
			container.Register(Castle.MicroKernel.Registration.Component.For<MyMain>());
			container.Register(Castle.MicroKernel.Registration.Component.For<IDependency1>().ImplementedBy<Dependency1>());
			container.Register(Castle.MicroKernel.Registration.Component.For<IDependency2>().ImplementedBy<Dependency2>());
			//create the main object and invoke its method as desired
			var mainThing = container.Resolve<MyMain>();
			mainThing.DoSomething();
			Console.Read();
		}
	}
}
