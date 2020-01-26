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
        public Dictionary<RodzajSurowca, int> Zasoby { get; set; }
        public Dictionary<WartoscZetonuWojny, int> ZetonyWojny { get; set; }
        public List<Karta> Karty { get; set; }
        public Miasto Miasto { get; set; }
        public List<Cod> Coda { get; set; }
    }
    public enum WartoscZetonuWojny
    {
        Minus1,
        Plus1,
        Plus3,
        Plus5
    }
}
