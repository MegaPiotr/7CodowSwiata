using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Efekt
    {
        public Efekt(Dzialanie dzialanie, int ilosc = 1)
        {
            Ilosc = ilosc;
            Dzialanie = dzialanie;
        }
        public int Ilosc { get; set; }
        public Dzialanie Dzialanie { get; set; }
    }
    public enum Dzialanie
    {
        DodajDrewno,
        DodajZloto,
        DodajKamien,
        DodajSzklo,
        DodajPapier,
        DodajTkanine
    }
}
