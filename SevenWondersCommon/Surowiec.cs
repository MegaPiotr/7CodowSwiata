using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Surowiec
    {
        public Surowiec(RodzajSurowca rodzaj, int ilosc=0)
        {
            Rodzaj = rodzaj;
            Ilosc = ilosc;
        }
        public RodzajSurowca Rodzaj { get; set; }
        public int Ilosc { get; set; }
    }
}
