using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Machine
{
    // 클라이언트들이 모여있는 클래스
    public class ClientInfo
    {
        public bool Line { get { return IsLine; } }
        public TcpClient ClientData { get { return Client; } }

        List<ClientInfo> list = new List<ClientInfo>();
        TcpClient Client;
        bool IsLine;
        int ID;

        public ClientInfo()
        {
        }

        public void SetClient(TcpClient client, int ID, bool isBaord)
        {
            ClientInfo info = new ClientInfo();
            info.Client = client;
            info.IsLine = isBaord;
            info.ID = ID;
            list.Add(info);
        }

        public List<ClientInfo> GetClient()
        {
            return list;
        }

        public void DeleteClient(int ID)
        {
            ClientInfo info = list.Find(c => c.ID == ID);
            info.Client.Close();
            info.Client.Dispose();
            list.Remove(info);
        }
    }
}
