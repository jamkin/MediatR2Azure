namespace MediatR.InfrastructureBuilder
{
    using MediatR.InfrastructureBuilder.CodeGeneration;
    using MediatR.InfrastructureBuilder.Grouping;
    using MediatR.InfrastructureBuilder.Logging;
    using MediatR.InfrastructureBuilder.Serialization;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class MessageInfraBuilder : IMessageInfraBuilder
    {
        public static IMessageInfraBuilder CreateNew() => new MessageInfraBuilder();

        private IMessageInfraCodeGenerator _messageInfraCodeGenerator;
        private string _name;
        private ILogger _logger;

        public IMessageInfraBuilder AddLogging(ILogger logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return this;
        }

        public IMessageInfraBuilder AddMessageSystemName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid message system name.", nameof(name));
            }

            this._name = name;
            return this;
        }

        public IMessageHandlerGroupingBuilder AddGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public IMessageInfraBuilder AddCodeGenerator(IMessageInfraCodeGenerator codeGenerator)
        {
            this._messageInfraCodeGenerator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
            return this;
        }

        public void Build()
        {
            var messageInfraCodeGenerator = _messageInfraCodeGenerator
                ?? throw new InvalidOperationException($"Code generator needs to have been set using {this.GetType()}.{nameof(this.AddCodeGenerator)}");

            this._logger.LogInformation($"Generating code files ...");
            foreach (var codeFile in messageInfraCodeGenerator.GenerateFiles())
            {
                if (codeFile.TargetFile.Exists)
                {
                    this._logger.LogWarning($"File {codeFile.TargetFile} will be deleted and recreated.");
                    codeFile.TargetFile.Delete();
                    using (var targetStream = codeFile.TargetFile.OpenWrite())
                    using (var sourceStream = codeFile.GenerateContent())
                    {
                        targetStream.CopyTo(sourceStream);
                    }
                    this._logger.LogInformation($"Generated file {codeFile.TargetFile}.");
                }
            }
            this._logger.LogInformation("All code files generated.");
        }

        public IMessageInfraBuilder AddMessageSerializer<TMessage>(IMessageSerializer<TMessage> messageSerializer) where TMessage : class
        {
            throw new NotImplementedException();
        }

        public IMessageInfraBuilder AddMessageDeserializer<TMessage>(IMessageDeserializer<TMessage> messageDeserializer) where TMessage : class
        {
            throw new NotImplementedException();
        }

        private MessageInfraBuilder()
        {
            this._logger = LoggerNone.Instance;
        }
    }
}
