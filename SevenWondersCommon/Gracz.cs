using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Gracz
    {
        public string Nazwa { get; set; }
        public List<Surowiec> Zasoby { get; set; }
        public List<ZetonWojny> ZetonyWojny { get; set; }
        public List<Karta> Karty { get; set; }
        public List<Karta> KartyWRece { get; set; }
        public List<Karta> KartyCzekajace { get; set; }
        public Miasto Miasto { get; set; }
        public List<Cod> CodaZbudowane { get; set; }
    }
    
}
