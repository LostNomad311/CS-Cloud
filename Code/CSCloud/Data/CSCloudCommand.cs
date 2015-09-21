using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CSCloud.Interfaces;
using CSCloud.Enums;
using System.Xml.Serialization;
using System.IO;

namespace CSCloud.Data
{
    [XmlRoot("command")]
    [DataContract]
    public class CSCloudCommand
    {
        [DataMember]
        [XmlElement("code")]
        public CSCloudCommandCode Code;

        public string GetXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, this);

            return sw.ToString();
        }

        public static CSCloudCommand FromXml(string xml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(CSCloudCommand));
            StringReader sr = new StringReader(xml);
            return (CSCloudCommand)deserializer.Deserialize(sr);
        }

        public override string ToString()
        {
            return string.Format("Code: {0}", this.Code.ToString());
        }
    }
}
