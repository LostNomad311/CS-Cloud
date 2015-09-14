using CSCloud.DAL;
using CSCloud.Data;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CSCloudLogServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CSCloudLogService : ICSCloudLogService
    {
        public void Log(CSCloudLogEntry logEntry)
        {
            using (CSCloudEntities db = new CSCloudEntities())
            {
                db.Logs.Add(LogToModel(logEntry));
                db.SaveChanges();
            }
        }

        private Log LogToModel(CSCloudLogEntry log)
        {
            var l = new Log();
            l.Date = log.Date;
            l.Severity = log.Severity.ToString();
            l.Message = log.Message;
            l.StackTrace = log.StackTrace;

            return l;
        }

        private CSCloudLogEntry ModelToLogEntry(Log log)
        {
            return new CSCloudLogEntry
            {
                Date = log.Date,
                ID = log.id,
                Message = log.Message,
                Severity = (CSCloud.Enums.CSCloudSeverity)Enum.Parse(typeof(CSCloud.Enums.CSCloudSeverity), log.Severity, true),
                StackTrace = log.StackTrace
            };
        }

        public CSCloudLogEntry[] GetLog()
        {
            using (CSCloudEntities db = new CSCloudEntities())
            {
                var logEntries = new List<CSCloudLogEntry>(db.Logs.Count());
                foreach (var l in db.Logs)
                {
                    logEntries.Add(ModelToLogEntry(l));
                }

                return logEntries.ToArray();
            }
        }
    }
}
