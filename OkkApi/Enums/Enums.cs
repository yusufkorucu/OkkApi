using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkApi.Enums
{
    public class Enums
    {
        public enum Job
        {
            Student=1,
            Academician=2,
            Security=3,
            Dean=4,
            Undefined=5,
            Special=6,
            Graduate=7

        }
        public enum Cins
        {
            Erkek = 1,
            Kadın = 2

        }

        public enum SpecialStat
        {
            Hamile = 1,
            KronikKalp = 2

        }

        public enum HastaStat
        {
            Risksiz = 1,
            Riskli = 2,
            KontrolEdilmeli=3,
            Acil=4,
            DurumBilgisiYok=5

        }
    }
}
