using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCloud.Interfaces;

namespace CSCloudServer
{
    public class ClientConnectedEventArgs : EventArgs
    {
		public ICSCloudClient ConnectedClient { get; set; }

        public ClientConnectedEventArgs(ICSCloudClient client)
		{
            this.ConnectedClient = client;
		}
    }
}
