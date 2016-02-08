using System;
using Akka.Actor;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;

namespace akkanansy.Actors
{
	public class SqsActor : ReceiveActor
	{
		public SqsActor ()
		{
			Receive<string> (x => {
				
				var config = new AmazonSQSConfig();
				config.ServiceURL = "https://sqs.us-west-2.amazonaws.com/";
				//config.RegionEndpointServiceName = "https://us-west-2.amazonaws.com/";

				var cred = new Amazon.Runtime.EnvironmentVariablesAWSCredentials();
				var client = new AmazonSQSClient(cred, config);

				var msg =  x + " and what " + Guid.NewGuid().ToString();
				var request = new Amazon.SQS.Model.SendMessageRequest("https://sqs.us-west-2.amazonaws.com/759958467938/akka_q", msg);
				client.SendMessage(request);



				Sender.Tell(string.Format("done  : [{0}]", msg ));
			});
		}
	}
}

