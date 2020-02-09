using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class ZetonWojny
    {
        public WartoscZetonuWojny Wartosc { get; set; }
        public int Ilosc { get; set; }
    }
    public enum WartoscZetonuWojny
    {
        Minus1,
        Plus1,
        Plus3,
        Plus5
    }
}
