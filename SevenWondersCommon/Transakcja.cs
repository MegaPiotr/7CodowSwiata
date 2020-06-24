using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Transakcja
    {
        public Gracz Kupujacy { get; set; } 
        public Gracz Dostawca { get; set; }
        public List<Surowiec> Surowce { get; set; }
    }
}
