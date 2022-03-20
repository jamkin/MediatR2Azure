namespace MyECommerceSite.Simulator
{
    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;

    public class OrderSimulator
    {
        [FunctionName("PlaceNewOrder")]
        public void PlaceNewOrder([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            throw new NotImplementedException("TODO: Enqueue message to place new order");
        }
    }
}
