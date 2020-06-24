using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    /// <summary>
    /// Implementacja tego co dzieje się w grze, pomijając komunikację między komputerami
    /// </summary>
    public abstract class Gra
    {
        public bool CzyMoznaWykonacRuch(Ruch ruch, Transakcja transakcja = null)
        {
            return false;
        }

        public List<Surowiec> BrakujaceSurowce(Ruch ruch)
        {
            return new List<Surowiec>();
        }

        public virtual void WykonajRuch(Ruch ruch, Transakcja transakcja = null)
        {

        }

        protected abstract void AktualizujRuch(Ruch ruch, Transakcja transakcja = null);
    }
}
