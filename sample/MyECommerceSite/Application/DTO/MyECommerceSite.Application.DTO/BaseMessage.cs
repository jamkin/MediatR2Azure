namespace MyECommerceSite.Application.DTO
{
    using Newtonsoft.Json;

    public abstract class BaseMessage
    {
        [JsonIgnore]
        public string CorrelationId => this._correlationId;

        [JsonIgnore]
        public DateTimeOffset Time => this._time;

        [JsonProperty("correlationId")]
        [JsonRequired]
        private string _correlationId { get; set; }

        [JsonProperty("time")]
        [JsonRequired]
        private DateTimeOffset _time { get; set; }

        [JsonConstructor]
        protected BaseMessage() { }

        protected BaseMessage(string correlationId, DateTimeOffset time)
        {
            this._correlationId = correlationId;
            this._time = time;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}