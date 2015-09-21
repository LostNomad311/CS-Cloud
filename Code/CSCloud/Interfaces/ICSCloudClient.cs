using CSCloud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CSCloud.Interfaces
{
    //[ServiceContract]
    public interface ICSCloudClient
    {
        [OperationContract]
        string GetName();

        //[OperationContract(AsyncPattern = true)]
        //Task<CSCloudResponse> ExecuteCommandAsync(CSCloudRequest command);

        [OperationContract]
        CSCloudResponse ExecuteCommand(CSCloudRequest command);
    }
}
