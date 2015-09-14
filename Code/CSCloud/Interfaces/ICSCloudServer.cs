using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CSCloud.Data;

namespace CSCloud.Interfaces
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICSCloudClient))]
    public interface ICSCloudServer
    {
        [OperationContract(IsInitiating = true)]
        bool Connect(string clientName, string password);

        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void Disconnect();

        [OperationContract]
        CSCloudCommandRecord[] GetExecutedCommands();

        [OperationContract]
        CSCloudClientRecord[] GetClients(bool OnlyActive);

        //ICSCloudServerCallback Callback { get;  }
    }

    //[ServiceContract]
    //public interface ICSCloudServerCallback
    //{
    //    [OperationContract(IsInitiating = false, IsOneWay = true)]
    //    void CommandExecuted(CSCloudResponse response);
    //}
}
