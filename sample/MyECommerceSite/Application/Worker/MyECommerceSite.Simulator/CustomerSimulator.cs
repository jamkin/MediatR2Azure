namespace MyECommerceSite.Simulator
{
    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;

    public class CustomerSimulator
    {
        [FunctionName("AddNewCustomer")]
        public void AddNewCustomer([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            throw new NotImplementedException("TODO: Enqueue message for adding new customer");
        }

        [FunctionName("ChangeCustomerAddress")]
        public void ChangeCustomerAddress([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            throw new NotImplementedException("TODO: Enqueue new message for changing customer address");
        }
    }
}
