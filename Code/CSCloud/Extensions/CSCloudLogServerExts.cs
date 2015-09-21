using CSCloud.Data;
using CSCloud.Interfaces;
using System;
using System.Diagnostics;

namespace CSCloud.Extensions
{
    //TODO JBG These extension methods can not be used due to the generted proxies
    public static class CSCloudLogServerExts
    {
        public static void LogResponse(this ICSCloudLogService logService, CSCloudResponse response, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
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

        public static void LogRequest(this ICSCloudLogService logService, CSCloudRequest request, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
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
