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
    /// <summary>
    /// 연결정보를 담고있는 공통 DAC
    /// </summary>
    public class ConnectionInfo
    {
        public string ConnectionString
        {
            //XML파일에 있는 연결정보를 가져옴
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
