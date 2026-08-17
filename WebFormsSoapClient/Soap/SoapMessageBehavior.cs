using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WebFormsSoapClient.Soap
{
    public class SoapMessageBehavior : IEndpointBehavior
    {
        public void ApplyClientBehavior(
            ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(
                new SoapMessageInspector());
        }

        public void AddBindingParameters(
            ServiceEndpoint endpoint,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(
            ServiceEndpoint endpoint,
            EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
