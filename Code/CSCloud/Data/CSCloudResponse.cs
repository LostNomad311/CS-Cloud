using CSCloud.Enums;
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
    public class CSCloudResponse
    {
        [DataMember]
        public CSCloudResult Result;

        [DataMember]
        public string[] Messages;

        [DataMember]
        public CSCloudRequest Request;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(string.Format("Request: {0} - Result {1} - Messages:",
                this.Request.ToString(),
                this.Result.ToString()));
            if (this.Messages != null) sb.AppendLine().AppendLine(string.Join("\n", this.Messages));
            return sb.ToString();
        }
    }
}
