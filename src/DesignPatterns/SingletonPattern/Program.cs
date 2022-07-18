using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singleton Pattern!");

             LoggerTest();

             LoadBalancerTest();

            LoggerIoCTest();

            Console.ReadKey();
        }

        private static void LoggerIoCTest()
        {
            // Install-Package Microsoft.Extensions.DependencyInjection
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<MessageService>();
            services.AddTransient<PrintService>();
            services.AddSingleton<Logger>();

            var serviceProvider = services.BuildServiceProvider();

            MessageService messageService = serviceProvider.GetRequiredService<MessageService>();
            PrintService printService = serviceProvider.GetRequiredService<PrintService>();

            if (ReferenceEquals(messageService.logger, printService.logger))
            {
                Console.WriteLine("The same instances");
            }
            else
            {
                Console.WriteLine("Different instances");
            }

        }

        private static void LoggerTest()
        {
            MessageService messageService = new MessageService(Logger.Instance);
            PrintService printService = new PrintService(Logger.Instance);
            messageService.Send("Hello World!");
            printService.Print("Hello World!", 3);

            if (ReferenceEquals(messageService.logger, printService.logger))
            {
                Console.WriteLine("The same instances");
            }
            else
            {
                Console.WriteLine("Different instances");
            }
        }

        private static void LoadBalancerTest()
        {
            Task.Run(() => LoadBalanceRequestTest(15));
            Task.Run(() => LoadBalanceRequestTest(15));
            Task.Run(() => LoadBalanceRequestTest(15));
        }

        private static void LoadBalanceRequestTest(int numberOfRequests)
        {            
            LoadBalancer loadBalancer = LoadBalancer.Instance;

            for (int i = 0; i < numberOfRequests; i++)
            {
                Server server = loadBalancer.NextServer;
                Console.WriteLine($"Send request to: {server.Name} {server.IP}");
            }
        }

        

        
    }




  
}
