namespace MediatR.InfrastructureBuilder.Messaging.JsonSerialization.JsonSerialization
{
    using AutoMapper;
    using MediatR.InfrastructureBuilder.Serialization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class JsonSerializerDeserializer<TMessageModel> : IMessageSerializer<TMessageModel>, IMessageDeserializer<TMessageModel> where TMessageModel : class
    {
        private readonly IMapper _mapper;
        private readonly Type _contractType;

        public JsonSerializerDeserializer(IMapper mapper, Type contractType)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._contractType = contractType ?? throw new ArgumentNullException(nameof(contractType));
        }

        public TMessageModel Deserialize(Stream source, CancellationToken ct = default)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            object contract = this.DeserializeContract(source);
            TMessageModel model = this._mapper.Map<TMessageModel>(contract);

            return model;
        }

        public Task<TMessageModel> DeserializeAsync(Stream source, CancellationToken ct = default)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // TODO: Real async
            return Task.FromResult(this.Deserialize(source));
        }

        public Stream Serialize(TMessageModel message, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> SerializeAsync(TMessageModel message, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        private object DeserializeContract(Stream stream)
        {
            throw new NotImplementedException();
        }

        private Stream SerializeContract(object contract)
        {
            throw new NotImplementedException();
        }
    }
}