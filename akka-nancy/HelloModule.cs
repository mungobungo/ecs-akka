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

				var greet = Program.system.ActorSelection("akka://MySystem/user/greeter");
				var sqs = Program.system.ActorSelection("akka://MySystem/user/sqs");
				var a = greet.Ask(DateTime.UtcNow.ToString());
				var b = sqs.Ask(DateTime.UtcNow.ToString());
				Task.WaitAll(a,b);

				return string.Format("{0} {1}", DateTime.UtcNow, a.Result.ToString() + b.Result.ToString());
			};
		}
	}
}

