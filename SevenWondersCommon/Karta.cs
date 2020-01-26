using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Karta
    {
        public string Nazwa { get; set; }
        public Dictionary<RodzajSurowca, int> Koszt { get; set; }
        public List<Efekt> Efekty { get; set; }
        public List<Symbol> Symbole { get; set; }
        public Karta KartaRabatowa { get; set; }
        public List<Karta> KartyDoRabatu { get; set; }
        public string Obrazek { get; set; }
    }
    public enum Symbol
    {
        Zloto,
        Kamien,
        Drewno,
        Szklo,
        Papier,
        Tkanina,
        Wojna,
        Punkt,
        Moneta
    }
}
