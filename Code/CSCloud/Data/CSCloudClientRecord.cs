using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSCloud.Data
{
    [DataContract]
    public class CSCloudClientRecord
    {
        [DataMember]
        public string ClientName;

        [DataMember]
        public bool IsActive;
    }
}
