using Nancy.Hosting.Self;
using System;
namespace akkanansy
{
	class Program
	{
		static void Main (string[] args)
		{
			var nancyHost = new NancyHost(new Uri("http://localhost:8888/nancy/"), new Uri("http://localhost:8889/nancy/"), new Uri("http://localhost:8899/nancytoo/"));
			nancyHost.Start();

			Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/nancy/. Press enter to stop");
			//Process.Start("http://localhost:8888/nancy/");
			Console.ReadKey();

			nancyHost.Stop();

			Console.WriteLine("Stopped. Good bye!");
		}
	}
}