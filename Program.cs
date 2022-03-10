using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Newtonsoft.Json;

namespace SES.Envio_SMS_Email
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await new AmazonSESMail().Enviar();

            // var awsCredentials = new BasicAWSCredentials(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET")); 
            // var client = new AmazonSQSClient(awsCredentials, RegionEndpoint.SAEast1);
            // var request = new SendMessageRequest
            // {
            //     QueueUrl = Environment.GetEnvironmentVariable("SQS_URL"),
            //     MessageBody = JsonConvert.SerializeObject(objEnvio)
            // };

            // await client.SendMessageAsync(request);
        }
    }
}
