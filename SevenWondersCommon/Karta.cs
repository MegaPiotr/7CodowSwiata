﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SevenWondersCommon
{
    public class Karta
    {
        public string Nazwa { get; set; }
        public List<Surowiec> Koszt { get; set; }
        public List<Efekt> Efekty { get; set; }
        public List<Symbol> Symbole { get; set; }
        public Karta KartaRabatowa { get; set; }
        public List<Karta> KartyDoRabatu { get; set; }
        public object Obrazek { get; set; }
        public KolorKarty Kolor { get; set; }
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
    public enum KolorKarty
    {
        Czerwona,
        Zielona,
        Niebieska,
        Zolta,
        Brazowa,
        Szara,
        Fioletowa
    }
}
