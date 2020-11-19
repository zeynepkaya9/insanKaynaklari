using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YazlabDeneme
{
    class KisiBilAgac
    {
        bool ingBilme = false;
        int i=0;
        int j = 0;
        public List<KisiBilNode> filterList = new List<KisiBilNode>();

        KisiBilNode root;
        public void Add(string AdT, string AdresT, string TelNoT, string EpostaT, string DogumTarihT, string YabanciDilT,string EhliyetT, egitimBilListe egitimBilT,isYeriList isYeriBilT)
        {
            KisiBilNode eklenen = new KisiBilNode(AdT, AdresT, TelNoT, EpostaT, DogumTarihT, YabanciDilT, EhliyetT,egitimBilT,isYeriBilT);
            if (root == null)
            {
                root = eklenen;
            }
            else
            {
                KisiBilNode iter = root;
                KisiBilNode iter2;
                while (true)
                {
                    iter2 = iter;
                    if (string.Compare(iter.Ad, AdT) == -1)
                    {
                        iter = iter.right;
                        if (iter == null)
                        {
                            iter2.right = eklenen;
                            break;
                        }
                    }
                    else
                    {
                        iter = iter.left;
                        if (iter == null)
                        {
                            iter2.left = eklenen;
                            break;
                        }
                    }
                }
            }
        }
        public void Listing(KisiBilNode node) // Kişi bilgilerinin listelendiği fonksiyon bu fonksiyonu ana programda node parametresi olduğu için direk çağıramayız. lidting fonksiyonundan bu fonksiyona node atarak litingi çağırabiliriz.
        {
            if (node != null)
            {
                Listing(node.left);
                Console.WriteLine("/////////////////// Kişi Bilgileri ///////////////////" + "\n");
                Console.WriteLine(node.Ad + "\n" + node.Adres +
                    "\n" + node.TelNo + "\n" + node.Eposta +
                    "\n" + node.DogumTarih + "\n" +
                    node.YabanciDil + "\n" + node.Ehliyet);
                Console.WriteLine("\n" + "_____________________________________________________");
                if (node.egitimBilListe != null)
                {
                    node.egitimBilListe.Listing();
                }
                if (node.isYeriList != null)
                {
                    node.isYeriList.listing();
                }
              
                Listing(node.right);
            }
        }
        public KisiBilNode TakeNode;

        private KisiBilNode ReturnNode(KisiBilNode node, string SearchNode)
        {
            if (node != null)
            {
                ReturnNode(node.left, SearchNode);
                if (node.Ad == SearchNode)
                {
                    TakeNode = node;
                }
                ReturnNode(node.right, SearchNode);
            }
            return null;
        }
      
        public KisiBilNode ReturnTree(string SearchNode)
        {
            return ReturnNode(root, SearchNode);
        }
        public void listele()
        {
            Listing(root);
        }
        private KisiBilNode MinValue(KisiBilNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }
        public void Copy(KisiBilNode copied,KisiBilNode MinValue)
        {
            copied.Ad = MinValue.Ad;
            copied.Adres = MinValue.Adres;
            copied.TelNo = MinValue.TelNo;
            copied.Eposta = MinValue.Eposta;
            copied.DogumTarih = MinValue.DogumTarih;
            copied.YabanciDil = MinValue.YabanciDil;
            copied.Ehliyet = MinValue.Ehliyet;
        }
        private KisiBilNode Delete(KisiBilNode node, string AdD)
        {

            if (node == null) 
            {
                return node;
            }
            if (string.Compare(node.Ad, AdD) == 1) 
            {
                node.left = Delete(node.left, AdD);
            }
            else if (string.Compare(node.Ad, AdD) == -1)  
            {
                node.right = Delete(node.right, AdD); 
            }
            else  
            {
                if (node.left == null) 
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }

                Copy(node, MinValue(node.right)); 
                node.right = Delete(node.right, node.Ad);  
            }
            return node;

        }//Silme metodu bu metotta listing gibi ana fonksiyondan çağırılamaz delete2 den dolaylı olarak çağırılır
        public void Delete2(string AdD2)
        {
            root = Delete(root, AdD2);

        }
        string file = @"C:\Users\ZEYNEP\Desktop\YazLabVeri.txt";
        public void Write(KisiBilNode node)
        {


            if (node != null)
            {

                Write(node.left);
                FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);


                sw.WriteLine("||||||||||||||||||||KISI BILGILERI||||||||||||||||||||");
                sw.WriteLine(" ");
                sw.WriteLine("Kisi Adi Soyadi: " + node.Ad);
                sw.WriteLine("Kisi Adresi: " + node.Adres);
                sw.WriteLine("Kisi Telefonu: " + node.TelNo);
                sw.WriteLine("Kisi Mail: " + node.Eposta);
                sw.WriteLine("Kisi DogumTarihi: " + node.DogumTarih);
                sw.WriteLine("Kisi Yabanci Dil: " + node.YabanciDil);
                sw.WriteLine("Kisi Ehliyet: " + node.Ehliyet);
                sw.WriteLine(" ");
                
                for (int i = 0; i < node.egitimBilListe.count(); i++)
                {
                    sw.WriteLine("^^^^^^^^^^^^^^^^^^^^^^Egitim Bilgileri^^^^^^^^^^^^^^^^^^^^^^^^^");
                    sw.WriteLine(" ");
                    sw.WriteLine("Okul Adi: " + node.egitimBilListe.egitimListesi(i).okulAd);
                    sw.WriteLine("Okul Turu: " + node.egitimBilListe.egitimListesi(i).okulTur);
                    sw.WriteLine("Bolumu: " + node.egitimBilListe.egitimListesi(i).bolum);
                    sw.WriteLine("Baslangic Tarihi: " + node.egitimBilListe.egitimListesi(i).basTarih);
                    sw.WriteLine("Bitis Tarihi: " + node.egitimBilListe.egitimListesi(i).bitTarih);
                    sw.WriteLine("Not Ortalamasi: " + node.egitimBilListe.egitimListesi(i).notOrt);
                    sw.WriteLine("#########################################################");
                }
               
                for (int i = 0; i < node.isYeriList.count(); i++)
                {
                    sw.WriteLine("========================Isyeri Bilgileri========================");
                    sw.WriteLine(" ");
                    sw.WriteLine("Isyeri Adi: " + node.isYeriList.isyeribilgileri(i).isYeriAd);
                    sw.WriteLine("Isyeri Adresi: " + node.isYeriList.isyeribilgileri(i).Adres);
                    sw.WriteLine("Gorevi: " + node.isYeriList.isyeribilgileri(i).Pozisyonu);
                    sw.WriteLine("Calisma suresi: " + node.isYeriList.isyeribilgileri(i).Sure);
                    sw.WriteLine("#########################################################");
                }


                sw.WriteLine("------------------------------------------------------------------------");
                sw.Flush();

                sw.Close();
                fs.Close();
                Write(node.right);
            
            }

        }
        public void Read(KisiBilNode node)
        {
            string adSoyad = " ", adres = " ", telNo = " ", eposta = " ", dogumtarihi = " ", yabancidil = " ", ehliyet = " ";
            string isyeriAd = " ", isyeriAdres = " ", pozisyon = " ", calisilanSure = " ";
            string okulaAd = " ", okulTur = " ", bolum = " ", basTarih = " ", bitTarih = " ", notOrt = " ";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            string satir = sw.ReadLine();
            while (satir != null)
            {


                if (satir[0] == '|')
                {



                    for (int i = 0; i < 8; i++)
                    {
                        satir = sw.ReadLine();
                        if (satir.Contains("Kisi Adi"))
                        {
                            adSoyad = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Adresi"))
                        {
                            adres = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Telefonu"))
                        {
                            telNo = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Mail"))
                        {
                            eposta = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi DogumTarihi"))
                        {
                            dogumtarihi = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Yabanci Dil"))
                        {
                            yabancidil = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Ehliyet"))
                        {
                            ehliyet = stringAyikla(satir);
                        }
                    }
                }
                else if (satir[0] == '^')
                {
                    satir = sw.ReadLine();
                    egitimBilListe egitimliste = new egitimBilListe();

                    while (true)
                    {

                        satir = sw.ReadLine();
                        if (satir.Contains("Okul Adi"))
                        {
                            okulaAd = stringAyikla(satir);
                        }
                        else if (satir.Contains("Okul Turu"))
                        {
                            okulTur = stringAyikla(satir);
                        }
                        else if (satir.Contains("Bolumu"))
                        {
                            bolum = stringAyikla(satir);
                        }
                        else if (satir.Contains("Baslangic"))
                        {
                            basTarih = stringAyikla(satir);
                        }
                        else if (satir.Contains("Bitis"))
                        {
                            bitTarih = stringAyikla(satir);
                        }
                        else if (satir.Contains("Not"))
                        {
                            notOrt = stringAyikla(satir);
                        }
                        else if (satir[0] == '#')
                        {

                            egitimliste.Add(okulaAd, okulTur, bolum, basTarih, bitTarih, notOrt);
                        }
                        else if (satir[0] == '=')
                        {

                            satir = sw.ReadLine();
                            isYeriList isyeriliste = new isYeriList();
                            if (satir[0] == '-')
                            {
                                Add(adSoyad, adres, telNo, eposta, dogumtarihi, yabancidil, ehliyet, egitimliste, isyeriliste);
                                break;
                            }


                            while (true)
                            {
                                satir = sw.ReadLine();
                                if (satir.Contains("Isyeri Adi"))
                                {
                                    isyeriAd = stringAyikla(satir);
                                }
                                else if (satir.Contains("Isyeri Adresi"))
                                {
                                    isyeriAdres = stringAyikla(satir);
                                }
                                else if (satir.Contains("Gorevi"))
                                {
                                    pozisyon = stringAyikla(satir);
                                }
                                else if (satir.Contains("Calisma suresi"))
                                {
                                    calisilanSure = stringAyikla(satir);
                                }

                                else if (satir[0] == '#')
                                {

                                    isyeriliste.Add(isyeriAd, isyeriAdres, pozisyon, calisilanSure);
                                }
                                else if (satir[0] == '-')
                                {

                                    Add(adSoyad, adres, telNo, eposta, dogumtarihi, yabancidil, ehliyet, egitimliste, isyeriliste);

                                    break;
                                }

                            }
                            break;
                        }
                    }


                }

                satir = sw.ReadLine();
            }


            sw.Close();
            fs.Close();
        }
        public void okut()
        {
            Read(root);
        }

        public void yazdir()
        {
            Write(root);
        }
        public string stringAyikla(string deger)
        {
            string donecek = "";
            int i;
            for (i = 0; i < deger.Length; i++)
            {
                if (deger[i] == ':')
                {
                    break;
                }
            }
            i++;
            i++;
            for (int j = i; j < deger.Length; j++)
            {
                donecek = donecek + deger[j];
            }
            return donecek;

        }
        public void ingFiltre(KisiBilNode node)
        {
            if (node != null) 
            { 
            ingFiltre(node.left);

                if (node.YabanciDil.Contains("ingilizce"))
                {
                    filterList.Add(node);

                    filterlistYazdir(node);

                }
            ingFiltre(node.right);
            }
            

        }
        public void ingFiltreOkut()
        {   
            ingFiltre(root);
          
        }
        public void filterlistYazdir(KisiBilNode node)
        {
            Console.WriteLine(node.Ad +" "+ node.YabanciDil);
        }
        public int count()
        {
            i = 0;
            dolas(root);
            return i;
        }
        private void dolas(KisiBilNode node)
        {

            if (node != null)
            {
                dolas(node.left);
                j++;
                dolas(node.right);
            }
        }
        public void DeleteFile()
        {
            File.Delete(file);
            Write(root);
        }
    }
}
