using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class egitimBilListe
    {
        egitimBilNode headNode;
        int id = 0;
     
        public void Add(string okulAdiA, string turuA, string bolumuA, string baslangicTarihiA, string bitisTarihiA, string notOrtalamasiA)
        {
            string id = ReturnID();
            egitimBilNode adding = new egitimBilNode(id, okulAdiA, turuA, bolumuA, baslangicTarihiA, bitisTarihiA, notOrtalamasiA);

            if (headNode == null)
            {
                headNode = adding;
            }
            else
            {
                egitimBilNode iter = headNode;

                while (iter.next != null)
                {
                    iter = iter.next;
                }
                iter.next = adding;
            }
        }
        public void Listing()
        {
            egitimBilNode iter = headNode;
            Console.WriteLine("/////////////////// Eğitim Bilgileri ///////////////////");
            while (iter != null)
            {

                Console.WriteLine(iter.okulAd + "\n" + iter.okulTur + "\n" + iter.bolum + "\n" + iter.basTarih + "\n" + iter.bitTarih + "\n" + iter.notOrt + "\n");
                iter = iter.next;
            }
            Console.WriteLine("_____________________________________________________");
        }
        public void Delete(string id)
        {
            if (headNode.id == id)
            {
                headNode = headNode.next;
            }
            else
            {
                egitimBilNode iter = headNode;
                egitimBilNode iter2 = iter.next;
                while (iter2.id != id)
                {
                    iter = iter.next;
                    iter2 = iter2.next;
                }
                iter.next = iter.next.next;
            }
        }
        public void Update(string id, string okulAdiU, string turuU, string bolumuU, string baslangicTarihiU, string bitisTarihiU, string notOrtalamasiU)
        {
            egitimBilNode iter = headNode;

            while (iter.id != id)
            {
                iter = iter.next;
            }
            iter.okulAd = okulAdiU;
            iter.okulTur = turuU;
            iter.bolum = bolumuU;
            iter.basTarih = baslangicTarihiU;
            iter.bitTarih = bitisTarihiU;
            iter.notOrt = notOrtalamasiU;
        }
        public int count()
        {
            egitimBilNode iter = headNode;
            int sayac = 0;
            while (iter != null)
            {
                sayac++;
                iter = iter.next;
            }
            return sayac;
        }
        public egitimBilNode egitimListesi(int i)
        {
            egitimBilNode iter = headNode;
            int sayac = 0;
            if (count() < i)
            {
                Console.WriteLine("Hata: index out of range!");
                return null;
            }
            else
            {
                while (iter != null)
                {
                    if (sayac == i)
                    {
                        return iter;
                    }
                    sayac++;
                    iter = iter.next;
                }
            }
            return null;

        }
        private string ReturnID()
        {
            id++;
            return "egitim" + id;
        }
    }

}
