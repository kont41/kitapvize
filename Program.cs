using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KitabeviApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Kitap[] KitapDizi = new Kitap[0];//Dizinın hata vermemesi için başka boş  oluşturmak[adım başarılı]
            string cikis = "";
            while (cikis != "E")//Çıkış için hotkey[adım başarılı]
            {
                Console.Write("Lütfen Kitap Eklemek İçin 1'e, Kitap Listesini Görmek İçin 2'ye Basınız: ");
                int secim = int.Parse(Console.ReadLine());
                if (secim == 1)//Kitap ekle
                {
                    Console.WriteLine("Kaç Kitap Eklemek İstiyorsunuz?");
                    byte kitapSecim = byte.Parse(Console.ReadLine());
                    KitapDizi = new Kitap[kitapSecim];//kullanıcıdan alınan büyüklükte dizi oluşturmak[adım başarılı]
                    for (int i = 0; i < kitapSecim; i++)
                    {
                      
                            Kitap kitap = new Kitap();//Her eklenen kitaba yer ayırma[adım başarılı]
                            Console.WriteLine($"{i + 1}. Kitabın Adını Giriniz: ");//i+in amacı 1. kitap 2. kitap diye listeleyebilmek.
                            kitap.KitapTitle = Console.ReadLine();
                            Console.WriteLine($"{i + 1}. Kitabın yazarını giriniz: ");
                            kitap.KitapYazar = Console.ReadLine();

                            Console.WriteLine($"{i + 1}. Kitabın basım tarihini giriniz: ");
                            kitap.KitapTarih = DateTime.Parse(Console.ReadLine());
                            while (kitap.KitapTarih.Year > 2020)
                            {
                                Console.WriteLine($"{i + 1}. Şuanki Yıldan Daha Büyük Bir Değer Girdiniz");
                                Console.WriteLine($"{i + 1}. Kitabın basım tarihini giriniz: ");
                                kitap.KitapTarih = DateTime.Parse(Console.ReadLine());
                            }
                            Console.Write($"{i + 1}. Kitabın türünü giriniz: ");
                            kitap.KitapTur = Console.ReadLine();
                            Console.WriteLine("--------------------------------------");
                            KitapDizi[i] = kitap;//Verilen kitap bilgilerini diziye aktarmak[adım başarılı]
                        Kitap.dosyaYaz(kitap.KitapTitle,kitap.KitapYazar,kitap.KitapTarih,kitap.KitapTur);
                        
                       
                    }
                }
                else if (secim == 2)//bu metod ile kitapların listesini getiriyor [adım başarılı]
                {
                    Kitap.dosyaOku();
                   
                }
                else
                {
                    Console.WriteLine("\nHatalı Girildi. Lütfen Tekrar Deneyiniz.\n");
                }
                Console.WriteLine("");
                Console.WriteLine("Programdan Çıkmak İstiyor musunuz? (E/H):");
                cikis = Console.ReadLine().ToUpper();
                
            }
        }
    }
}