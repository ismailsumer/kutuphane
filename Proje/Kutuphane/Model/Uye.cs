namespace Kutuphane.Model
{ 
    public struct Uye
    {
        public int Uye_ıd { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string E_posta { get; set; }
        public string Telefon { get; set; }

        public Uye(int uye_ıd, string ad, string soyad, string e_posta, string telefon)
        {
            Uye_ıd = uye_ıd;
            Adı = ad;
            Soyadı = soyad;
            E_posta = e_posta;
            Telefon = telefon;
        }
}
 
}
