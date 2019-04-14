using MassTransit;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitConsumerHost
{
     
        internal class Command1Handler : IConsumer<MyMessage>
        {
            public async Task Consume(ConsumeContext<MyMessage> context)
            {
                await Console.Out.WriteLineAsync($"Command with text {context.Message.Text} been received");
            }
        }
    
}
