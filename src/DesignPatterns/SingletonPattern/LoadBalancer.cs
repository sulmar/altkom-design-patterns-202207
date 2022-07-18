using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    public class LoadBalancer : LazySingleton<LoadBalancer>
    {
        private readonly List<Server> servers;

        private readonly Random random = new Random();

        public LoadBalancer()
        {
            Console.WriteLine("Initialize");

            servers = new List<Server>
            {
                new Server { Name = "ServerA", IP = "192.168.0.18" },
                new Server { Name = "ServerB", IP = "192.168.0.19" },
                new Server { Name = "ServerC", IP = "192.168.0.20" },
                new Server { Name = "ServerD", IP = "192.168.0.21" },
                new Server { Name = "ServerE", IP = "192.168.0.22" },
            };
        }

        // Simple Load Balancer
        public Server NextServer => servers[random.Next(servers.Count)];

        // private static object sync = new object();

        //private static LoadBalancer _instance;
        //public static LoadBalancer Instance
        //{
        //    get
        //    {
        //        lock (sync)                     // -> Monitor.Enter(sync);
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new LoadBalancer();
        //            }
        //        }                               // -> Monitor.Exit(sync);

        //        return _instance;

        //    }
        //}
    }

    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}
