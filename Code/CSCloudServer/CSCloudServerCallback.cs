using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CSCloudServer
{
    //public class CSCloudServerCallback : ICSCloudServerCallback
    //{
    //    public void CommandExecuted(CSCloudResponse response)
    //    {
    //        //TODO Log command
    //        //TODO Save command results in DB

    //        for (int idx = 0; idx < CommandWorkFlow.Length; idx++)
    //        {
    //            if (string.Equals(response.Request.Command.Code.ToString(), CommandWorkFlow[idx].Trim()))
    //            {
    //                if (idx < CommandWorkFlow.Length - 1)
    //                {
    //                    var callback = OperationContext.Current.GetCallbackChannel<ICSCloudClient>();
    //                    CSCloudCommand command = new CSCloudCommand();
    //                    command.Code = (CSCloudCommandCode)Enum.Parse(typeof(CSCloudCommandCode), CommandWorkFlow[idx + 1], true);
    //                    SendCommand(callback, command);
    //                }
    //            }
    //        }
    //    }
    //}
}
