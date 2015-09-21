using CSCloud.Enums;
using System.Runtime.Serialization;
using System.Text;

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
            StringBuilder sb = new StringBuilder(string.Format("Result {0}", this.Result.ToString()));
            if (Request != null) sb.Append(string.Format(" - Request: {0}", this.Request.ToString()));
            if (this.Messages != null) sb.Append(" - Messages:").AppendLine().AppendLine(string.Join("\n", this.Messages));
            return sb.ToString();
        }
    }
}
