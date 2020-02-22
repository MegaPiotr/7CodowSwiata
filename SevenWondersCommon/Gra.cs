using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Gra
    {
        public List<Gracz> Gracze { get; set; }
        public bool Zaczeta { get; set; }
        private Ruch _Temp;

        public void WykonajRuch(Ruch ruch)
        {

        }
        public void CofnijRuch()
        {

        }
        public void ZaakceptujRuch()
        {

        }
        public void WykupSurowce(Gracz gracz, Gracz kontrahent, List<Surowiec> surowce)
        {

        }
    }
    public class Ruch
    {
        public Ruch(Gracz gracz)
        {
            Gracz = gracz;
        }
        public Ruch(Gracz gracz, Karta karta, TypRuchu typ ):this(gracz)
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
