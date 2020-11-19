using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class isYeriList
    {
        isYeriListNode headNode;

        int id = 0;
        public void Add(string isyeriAdiA, string isyeriAdresiA, string goreviA, string suresiA)
        {
            string id = ReturnID();
            isYeriListNode eklenecek = new isYeriListNode(id, isyeriAdiA, isyeriAdresiA, goreviA, suresiA);

            if (headNode == null)
            {
                headNode = eklenecek;
            }
            else
            {
                isYeriListNode iter = headNode;

                while (iter.next != null)
                {
                    iter = iter.next;
                }
                iter.next = eklenecek;
            }
        }
        public void listing()
        {
            isYeriListNode iter = headNode;
            Console.WriteLine("////////////////// İş Yeri Bilgileri //////////////////");
            while (iter != null)
            {
                Console.WriteLine(iter.isYeriAd + "\n" + iter.Adres + "\n" + iter.Pozisyonu + "\n" + iter.Sure + "\n");
                iter = iter.next;
            }
            Console.WriteLine("_____________________________________________________");
        }
        public void delete(string id)
        {
            if (headNode.id == id)
            {
                headNode = headNode.next;
            }
            else
            {
                isYeriListNode iter = headNode;
                isYeriListNode iter2 = iter.next;
                while (iter2.id != id)
                {
                    iter = iter.next;
                    iter2 = iter2.next;
                }
                iter.next = iter.next.next;
            }
        }

        private string ReturnID()
        {
            id++;
            return "isyeri" + id;
        }
        public void Update(string idU, string isyeriAdiU, string isyeriAdresiU, string goreviU, string suresiU)
        {
            isYeriListNode iter = headNode;

            while (iter.id != idU)
            {
                iter = iter.next;
            }
            iter.isYeriAd = isyeriAdiU;
            iter.Adres= isyeriAdresiU;
            iter.Pozisyonu = goreviU;
            iter.Sure = suresiU;
        }
        public int count()
        {
            isYeriListNode iter = headNode;
            int sayac = 0;
            while (iter != null)
            {
                sayac++;
                iter = iter.next;
            }
            return sayac;
        }
        public isYeriListNode isyeribilgileri(int i)
        {
            isYeriListNode iter = headNode;
            int sayac = 0;
            if (count() < i)
            {
                Console.WriteLine("Hata");
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
        public void clear()
        {
            headNode = null;
        }
    }
}
