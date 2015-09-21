using CSCloud.Data;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCloudServer
{
    public class CommandSentEventArgs : EventArgs
    {
        public ICSCloudClient Client { get; set; }
        public CSCloudCommand Command { get; set; }

        public CommandSentEventArgs(ICSCloudClient client, CSCloudCommand command)
        {
            this.Client = client;
            this.Command = command;
        }
    }
}
