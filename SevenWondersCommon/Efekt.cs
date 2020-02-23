using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Efekt
    {
        public Efekt(TypEfektu typ, Dzialanie dzialanie, int ilosc = 1)
        {
            Ilosc = ilosc;
            Dzialanie = dzialanie;
            Typ = typ;
        }
        public int Ilosc { get; set; }
        public Dzialanie Dzialanie { get; set; }
        public TypEfektu Typ { get; set; }
    }
    public enum Dzialanie
    {
        DodajDrewno,
        DodajZloto,
        DodajKamien,
        DodajSzklo,
        DodajPapier,
        DodajTkanine,
        DodajCegle,
        DodajPunkty,
        DodajDrewnoKamienZlotoLubCegle,
        DodajPunktyWojny,
        TaniHandelZLewymSasiadem,
        TaniHandelZPrawymSasiadem,
        KopiowanieGildiiOdSasiadow,
    }
    public enum TypEfektu
    {
        Natychmiastowy,
        Produkcja,
        JednorazowayEra,
        JednorazowyGra,
        LiczeniePunktow,
        Pojedynek,
        Handel
    }
}
