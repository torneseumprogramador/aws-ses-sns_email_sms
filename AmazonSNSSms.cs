using Amazon;
using System;
using System.Collections.Generic;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Threading;
using Newtonsoft.Json;

namespace SES.Envio_SMS_Email 
{
    public class AmazonSNSSms
    {
        public async Task Enviar()
        {
            AmazonSimpleNotificationServiceClient smsClient = new AmazonSimpleNotificationServiceClient(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET"), Amazon.RegionEndpoint.SAEast1);

            // envio de SMS para telefone subscribe
            // PublishRequest publishRequest = new PublishRequest();
            // publishRequest.Message = "Um exemplo de SMS - via código";
            // publishRequest.PhoneNumber = "+5511976144154";
            // var result = await smsClient.PublishAsync(publishRequest);
            // Console.WriteLine($"Status code: {result.HttpStatusCode}");
            // Console.WriteLine("The SMS was sent successfully.");

            // envio de SNS para subscribers
            PublishRequest publishRequest = new PublishRequest();
            publishRequest.TopicArn = "arn:aws:sns:sa-east-1:763818760783:teste_sns";
            publishRequest.Message = "Um exemplo de SMS - via código";
            publishRequest.Subject = "Um envio de email via codigo";
            var result = await smsClient.PublishAsync(publishRequest);
            Console.WriteLine($"Status code: {result.HttpStatusCode}");
            Console.WriteLine("The SMS was sent successfully.");
        }
    }
}