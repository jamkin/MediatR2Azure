namespace MyECommerceSite.Application.Product.DTO.Notifications
{
    using MyECommerceSite.Application.DTO;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PriceIncreased : BaseMessage
    {
        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("oldPrice")]
        public decimal OldPrice { get; set; }

        [JsonProperty("newPrice")]
        public decimal NewPrice { get; set; }
    }
}
