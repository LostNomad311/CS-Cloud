using CSCloud.Data;
using CSCloud.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CSCloud.Interfaces
{
    [ServiceContract]
    public interface ICSCloudLogService
    {
        [OperationContract(IsOneWay = true)]
        void Log(CSCloudLogEntry logEntry);

        [OperationContract]
        CSCloudLogEntry[] GetLog();
    }
}
