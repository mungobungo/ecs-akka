﻿using Nancy.Hosting.Self;
using System;
using System.Threading;
using Akka.Actor;
using akkanansy.Actors;
namespace akkanansy
{
	class Program
	{
		public static ActorSystem system;
		static void Main (string[] args)
		{
			system = ActorSystem.Create("MySystem");
			system.ActorOf<DummyActor>("greeter");

			var nancyHost = new NancyHost(new Uri("http://localhost:8888/nancy/"), new Uri("http://localhost:8889/nancy/"), new Uri("http://localhost:8899/nancytoo/"));
			nancyHost.Start();

			Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/nancy/. Press enter to stop");
			//Process.Start("http://localhost:8888/nancy/");
			string a = "none";
			while (a != "quit") {
				a = Console.ReadLine ();
		    }

			nancyHost.Stop();

			Console.WriteLine("Stopped. Good bye!");
		}
	}
}