using CSCloud.Data;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSCloudClient
{
    public class CSCloudClient : CSCloudServerProxyHttp.ICSCloudServerCallback
    {
        public const string KEY_PASSWORD = "password";

        private CSCloudServerProxyHttp.ICSCloudServer server;
        private static CSCloudLogServerProxy.ICSCloudLogService logService;

        static CSCloudClient()
        {
            logService = new CSCloudLogServerProxy.CSCloudLogServiceClient();
        }

        //string ICSCloudClient.GetName()
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

            logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR);

            return response;
        }

        private static void logResponse(CSCloudResponse response, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
        {
            CSCloudLogEntry log = new CSCloudLogEntry();
            log.Date = DateTime.UtcNow;
            log.Severity = severity;
            StringBuilder sb = new StringBuilder();
            if (message != null) sb.AppendLine().Append(message);
            else sb.Append(response.ToString());
            if (stackTrace != null) sb.AppendLine().AppendLine(stackTrace);
            log.Message = sb.ToString();
            logService.Log(log);
        }

        private CSCloudResponse Compile(CSCloudRequest request)
        {
            //throw new NotImplementedException();
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                Console.WriteLine("Compiled stuff..."); //TODO JBG
                response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                logResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                //TODO JBG Success with warning condition
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        private CSCloudResponse Test(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                Console.WriteLine("Tested stuff..."); //TODO JBG
                response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                logResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                //TODO JBG Success with warning condition
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        private CSCloudResponse Report(CSCloudRequest request)
        {
            CSCloudResponse response = new CSCloudResponse();
            response.Request = request;

            try
            {
                Console.WriteLine("Nothing to report..."); //TODO JBG
                response.Result = CSCloud.Enums.CSCloudResult.ERROR; //TODO JBG Testing
                response.Messages = new string[] { "Nothing to report..." };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
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
                logResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
                server.Disconnect();
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return response;
        }

        public bool Connect(CSCloudServerProxyHttp.ICSCloudServer server)
        {
            this.server = server;

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
                response.Result = CSCloud.Enums.CSCloudResult.SUCCESS;
                logResponse(response, CSCloud.Enums.CSCloudSeverity.INFO);
            }
            catch (Exception ex)
            {
                response.Result = CSCloud.Enums.CSCloudResult.ERROR;
                response.Messages = new string[] { ex.Message };
                logResponse(response, CSCloud.Enums.CSCloudSeverity.ERROR, response.ToString(), ex.StackTrace);
            }

            return connected;
        }

    }
}
