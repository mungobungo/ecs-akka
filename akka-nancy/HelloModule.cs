using Nancy;
using System;
namespace akkanansy
{
	public class HelloModule : NancyModule
	{
		public HelloModule()
		{
			Get["/"] = x => {

				return string.Format("{0} {1}", DateTime.UtcNow, "waiting for the miracle");
			};
		}
	}
}

