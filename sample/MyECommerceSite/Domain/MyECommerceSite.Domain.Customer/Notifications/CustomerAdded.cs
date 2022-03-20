namespace MyECommerceSite.Domain.Customer.Notifications
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomerAdded : INotification, ICustomerAssociated
    {
        public Guid CustomerId => throw new NotImplementedException();
    }
}
