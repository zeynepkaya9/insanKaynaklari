using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazlabDeneme
{
    class Program
    {
        static void Main(string[] args)
        {
            string islem, name;
            string ad, adres, tel, eposta, ehliyet, yabancidil, dogumTarih;
            string okulAd, okulTur, okulBolum, okulbasTarih, okulbitTarih, notOrt;
            string isyeriAd, isYeriAdres, isPozisyon, isSure;

            string kullaniciEkle = "1";
            string kullaniciListele = "2";
            string guncelle = "3";
           
            
            KisiBilAgac kisiBilAgac = new KisiBilAgac();
            kisiBilAgac.okut();
            while (true)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçin.");
                Console.WriteLine("Kullanıcı Ekle: " + kullaniciEkle + "\n" + "Kişileri Listele: " + kullaniciListele + "\n" +
                    "Kişi Güncelle: " + guncelle + "\n" + "Kullanıcı Sil: 4" + "\n" + "Filtrele: 5");
                islem = Console.ReadLine();
                if (islem == "1")//Kullanıcı Ekle
                {
                    egitimBilListe ListeEgitim = new egitimBilListe();
                    isYeriList ListeIsYeri = new isYeriList();
                    Console.WriteLine("Ad Soyad: ");
                    ad = Console.ReadLine();
                    Console.WriteLine("Adres: ");
                    adres = Console.ReadLine();
                    Console.WriteLine("Tel No: ");
                    tel = Console.ReadLine();
                    Console.WriteLine("E-Posta: ");
                    eposta = Console.ReadLine();
                    Console.WriteLine("Doğum Tarihi: ");
                    dogumTarih = Console.ReadLine();
                    Console.WriteLine("Yabancı Dil: ");
                    yabancidil = Console.ReadLine();
                    Console.WriteLine("Ehliyet: ");
                    ehliyet = Console.ReadLine();

                    while (true)
                    {

                        Console.WriteLine("Eğitim bilgisi eklemek için: 1" + "\n" +
                        "İşyeri Bilgisi Eklemek için: 2" + "\n" + "Kaydetmek ve Ana Menüye Dönmek için: 3");
                        islem = Console.ReadLine();
                   
                         if (islem == "1")
                         {
                        
                            Console.WriteLine("Okul Adı: ");
                            okulAd = Console.ReadLine();
                            Console.WriteLine("Okul Türü: ");
                            okulTur = Console.ReadLine();
                            Console.WriteLine("Bölümü: ");
                            okulBolum = Console.ReadLine();
                            Console.WriteLine("Başlangıç Tarih: ");
                            okulbasTarih = Console.ReadLine();
                            Console.WriteLine("Bitiş Tarihi: ");
                            okulbitTarih = Console.ReadLine();
                            Console.WriteLine("Not Ortalaması: ");
                            notOrt = Console.ReadLine();
                            ListeEgitim.Add(okulAd, okulTur, okulBolum, okulbasTarih, okulbitTarih, notOrt);

                          
                        
                         }
                           else if (islem == "2")
                           {
                             Console.WriteLine("İş Yeri Adı: ");
                             isyeriAd = Console.ReadLine();
                             Console.WriteLine("İş Yeri Adres: ");
                             isYeriAdres = Console.ReadLine();
                             Console.WriteLine("Çalışıtığı Pozisyon: ");
                             isPozisyon = Console.ReadLine();
                             Console.WriteLine("Çalıştığı Süre: ");
                             isSure = Console.ReadLine();
                            ListeIsYeri.Add(isyeriAd, isYeriAdres, isPozisyon, isSure);

                           }
                         else if (islem == "3")
                        {
                        
                            if (ListeIsYeri == null && ListeEgitim == null)
                            {
                                kisiBilAgac.Add(ad, adres, tel, eposta, dogumTarih, yabancidil,ehliyet, null, null);
              
            
                            }
                            else if (ListeEgitim==null&&ListeIsYeri!=null)
                            {
                                kisiBilAgac.Add(ad, adres, tel, eposta, dogumTarih, yabancidil, ehliyet, null,ListeIsYeri);
                            }
                            else if (ListeEgitim != null && ListeIsYeri == null)
                            {
                                kisiBilAgac.Add(ad, adres, tel, eposta, dogumTarih, yabancidil, ehliyet, ListeEgitim, null);
                            }
                            else if (ListeEgitim != null && ListeIsYeri != null)
                            {
                                kisiBilAgac.Add(ad, adres, tel, eposta, dogumTarih, yabancidil, ehliyet, ListeEgitim, ListeIsYeri);
                            }
                            kisiBilAgac.DeleteFile();
                            kisiBilAgac.listele();
                            kisiBilAgac.yazdir();
                            break;
                        }

                    }

                }
                else if (islem == "2")//Kişileri Listele
                {
                  
                    kisiBilAgac.listele();
                }
                else if (islem == "3")//Güncelle
                {
                    kisiBilAgac.okut();
                    Console.WriteLine("Güncellemek istediğiniz kişinin adını giriniz.");
                    name = Console.ReadLine();
                    kisiBilAgac.ReturnTree(name);
          
                }
                else if (islem == "4")//Kişi Sil
                {
                    Console.WriteLine("Silmek istediğiniz kişinin ismini giriniz.");
                    name = Console.ReadLine();
                    kisiBilAgac.Delete2(name);
                    kisiBilAgac.DeleteFile();
                    Console.WriteLine(name + " isimli kişi dosyadan silinmiştir.");
                }
                else if (islem == "5")//Filtreleme işlemleri
                {
                    Console.WriteLine("İngilizce Bilen Kişler: 1" + "\n" +"En Az Lisans Mezunu Olan Kişiler: 2"
                        + "\n" +"Birden Fazla Dil Bilen Kişiler: 3" + "\n" +"Deneyimsiz Kişiler: 4" + "\n" +
                        "Girilecek Minimum Deneyim Süresine Göre Kişiler: 5" + "\n" +
                        "Girilecek Olan Yaş Değeri Altındaki Kişiler: 6" + "\n" +"Belirli Tip Ehliyeti Olan Kişiler: 7");
                    islem = Console.ReadLine();
                    if (islem == "1")
                    {
                        kisiBilAgac.filterList.Clear();
                        kisiBilAgac.ingFiltreOkut();
                    }
                    else if (islem == "2")
                    {

                    }
                    else if (islem == "3")
                    {

                    }
                    else if (islem == "4")
                    {

                    }
                    else if (islem == "5")
                    {

                    }
                    else if (islem == "6")
                    {

                    }
                    else if (islem == "7")
                    {

                    }




                }


               
            }

        }
    }
}
