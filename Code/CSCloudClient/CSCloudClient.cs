using CSCloud.Data;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace CSCloudClient
{
    public class CSCloudClient : CSCloudServerProxyHttp.ICSCloudServerCallback
    {
        public const string KEY_PASSWORD = "password";

        private CSCloudServerProxyHttp.ICSCloudServer server;
        private CSCloudLogServerProxy.ICSCloudLogService logService;

        public string GetName()
        {
            return string.Format("{0}_{1:yyMMdd}_{1:HHmmss}", Environment.MachineName, DateTime.UtcNow);
        }

        //public async Task<CSCloudResponse> ICSCloudClient.ExecuteCommandAsync(CSCloudRequest request)
        //{
        //    CSCloudRequest request = (CSCloudRequest)command;

        //    XmlSerializer deserializer = new XmlSerializer(typeof(CSCloudCommand));
        //    StringReader sr = new StringReader(request.Command.Text);
        //    CSCloudCommand csCommand = (CSCloudCommand)deserializer.Deserialize(sr);
        //    Task<CSCloudResponse> task = null;

        //    switch (csCommand.Code)
        //    {
        //        case CSCloud.Enums.CSCloudCommandCode.COMPILE:
        //            task = Task<CSCloudResponse>.Factory.StartNew(() => { return Compile(request); });
        //            break;
        //        case CSCloud.Enums.CSCloudCommandCode.TEST:
        //            task = Task<CSCloudResponse>.Factory.StartNew(() => { return Test(request); });
        //            break;
        //        case CSCloud.Enums.CSCloudCommandCode.REPORT:
        //            task = Task<CSCloudResponse>.Factory.StartNew(() => { return Report(request); });
        //            break;
        //        case CSCloud.Enums.CSCloudCommandCode.DISCONNECT:
        //            task = Task<CSCloudResponse>.Factory.StartNew(() => { return Disconnect(request); });
        //            break;
        //        default:
        //            task = Task<CSCloudResponse>.Factory.StartNew(() => { return InvalidCommand(request); });
        //            break;
        //    }

        //    return await task;
        //}

        public CSCloudResponse ExecuteCommand(CSCloudRequest request)
        {
            CSCloudCommand csCommand = CSCloudCommand.FromXml(request.Command.GetXml());
            CSCloudResponse response = null;

            switch (csCommand.Code)
            {
                case CSCloud.Enums.CSCloudCommandCode.COMPILE:
                    response = Compile(request);
                    break;
                case CSCloud.Enums.CSCloudCommandCode.TEST:
                    response = Test(request);
                    break;
                case CSCloud.Enums.CSCloudCommandCode.REPORT:
                    response = Report(request);
                    break;
                case CSCloud.Enums.CSCloudCommandCode.DISCONNECT:
                    response = Disconnect(request);
                    break;
                default:
                    response = InvalidCommand(request);
                    break;
            }

            return (CSCloudResponse)response;
        }

        private CSCloudResponse InvalidCommand(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;
            response.Result = CSCloud.Enums.CSCloudResult.ERROR;
            string err = string.Format("Invalid command: {0}", request.Command.Code.ToString());
            response.Messages = new string[] { err };

            LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR);

            return response;
        }

        private CSCloudResponse Compile(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                //TODO JBG Success with warning condition
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        private CSCloudResponse Test(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                response.Result = CSCloud.Enums.CSCloudResult.WARNIG; //TODO JBG Testing
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                //TODO JBG Success with warning condition
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        private CSCloudResponse Report(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR; //TODO JBG Testing
                response.Messages = new string[] { "Nothing to report..." }; //TODO JBG
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        private CSCloudResponse Disconnect(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                server.Disconnect(this.GetName());
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        public CSCloudResponse Connect(CSCloudServerProxyHttp.ICSCloudServer server, CSCloudLogServerProxy.ICSCloudLogService logService)
        {
            if (server == null) throw new ArgumentNullException("server");

            this.server = server;
            this.logService = logService;

            CSCloudResponse response = new CSCloudResponse();
            CSCloudRequest request = new CSCloudRequest();
            request.ClientName = this.GetName();
            request.Command = new CSCloudCommand();
            request.Command.Code = CSCloud.Enums.CSCloudCommandCode.CONNECT;
            response.Request = request;

            bool connected = false;
            try
            {
                connected = server.Connect(this.GetName(), ConfigurationManager.AppSettings[KEY_PASSWORD]);

                if (connected)
                {
                    if (logService == null)
                    {
                        response.Result = CSCloud.Enums.CSCloudResult.WARNIG;
                        var msg = string.Format("No Log Service is available , client {0} can not log it's activities", this.GetName());
                        response.Messages = new string[] { msg };

                        Debug.WriteLine(msg);
                    }
                    else
                    {
                        response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                        LogResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                    }
                }
                else
                {
                    response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                    LogResponse(response, CSCloud.Enums.CSCloudSeverity.WARNING); //TODO JBG Decide on how conditions like these are logged
                }
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                LogResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        public void LogResponse(CSCloudResponse response, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
        {
            if (logService == null) return;

            try
            {
                if (response == null) throw new ArgumentNullException("response");

                logService.Log(CSCloudLogEntry.FromResponse(response, severity, message, stackTrace));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Could not log response to Log Service: {2}\n{0}\n{1}", ex.Message, ex.StackTrace, response.ToString()));
            }
        }

        public void LogRequest(CSCloudRequest request, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
        {
            if (logService == null) return;

            try
            {
                if (request == null) throw new ArgumentNullException("request");

                logService.Log(CSCloudLogEntry.FromRequest(request, severity, message, stackTrace));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Could not log request to Log Service: {2}\n{0}\n{1}", ex.Message, ex.StackTrace, request.ToString()));
            }
        }

    }
}
