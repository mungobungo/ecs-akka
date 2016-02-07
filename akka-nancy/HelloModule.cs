using Nancy;
using System;

using System.Threading.Tasks;
using Akka;
using Akka.Actor;

namespace akkanansy
{
	public class HelloModule : NancyModule
	{
		public HelloModule()
		{
			Get["/"] = x => {

				var res = Program.system.ActorSelection("akka://MySystem/user/greeter");
				var a = res.Ask(DateTime.UtcNow.ToString());
				Task.WaitAll(a);

				return string.Format("{0} {1}", DateTime.UtcNow, a.Result);
			};
		}
	}
}

