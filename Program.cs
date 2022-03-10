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

            //await new AmazonSESMail().Enviar(); 
            await new AmazonSESSms().Enviar(); 
        }
    }
}
