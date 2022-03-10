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
            
            
            /*
            
            AmazonSimpleNotificationServiceClient smsClient = new AmazonSimpleNotificationServiceClient(my_access_key, my_secret_key, Amazon.RegionEndpoint.APSoutheast2);

            var smsAttributes = new Dictionary<string, MessageAttributeValue>();

            MessageAttributeValue senderID = new MessageAttributeValue();
            senderID.DataType = "String";
            senderID.StringValue = "mySenderId";

            MessageAttributeValue sMSType = new MessageAttributeValue();
            sMSType.DataType = "String";
            sMSType.StringValue = "Transactional";

            MessageAttributeValue maxPrice = new MessageAttributeValue();
            maxPrice.DataType = "Number";
            maxPrice.StringValue = "0.5";

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;


            smsAttributes.Add("AWS.SNS.SMS.SenderID", senderID);
            smsAttributes.Add("AWS.SNS.SMS.SMSType", sMSType);
            smsAttributes.Add("AWS.SNS.SMS.MaxPrice", maxPrice);

            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Message = "This is 2nd sample message";
            publishRequest.MessageAttributes = smsAttributes;
            publishRequest.PhoneNumber = "received phone no with + and country code";

            Task<PublishResponse> result = smsClient.PublishAsync(publishRequest, token);
            
            */
        }
    }
}
