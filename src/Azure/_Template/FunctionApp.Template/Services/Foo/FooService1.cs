namespace FunctionApp.Template.Services.Foo
{
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using FakeDomain.Foo.Requests;
    using MediatR.InfrastructureBuilder.Azure.Serverless.Functions;
    using MediatR.InfrastructureBuilder.Serialization;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;

    public class FooService1 : AzureFunctionsDomainServiceBase<FooService1>
    {
        public FooService1(ILogger<FooService1> logger, IMessageDeserializerFactory messageDeserializerFactory)
            : base(logger, messageDeserializerFactory)
        {
        }

        [FunctionName("FooService1_FooRequest1")]
        public Task FooService1_FooRequest1([ServiceBusTrigger(queueName: "foo-request-1-queue", Connection = "")] ServiceBusMessage serviceBusMessage)
        {
            return base.HandleRequestAsync<FooRequest1>(serviceBusMessage);
        }
    }
}
