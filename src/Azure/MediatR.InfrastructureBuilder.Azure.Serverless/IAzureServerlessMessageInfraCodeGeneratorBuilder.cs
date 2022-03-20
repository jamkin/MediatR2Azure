namespace MediatR.InfrastructureBuilder.Azure.Serverless
{
    using MediatR.InfrastructureBuilder.CodeGeneration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAzureServerlessMessageInfraCodeGeneratorBuilder
    {
        IAzureServerlessMessageInfraCodeGeneratorBuilder WithArmTemplatePath(FileInfo azureDeployFile);

        IAzureServerlessMessageInfraCodeGeneratorBuilder WithFunctionAppPath(DirectoryInfo pathToFunctionAppFolder);

        IAzureServerlessMessageInfraCodeGeneratorBuilder AddLogging(ILogger logger);

        IMessageInfraCodeGenerator Build();
    }
}
