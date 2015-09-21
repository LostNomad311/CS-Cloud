using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCloudAdmin
{
    public class CSCloudClientDummy : CSCloudServerProxy.ICSCloudServerCallback
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }

        public CSCloudServerProxy.CSCloudResponse ExecuteCommand(CSCloudServerProxy.CSCloudRequest command)
        {
            throw new NotImplementedException();
        }
    }
}