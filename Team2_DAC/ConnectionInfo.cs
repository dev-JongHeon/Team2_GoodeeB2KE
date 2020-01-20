using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Team2_DAC
{
    public class ConnectionInfo
    {
        public string ConnectionString
        {
            get
            {
                string connStr = string.Empty;

                XmlDocument configXml = new XmlDocument();
                configXml.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/ConnectionInfo.xml");
                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");
                foreach (XmlNode xmlNode in addNodes)
                {
                    if (xmlNode.Attributes["key"].InnerText == "TEAM2")
                    {
                        connStr = ((XmlCDataSection)xmlNode.ChildNodes[0]).InnerText;
                        break;
                    }
                }
                return connStr;
            }
        }
    }
}
