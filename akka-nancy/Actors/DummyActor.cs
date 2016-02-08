using System;
using Akka.Actor;

namespace akkanansy.Actors
{
	public class DummyActor : ReceiveActor
	{
		public DummyActor ()
		{
			Receive<string> (x => {
				var process_key = Environment.GetEnvironmentVariable ("aws_key", EnvironmentVariableTarget.Process);
				var user_key = Environment.GetEnvironmentVariable ("aws_key", EnvironmentVariableTarget.User);
				var machine_key = Environment.GetEnvironmentVariable ("aws_key", EnvironmentVariableTarget.Machine);
				var key_env = string.Format("aws_key[ proc: '{0}', user: '{1}', machine : '{2}' ]", process_key, user_key, machine_key);

				var process_secret = Environment.GetEnvironmentVariable ("aws_secret", EnvironmentVariableTarget.Process);
				var user_secret = Environment.GetEnvironmentVariable ("aws_secret", EnvironmentVariableTarget.User);
				var machine_secret = Environment.GetEnvironmentVariable ("aws_secret", EnvironmentVariableTarget.Machine);
				var secret_env = string.Format("aws_secret [ proc:'{0}', user: '{1}', machine : '{2}']", process_secret, user_secret, machine_secret );
				Sender.Tell(string.Format("and also akka greeting {0}, {1}, {2} " , x , key_env, secret_env));
			});
		}
	}
}

