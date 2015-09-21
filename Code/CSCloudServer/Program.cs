using CSCloud.Data;
using CSCloud.Enums;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CSCloudServer
{
    class Program
    {

        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(new CSCloudServer()))
            {
                host.Open();

                Console.WriteLine("CS Cloud Server started at :");
                host.Description.Endpoints.ToList().ForEach(e => Console.WriteLine(e.Address.ToString()));
                Console.WriteLine();

                Console.WriteLine("Press [ENTER] to quit.");

                Console.ReadLine();
            }
        }
    }
}
