using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.AzureServiceBusTransport;
using Messages;
using System;
using System.Configuration;

namespace MasstransitConsumerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingAzureServiceBus(config => {

                var host = config.Host(ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"], hst =>
                {
                    hst.OperationTimeout = TimeSpan.FromSeconds(15);
                });

                config.SubscriptionEndpoint<MyMessage>(host, "command1", x =>
                {
                    x.Consumer<Command1Handler>();
                });
            });

            bus.Start();

       

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
