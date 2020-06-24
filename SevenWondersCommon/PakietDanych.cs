using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class PakietDanych
    {
        public Ruch Ruch { get; set; }
        public Transakcja Transakcja { get; set; }

        public PakietDanych(Ruch ruch, Transakcja transakcja = null)
        {
            Ruch = ruch;
            Transakcja = transakcja;
        }
    }
}
