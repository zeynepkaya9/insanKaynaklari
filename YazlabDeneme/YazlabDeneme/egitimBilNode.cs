using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class egitimBilNode
    {
        public string id,okulAd, okulTur, bolum, basTarih, bitTarih, notOrt;
        public egitimBilNode next;
        public egitimBilNode(string idN,string okulAdN,string okulTurN, string bolumN, string basTarihN, string bitTarihN, string notOrtN)
        {
            id = idN;
            okulAd = okulAdN;
            okulTur = okulTurN;
            bolum = bolumN;
            basTarih = basTarihN;
            bitTarih = bitTarihN;
            notOrt = notOrtN;
            next = null;

        }
    }
}
