using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class isYeriListNode
    {
        public string id, isYeriAd, Adres, Pozisyonu, Sure;
        public isYeriListNode next;
        public isYeriListNode(string idN,string isYeriAdN, string AdresN, string PozisyonuN, string SureN)
        {
            id = idN;
            isYeriAd = isYeriAdN;
            Adres = AdresN;
            Pozisyonu = PozisyonuN;
            Sure = SureN;
            next = null;
        }
    }
}
