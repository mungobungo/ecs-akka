using System;
using Akka.Actor;

namespace akkanansy.Actors
{
	public class DummyActor : ReceiveActor
	{
		public DummyActor ()
		{
			Receive<string> (x => {
				Sender.Tell("and also akka greeting : " + x + x);
			});
		}
	}
}

