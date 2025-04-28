using System;
using System.Data.SqlClient;
using Kutuphane.Model;
using Kutuphane.servis;
using Kutuphane.Utils;


namespace Kutuphane
{
    class Program
    {
        static void Main(string[] args)
        {
        
        }
            public void ListBooks()
        {
            servis_kitap serviskitap = new servis_kitap();
            List<Kitap> listbook = new List<Kitap>();
            foreach (var kitap in listbook)
            {
                Console.WriteLine($"ID: {kitap.Kitap_ıd}, Başlık: {kitap.Başlık}, Yazar ID: {kitap.Yazar_ıd}, Yayın Yılı: {kitap.Yayın_Yılı}, ISBN: {kitap.ISBN}");
            }
        }

        public void DeleteKitap()
        {
            servis_kitap servisKitap = new servis_kitap();
            int kitapId = 1; // Silinecek kitabın ID'si
            int result = servisKitap.DeleteKitap(kitapId);
            Console.WriteLine("Kitap silindi: " + result);
        }

        public void UpdateKitap()
        { 
            servis_kitap servisKitap = new servis_kitap();
            Kitap kitap = new Kitap();
            kitap.Kitap_ıd = 1;
            kitap.Yazar_ıd = 1;
            kitap.Başlık = "Güncellenmiş Kitap Başlığı";
            kitap.Yayın_Yılı = 2023;
            kitap.ISBN = "0987654321";

            int result = servisKitap.UpdateKitap(kitap);
            Console.WriteLine("Kitap güncellendi: " + result);
        }

        public void AddKitap()
        {
            servis_kitap servisKitap = new servis_kitap();
            Kitap kitap = new Kitap();
            kitap.Kitap_ıd = 1;
            kitap.Yazar_ıd = 1;
            kitap.Başlık = "Kitap Başlığı";
            kitap.Yayın_Yılı = 2023;
            kitap.ISBN = "1234567890";

            int result = servisKitap.AddKitap(kitap);
            Console.WriteLine("Kitap eklendi: " + result);
        }

        public void GetOdunc()
        {    
            servis_ödünç servis_Odunc = new servis_ödünç();
            var odunclar = servis_Odunc.GetOdunc();
            foreach (var odunc in odunclar)
            {
                Console.WriteLine($"ID: {odunc.Odunc_ıd}, Kitap ID: {odunc.Kitap_ıd}, Üye ID: {odunc.Uye_ıd}, Ödünç Tarihi: {odunc.Odunc_Tarihi}, İade Tarihi: {odunc.Iade_Tarihi}");
            }
        }

        public void DeleteOdunc()
        {
            servis_ödünç servis_ödünç = new servis_ödünç();
            int oduncId = 1; // Silinecek ödünç ID'si
            int result = servis_ödünç.DeleteOdunc(oduncId);
            Console.WriteLine("Ödünç silindi: " + result);
        }

        public void AddOdunc()
        {
            servis_ödünç servis_Odunc = new servis_ödünç();
            Ödunc odunc = new Ödunc();
            odunc.Odunc_ıd = 1;
            odunc.Kitap_ıd = 1;
            odunc.Uye_ıd = 1;
            odunc.Odunc_Tarihi = DateTime.Now;
            odunc.Iade_Tarihi = DateTime.Now.AddDays(14);

            int result = servis_Odunc.AddOdunç(odunc);
            Console.WriteLine("Ödünç eklendi: " + result);
        }

        public void UpdateOdunc()
        {
            servis_ödünç servis_Odunc = new servis_ödünç();
            Ödunc odunc = new Ödunc();
            odunc.Odunc_ıd = 1;
            odunc.Kitap_ıd = 1;
            odunc.Uye_ıd = 1;
            odunc.Odunc_Tarihi = DateTime.Now;
            odunc.Iade_Tarihi = DateTime.Now.AddDays(14);

            int result = servis_Odunc.UpdateOdunc(odunc);
            Console.WriteLine("Ödünç güncellendi: " + result);
        }

        public void UpdateUye()
        {
            üye_servis üye_Servis = new üye_servis();
            Uye uye = new Uye();
            uye.Uye_ıd = 1;
            uye.Adı = "Güncellenmiş Üye Adı";
            uye.Soyadı = "Güncellenmiş Üye Soyadı";
            uye.E_posta = "güncellenmiş üye eposta";

            int result = üye_Servis.UpdateUye(uye);
            Console.WriteLine("Üye güncellendi: " + result);
        }

        public void DeleteUye()
        {
            üye_servis üye_Servis = new üye_servis();
            int uyeId = 1; // Silinecek üye ID'si
            int result = üye_Servis.DeleteUye(uyeId);
            Console.WriteLine("Üye silindi: " + result);
        }

        public void ListUye()
        {
            üye_servis üye_Servis = new üye_servis();
            var uyeler = üye_Servis.listuye();
            foreach (var uye in uyeler)
            {
                Console.WriteLine($"ID: {uye.Uye_ıd}, Adı: {uye.Adı}, Soyadı: {uye.Soyadı}, E-posta: {uye.E_posta}");
            }
        }

        public void Addüye()
        {
            üye_servis üye_Servis = new üye_servis();
            Uye uye = new Uye();
            uye.Uye_ıd = 1;
            uye.Adı = "Üye Adı";
            uye.Soyadı = "Üye Soyadı";
            uye.E_posta = "üye eposta";
        }

        public void ListYazar()
        {
            yazar_servis yazar_Servis = new yazar_servis();
            var yazarlar = yazar_Servis.ListYazar();
            foreach (var yazar in yazarlar)
            {
                Console.WriteLine($"ID: {yazar.Yazar_ıd}, Adı: {yazar.Yazar_adı}, Soyadı: {yazar.Yazar_soyadı}");
            }
        }

        public void DeleteYazar()
        {
            yazar_servis yazar_Servis = new yazar_servis();
            int yazarId = 1; // Silinecek yazar ID'si
            int result = yazar_Servis.DeleteYazar(yazarId);
            Console.WriteLine("Yazar silindi: " + result);
        }

        public void AddYazar()
        {
            yazar_servis yazar_Servis = new yazar_servis();
            Yazar yazar = new Yazar();
            yazar.Yazar_ıd = 1;
            yazar.Yazar_adı = "Yazar Adı";
            yazar.Yazar_soyadı = "Yazar Soyadı";

            int result = yazar_Servis.AddYazar(yazar);
            Console.WriteLine("Yazar eklendi: " + result);
        }
        
    } 
}                 
  
