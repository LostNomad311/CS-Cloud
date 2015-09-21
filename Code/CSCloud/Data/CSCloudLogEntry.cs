using CSCloud.Enums;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace CSCloud.Data
{
    [DataContract]
    public class CSCloudLogEntry
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public CSCloudSeverity Severity { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        public static CSCloudLogEntry FromMessage(CSCloudSeverity severity, string messgae, string stackTrace = null)
        {
            return new CSCloudLogEntry
            {
                Date = DateTime.UtcNow,
                Severity = severity,
                Message = messgae,
                StackTrace = stackTrace,
            };
        }

        public static CSCloudLogEntry FromRequest(CSCloudRequest request, CSCloudSeverity severity, string message, string stackTrace = null)
        {
            if (request == null) return null;

            CSCloudLogEntry log = new CSCloudLogEntry();
            log.Date = DateTime.UtcNow;
            log.Severity = severity;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(request.ToString());
            if (message != null) sb.AppendLine().Append(message);
            if (stackTrace != null) sb.AppendLine().AppendLine(stackTrace);
            log.Message = sb.ToString();

            return log;
        }

        public static CSCloudLogEntry FromResponse(CSCloudResponse response, CSCloudSeverity severity, string message, string stackTrace = null)
        {
            if (response == null) return null;

            CSCloudLogEntry log = new CSCloudLogEntry();
            log.Date = DateTime.UtcNow;
            log.Severity = severity;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(response.ToString());
            if (message != null) sb.AppendLine().Append(message);
            if (stackTrace != null) sb.AppendLine().AppendLine(stackTrace);
            log.Message = sb.ToString();

            return log;
        }
    }
}
