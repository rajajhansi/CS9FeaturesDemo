using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSFeaturesDemo
{
    class Order
    {
        public int Id { get; set; }
    }

    class OrderFactory
    {
       public async IAsyncEnumerable<Order> MakeOrdersAsync(int count)
       {
            for(var i = 0; i < count; i++)
            {
                // Pretend to call some expensive process to build up the order
                await Task.Delay(1000);

                yield return new Order { Id = i + 1 };
            }
       }
    }
    public static class AsyncStreamsDemo
    {
        static int ThreadId => Thread.CurrentThread.ManagedThreadId;
        public static async Task DemoAsync()
        {
            Console.WriteLine("AsyncStreams Demo");

            var orderFactory = new OrderFactory();

            Console.WriteLine($"[{ThreadId}]Enumerating orders....");

            await foreach(var order in orderFactory.MakeOrdersAsync(5))
            {
                Console.WriteLine($"[{ThreadId}]Received order {order.Id}");
            }

            Console.WriteLine($"[{ThreadId}]All orders created!");
        }
    }
}
