namespace MyECommerce.Application.Customer.DTO.Notifications
{
    using MyECommerceSite.Application.DTO;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddressChanged : BaseMessage
    {
        [JsonProperty("customerId")]
        [JsonRequired]
        public Guid CustomerId { get; set; }
    }
}
