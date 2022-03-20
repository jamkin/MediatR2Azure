namespace MediatR.InfrastructureBuilder.Azure.Serverless
{
    using MediatR.InfrastructureBuilder.CodeGeneration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AzureServerlessMessageInfraCodeGeneratorBuilder : IAzureServerlessMessageInfraCodeGeneratorBuilder
    {
        public static IAzureServerlessMessageInfraCodeGeneratorBuilder CreateNew() => new AzureServerlessMessageInfraCodeGeneratorBuilder();

        private AzureServerlessMessageInfraCodeGeneratorBuilder() { }

        public IMessageInfraCodeGenerator Build()
        {
            throw new NotImplementedException();
        }

        public IAzureServerlessMessageInfraCodeGeneratorBuilder WithArmTemplatePath(FileInfo azureDeployFile)
        {
            throw new NotImplementedException();
        }

        public IAzureServerlessMessageInfraCodeGeneratorBuilder WithFunctionAppPath(DirectoryInfo pathToFunctionAppFolder)
        {
            throw new NotImplementedException();
        }

        public IAzureServerlessMessageInfraCodeGeneratorBuilder AddLogging(ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
