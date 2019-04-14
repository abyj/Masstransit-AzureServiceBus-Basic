using MassTransit;
using MassTransit.AzureServiceBusTransport;
using Messages;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masstransit_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingAzureServiceBus(config => {

                var host = config.Host(ConfigurationManager.AppSettings["sb:uri"], hst =>
                {
                    hst.OperationTimeout = TimeSpan.FromSeconds(15);
                }
             );
            });

            bus.Start();

            bus.Publish<MyMessage>(new MyMessage() { Text = "Pubished at :" + DateTime.Now });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }

       
    }
}
