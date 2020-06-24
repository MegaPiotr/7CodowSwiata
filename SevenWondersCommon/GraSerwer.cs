using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class GraSerwer : Gra
    {
        private int Port;
        private TcpListener Serwer;

        public GraSerwer(int port)
        {
            Port = port;
        }

        public bool Uruchom()
        {
            Serwer = new TcpListener(IPAddress.Any, Port);

            //TcpListener server = new TcpListener(IPAddress.Any, 9999);
            //// we set our IP address as server's address, and we also set the port: 9999

            //server.Start();  // this will start the server

            //while (true)   //we wait for a connection
            //{
            //    TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

            //    NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

            //    byte[] hello = new byte[100];   //any message must be serialized (converted to byte array)
            //    hello = Encoding.Default.GetBytes("hello world");  //conversion string => byte array

            //    ns.Write(hello, 0, hello.Length);     //sending the message

            //    while (client.Connected)  //while the client is connected, we look for incoming messages
            //    {
            //        byte[] msg = new byte[1024];     //the messages arrive as byte array
            //        ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
            //        Console.WriteLine(encoder.GetString(msg).Trim('')); //now , we write the message as string
            //    }
            //}
            return true;
        }

        #region Gra

        public override void WykonajRuch(Ruch ruch, Transakcja transakcja = null)
        {
            base.WykonajRuch(ruch, transakcja);
        }

        protected override void AktualizujRuch(Ruch ruch, Transakcja transakcja = null)
        {
            base.WykonajRuch(ruch, transakcja);
        }

        #endregion
    }
}
