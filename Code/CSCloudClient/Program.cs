using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CSCloudClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to the server...");
            var client = new CSCloudClient();
            var server = new CSCloudServerProxyHttp.CSCloudServerClient(new InstanceContext(client));
            bool connected = false;
            try
            {
                connected = client.Connect(server);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not connect to the server.");
                //TODO Log
                return;
            }

            if (connected)
            {
                Console.WriteLine("Connected to the server.");
                Console.WriteLine("The client will exit automatically when all server commands have been completed.");
                //TODO Log
            }
            else
            {
                Console.WriteLine("Could not connect to the server.");
                //TODO Log
            }

            Console.WriteLine("Press [ENTER] to quit.");

            Console.ReadLine();
        }
    }
}
