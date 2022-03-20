namespace MediatR.InfrastructureBuilder
{
    using MediatR.InfrastructureBuilder.CodeGeneration;
    using MediatR.InfrastructureBuilder.Grouping;
    using MediatR.InfrastructureBuilder.Serialization;
    using Microsoft.Extensions.Logging;
    using System.Reflection;

    public interface IMessageInfraBuilder
    {
        IMessageInfraBuilder AddLogging(ILogger logger);

        IMessageInfraBuilder AddMessageSystemName(string name);

        IMessageInfraBuilder AddMessageSerializer<TMessage>(IMessageSerializer<TMessage> messageSerializer) where TMessage : class;

        IMessageInfraBuilder AddMessageDeserializer<TMessage>(IMessageDeserializer<TMessage> messageDeserializer) where TMessage : class;

        IMessageHandlerGroupingBuilder AddGroup(string groupName);

        IMessageInfraBuilder AddCodeGenerator(IMessageInfraCodeGenerator codeGenerator);

        void Build();
    }
}