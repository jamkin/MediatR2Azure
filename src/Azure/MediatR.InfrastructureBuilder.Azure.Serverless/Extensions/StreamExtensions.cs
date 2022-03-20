namespace MediatR.InfrastructureBuilder.Azure.Serverless.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class StreamExtensions
    {
        internal static async Task<MemoryStream> WriteToMemoryStreamAsync(this Stream stream, CancellationToken ct = default)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream, ct).ConfigureAwait(false);
                return memStream;
            }
        }

        internal static async Task<string> WriteToStringAsync(this Stream stream, Encoding encoding, CancellationToken ct = default)
        {
            using (var streamReader = new StreamReader(stream, encoding))
            {
                var str = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
                return str;
            }
        }
    }
}
