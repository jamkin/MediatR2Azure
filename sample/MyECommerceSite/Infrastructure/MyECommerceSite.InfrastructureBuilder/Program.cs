using MyECommerceSite.Domain.Customer.Notifications;
using MyECommerceSite.Domain.Customer.Requests;
using MyECommerceSite.Domain.Order.Notifications;
using MyECommerceSite.Domain.Order.Requests;
using MyECommerceSite.Domain.Shipping;
using MyECommerceSite.Domain.Shipping.Notifications;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using MediatR.InfrastructureBuilder.CodeGeneration;
using MediatR.InfrastructureBuilder.Azure.Serverless;
using MediatR.InfrastructureBuilder;
using MyECommerceSite.Domain.Product.Requests;
using MyECommerceSite.Domain.Billing.Notifications;

Console.WriteLine("Generating code for infrastructure and host application layer ...");

ILogger logger = new ConsoleLoggerProvider((string msg, LogLevel level) => true, true)
    .CreateLogger("MessageInfraBuilderLogs");

// Build the configuration for the Azure messaging infra
IMessageInfraCodeGenerator messageInfraCodeGenerator = AzureServerlessMessageInfraCodeGeneratorBuilder
    .CreateNew()
    .AddLogging(logger)
    .WithArmTemplatePath(new FileInfo("TODO: path to azuredeploy.json to be generated"))
    .WithFunctionAppPath(new DirectoryInfo("TODO: path to where Function App should be generated"))
    .Build();

// Build the messaging infra by combining the domain, serialization and finally
// the Azure config from above
MessageInfraBuilder.CreateNew()
    .AddLogging(logger)
    .AddMessageSystemName("MyECommerceSite")
    .AddGroup("Customer")
        .FromAssembly(typeof(AddCustomer).Assembly)
    .AddGroup("Email")
        .FromAssembly(typeof(ChargeAccepted).Assembly)
    .AddGroup("Billing")
        .FromAssembly(typeof(OrderPlaced).Assembly)
    .AddGroup("Product")
        .FromAssembly(typeof(AddProduct).Assembly)
    .AddGroup("Shipping")
        .FromAssembly(typeof(ShipmentArrived).Assembly)
     // TODO: Add serializers
    .AddCodeGenerator(messageInfraCodeGenerator)
    .Build();

Console.WriteLine("Code generated!");
Console.ReadKey(); // Just to keep it open
