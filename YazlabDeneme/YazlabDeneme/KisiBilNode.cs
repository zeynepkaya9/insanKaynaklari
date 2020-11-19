using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class KisiBilNode
    {
        public KisiBilNode right;
        public KisiBilNode left;
        public string Ad, Adres, TelNo, Eposta, DogumTarih, YabanciDil, Ehliyet;
        public egitimBilListe egitimBilListe;
        public isYeriList isYeriList;

        public KisiBilNode(string AdN, string AdresN, string TelNoN, string EpostaN, string DogumTarihN,string YabanciDilN,string EhliyetN,egitimBilListe egitimBilListeN,isYeriList isYeriListN)
        {
            Ad = AdN;
            Adres = AdresN;
            TelNo = TelNoN;
            Eposta = EpostaN;
            DogumTarih = DogumTarihN;
            YabanciDil = YabanciDilN;
            Ehliyet = EhliyetN;
            egitimBilListe = egitimBilListeN;
            isYeriList = isYeriListN;
            right = null;
            left = null;

        }
       
    }
}
