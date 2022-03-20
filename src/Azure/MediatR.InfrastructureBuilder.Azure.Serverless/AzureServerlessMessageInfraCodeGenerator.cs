namespace MediatR.InfrastructureBuilder.Azure.Serverless
{
    using MediatR.InfrastructureBuilder.CodeGeneration;
    using Microsoft.Extensions.Logging;

    public class AzureServerlessMessageInfraCodeGenerator : IMessageInfraCodeGenerator
    {
        private readonly ILogger _logger;

        public IEnumerable<ICodeFile> GenerateFiles(IMessageNetworkDefinition messageNetworkDefinition)
        {
            throw new NotImplementedException();
        }
    }
}