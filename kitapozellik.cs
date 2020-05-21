using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KitabeviApp
{
    public class Kitap : Program
    {
        public Kitap()
        {

        }

        public Kitap(string kitaptitle, string kitapyazar, string kitaptur, DateTime kitaptarih)
        {
            this.KitapTitle = kitaptitle;
            this.KitapYazar = kitapyazar;
            this.KitapTur = kitaptur;
            this.KitapTarih = kitaptarih;
        }
        public string KitapTitle { get; set; }
        public string KitapYazar { get; set; }
        public string KitapTur { get; set; }
        public DateTime KitapTarih { get; set; }
        public string BilgileriGetir() => $"KitapAdı:{this.KitapTitle}\nYazarAdı:{this.KitapYazar}\nKitapTürü:{this.KitapTur}\nKitapTarihi:{this.KitapTarih}";


        private static string dosyaYol = AppDomain.CurrentDomain.BaseDirectory + "Kitaplar.txt";
        public static void dosyaOku()//Dosya Okuma Metodu.program cs de kullanıldı[adım başarılı]
        {
            if (File.Exists(dosyaYol))//kitapları listeleme bloğu.txt den veri çekme[adım başarılı]
            {
                Console.WriteLine("Kitaplar Listeleniyor...");
                string bilgileriOku = File.ReadAllText(dosyaYol);
                Console.WriteLine(bilgileriOku);
            }
            else
                Console.WriteLine("Herhangi bir kitap bilgisi eklenmemiş.");
        }

        public static void dosyaYaz(string kitaptitle, string kitapyazar, DateTime kitaptarih, string kitaptur)
        {
                string kitapBilgi = "Kitap adı: " + kitaptitle + "\nKitap Yazarı: " + kitapyazar + "\nKitap Türü: " + kitaptur + "\nKitap Basım Tarihi: "+kitaptarih;
                File.AppendAllText(dosyaYol, kitapBilgi + Environment.NewLine);//txt ye uygun biçimde yazmak.bilgiler bin/debug içinde txt ye yazılıyor[adım başarılı]
        }
    }
}