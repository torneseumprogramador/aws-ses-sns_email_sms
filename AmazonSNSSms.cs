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
        private AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET"), Amazon.RegionEndpoint.SAEast1);
        public async Task EnviarSMS()
        {

            // envio de SMS para telefone subscribe
            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Message = "Um exemplo de SMS - via código";
            publishRequest.PhoneNumber = "+5511976144154";
            var result = await snsClient.PublishAsync(publishRequest);
            Console.WriteLine($"Status code: {result.HttpStatusCode}");
            Console.WriteLine("The SMS was sent successfully.");
        }

        public async Task CriandoTopicoEEnviando()
        {
            // Criando tópico e enviando email para o tópico
            var topicRequest = new CreateTopicRequest
            {
                Name = "CodingTestResults"
            };

            var topicResponse = await snsClient.CreateTopicAsync(topicRequest);
            var topicAttrRequest = new SetTopicAttributesRequest
            {
                TopicArn = topicResponse.TopicArn,
                AttributeName = "DisplayName",
                AttributeValue = "Coding Test Results"
            };

            await snsClient.SetTopicAttributesAsync(topicAttrRequest);

            await snsClient.SubscribeAsync(new SubscribeRequest
            {
                Endpoint = "didox_59@yahoo.com.br",
                Protocol = "email",
                TopicArn = topicResponse.TopicArn
            });

            await snsClient.SubscribeAsync(new SubscribeRequest
            {
                Endpoint = "+5511976144154",
                Protocol = "sms",
                TopicArn = topicResponse.TopicArn
            });

            DateTime latest = DateTime.Now + TimeSpan.FromMinutes(2);

            // espera confirmação
            while (DateTime.Now < latest)
            {
                var subsRequest = new ListSubscriptionsByTopicRequest
                {
                    TopicArn = topicResponse.TopicArn
                };

                var subs = (await snsClient.ListSubscriptionsByTopicAsync(subsRequest)).Subscriptions;

                var sub = subs[0];

                if (!string.Equals(sub.SubscriptionArn, "PendingConfirmation", StringComparison.Ordinal))
                {
                    break;
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(15));
            }

            // envia mensagem
            await snsClient.PublishAsync(new PublishRequest
            {
                Subject = "Titulo do email " + DateTime.Today.ToString("dd/MM/yyyy HH:MM"),
                Message = "Mensagem enviada",
                TopicArn = topicResponse.TopicArn
            });

        }
        public async Task EnviaParaTopicoManual()
        {
            // envio de SNS para subscribers
            PublishRequest publishRequest = new PublishRequest();
            publishRequest.TopicArn = "arn:aws:sns:sa-east-1:763818760783:teste_sns";
            publishRequest.Message = "Um exemplo de SMS - via código";
            publishRequest.Subject = "Um envio de email via codigo";
            var result = await snsClient.PublishAsync(publishRequest);
            Console.WriteLine($"Status code: {result.HttpStatusCode}");
            Console.WriteLine("The SMS was sent successfully.");
        }
    }
}