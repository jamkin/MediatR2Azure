namespace MediatR.InfrastructureBuilder.CodeGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICodeFile
    {
        FileInfo TargetFile { get; }

        Stream GenerateContent(CancellationToken ct = default);
    }
}
