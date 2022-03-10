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

namespace SES.Envio_SMS_Email 
{
    public class AmazonSESSms
    {
        public async Task Enviar()
        {
            AmazonSimpleNotificationServiceClient smsClient = new AmazonSimpleNotificationServiceClient(Environment.GetEnvironmentVariable("AWS_KEY"), Environment.GetEnvironmentVariable("AWS_SECRET"), Amazon.RegionEndpoint.APSoutheast2);
            var smsAttributes = new Dictionary<string, MessageAttributeValue>();

            // MessageAttributeValue senderID = new MessageAttributeValue();
            // senderID.DataType = "String";
            // senderID.StringValue = "mySenderId";

            // MessageAttributeValue sMSType = new MessageAttributeValue();
            // sMSType.DataType = "String";
            // sMSType.StringValue = "Transactional";

            // MessageAttributeValue maxPrice = new MessageAttributeValue();
            // maxPrice.DataType = "Number";
            // maxPrice.StringValue = "0.5";

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // smsAttributes.Add("AWS.SNS.SMS.SenderID", senderID);
            // smsAttributes.Add("AWS.SNS.SMS.SMSType", sMSType);
            // smsAttributes.Add("AWS.SNS.SMS.MaxPrice", maxPrice);

            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Message = "Um exemplo de SMS";
            publishRequest.MessageAttributes = smsAttributes;
            publishRequest.PhoneNumber = "+5511976144154";

            await smsClient.PublishAsync(publishRequest, token);
            
            Console.WriteLine("The SMS was sent successfully.");
        }
    }
}