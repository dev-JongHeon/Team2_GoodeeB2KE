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
        public TcpClient Client { get; set; }
        public bool IsBoard { get; set; }
        public int ID { get; set; }
    }
}
