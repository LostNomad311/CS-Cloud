using CSCloud.Data;
using System.ServiceModel;

namespace CSCloud.Interfaces
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICSCloudClient))]
    public interface ICSCloudServer
    {
        [OperationContract(IsInitiating = true)]
        bool Connect(string clientName, string password);

        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void Disconnect(string ClientName);

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
