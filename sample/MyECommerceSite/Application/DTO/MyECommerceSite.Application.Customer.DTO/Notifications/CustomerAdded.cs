namespace MyECommerce.Application.Customer.DTO.Notifications
{
    using MyECommerceSite.Application.DTO;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomerAdded : BaseMessage
    {
        [JsonProperty("customerId")]
        [JsonRequired]
        public Guid CustomerId { get; set; }

        [JsonProperty("name")]
        [JsonRequired]
        public string[] Name { get; set; }

        [JsonProperty("address")]
        [JsonRequired]
        public string[] Address { get; set; }
    }
}
