using CSCloud.Data;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
            bool connected = false;
            CSCloudClient client = null;
            CSCloudServerProxyHttp.CSCloudServerClient server = null;
            CSCloudLogServerProxy.CSCloudLogServiceClient logService = null;

            try
            {
                client = new CSCloudClient();
                server = new CSCloudServerProxyHttp.CSCloudServerClient(new InstanceContext(client));
                logService = new CSCloudLogServerProxy.CSCloudLogServiceClient();

                connected = client.Connect(server, logService).Result == CSCloud.Enums.CSCloudResult.ERROR;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Could not connect to server: {0}\n{1}", ex.Message, ex.StackTrace));
            }

            CSCloudResponse response = null;
            if (connected)
            {
                Console.WriteLine("Connected to the server.");
                Console.WriteLine("The client will exit automatically when all server commands have been completed.");

                response = new CSCloudResponse
                {
                    Result = CSCloud.Enums.CSCloudResult.SUCCESS,
                };
                client.LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
            }
            else
            {
                Console.WriteLine("Could not connect to the server.");
                if (client != null) client.LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
            }

            Console.WriteLine("Press [ENTER] to quit.");

            Console.ReadLine();
        }
    }
}
