using System;
using System.Net.Sockets;
using System.IO;
using NetworkUtility.Tcp.Common;
using System.Collections.Generic;

namespace NetworkUtility.Tcp.Server
{
    public class ClientReference
    {
     
        static int _bufferSize = 1500;
        public static int BufferSize
        {
            get
            {
                return _bufferSize;
            }
            set
            {
                _bufferSize = value;
            }
        }

        public string IP { get; set; }
        public Guid Id { get; private set; }
        public Socket sock { get; set; }
        public byte[] Buffer { get; set; }

        public DateTime ConnectionTime { get; private set; }
        public int Recieved { get; set; }
        public int RecieveCalls { get; set; }
        public int Fragments { get; set; }

        public static int TotalRecieved { get; set; }
        public static int TotalBytes { get; set; }

        public MemoryStream ms;
        //public TcpClient mycl;
        public int BytesReceived { get; set; }

        
        public ClientReference(Socket s)
        {
            //mycl.Client = s;
            IP = s.LocalEndPoint.ToString();
            ConnectionTime.ToShortTimeString();
            ConnectionTime = DateTime.Now.ToLocalTime();
            Id = SequentialGuid.GenerateGuid();
            //Id = Guid.NewGuid();
            sock = s;
            Buffer = new byte[BufferSize];
            ms = new MemoryStream();
            Fragments = 0;
           
        }
       
       
    }
}
