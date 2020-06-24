using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Ruch
    {
        public Ruch(Gracz gracz)
        {
            Gracz = gracz;
        }
        public Ruch(Gracz gracz, Karta karta, TypRuchu typ) : this(gracz)
        {
            Karta = karta;
            Typ = typ;
        }
        public Gracz Gracz { get; set; }
        public Karta Karta { get; set; }
        public TypRuchu Typ { get; set; }
    }
    public enum TypRuchu
    {
        Budowa,
        Sprzedaz,
        Cud
    }
}
