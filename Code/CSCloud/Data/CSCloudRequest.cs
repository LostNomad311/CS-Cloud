using System.Runtime.Serialization;

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
            return Command == null ? string.Empty : string.Format("Command: {0}", this.Command.ToString());
        }
    }
}
