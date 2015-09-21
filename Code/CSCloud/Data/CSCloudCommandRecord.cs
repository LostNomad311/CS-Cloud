using CSCloud.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSCloud.Data
{
    /// <summary>
    /// Represents a persisted CSCloudCommand record
    /// </summary>
    [DataContract]
    public class CSCloudCommandRecord
    {
        [DataMember]
        public CSCloudCommandCode Code;

        [DataMember]
        public string ClientName;

        [DataMember]
        public CSCloudResult Result;

        [DataMember]
        public DateTime Date;

        //TODO JBG Need any associated messages
    }
}
