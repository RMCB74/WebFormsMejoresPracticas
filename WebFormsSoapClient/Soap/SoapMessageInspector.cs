using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WebFormsSoapClient.Soap
{
    public class SoapMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(
            ref Message reply,
            object correlationState)
        {
            Console.WriteLine("===== SOAP RESPONSE =====");
            Console.WriteLine(reply.ToString());
        }

        public object BeforeSendRequest(
            ref Message request,
            IClientChannel channel)
        {
            Console.WriteLine("===== SOAP REQUEST =====");
            Console.WriteLine(request.ToString());

            return null;
        }
    }
}
