using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSCloud.Data
{
    [DataContract]
    public class CSCloudRequest
    {
        [DataMember]
        public CSCloudCommand Command { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        public override string ToString()
        {
            return string.Format("Command: {0}", this.Command.ToString());
        }
    }
}
