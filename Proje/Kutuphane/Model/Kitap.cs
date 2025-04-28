namespace Kutuphane.Model
{
    public struct Kitap 
  {

        public int Kitap_ıd { get; set; }
    public string Başlık { get; set; }
    public int Yazar_ıd { get; set; }
    public int Yayın_Yılı { get; set; }
    public string ISBN { get; set; } 
     public Kitap(int kitap_ıd, int yazar_ıd, string başlık, int yayın_Yılı, string ISBN) 
     {
        Kitap_ıd = kitap_ıd;
        Yazar_ıd = yazar_ıd;
        Başlık = başlık;
        Yayın_Yılı = yayın_Yılı;
        this.ISBN = ISBN;
     }
    }
}