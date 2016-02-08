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


                var sqs_url = Environment.GetEnvironmentVariable("sqs_url", EnvironmentVariableTarget.Process);
                var config = new AmazonSQSConfig();
                config.ServiceURL = sqs_url;

                var creds = new StoredProfileAWSCredentials();
                var client = new AmazonSQSClient(creds, config);

                var msg =  x + " and what " + Guid.NewGuid().ToString();
                var queue_url = Environment.GetEnvironmentVariable("queue_url", EnvironmentVariableTarget.Process);
             
                var request = new Amazon.SQS.Model.SendMessageRequest(queue_url, msg);
             
                client.SendMessage(request);

				Sender.Tell(string.Format("done  : [{0}]", msg ));
			});
		}
	}
}

