using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class GraKlient : Gra
    {
        private string Host;
        private int Port;

        //todo te cztery ubić Dispose
        private TcpClient Klient;
        private NetworkStream Stream;
        private StreamWriter Writer;
        private StreamReader Reader;

        public string Blad { get;private set; }

        public GraKlient(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public bool Polacz()
        {
            try
            {
                Klient = new TcpClient();
                Klient.Connect(Host, Port);
                Stream = Klient.GetStream();
                Stream.ReadTimeout = 2000;
                Reader = new StreamReader(Stream);
                Writer = new StreamWriter(Stream);
            }
            catch(Exception ex)
            {
                Blad = ex.Message;
                return false;
            }
            Blad = null;
            return true;
        }

        public void Wyslij(Ruch ruch, Transakcja transakcja = null)
        {
            var dane = new PakietDanych(ruch, transakcja);
            string json = JsonConvert.SerializeObject(dane);
            Writer?.Write(json);
        }
        //todo odbieranie danych

        #region Gra

        public override void WykonajRuch(Ruch ruch, Transakcja transakcja = null)
        {
            base.WykonajRuch(ruch, transakcja);
            Wyslij(ruch, transakcja);
        }
 
        protected override void AktualizujRuch(Ruch ruch, Transakcja transakcja = null)
        {
            base.WykonajRuch(ruch, transakcja);
        }

        #endregion
    }
}
