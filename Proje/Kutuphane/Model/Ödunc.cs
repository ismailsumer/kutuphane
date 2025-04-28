namespace Kutuphane.Model
{
        
    public struct Ödunc
    {
    public int Odunc_ıd { get; set; }
    public int Uye_ıd { get; set; }
    public int Kitap_ıd { get; set; }
    public DateTime Odunc_Tarihi { get; set; }
    public DateTime Iade_Tarihi { get; set; }

    public Ödunc(int odunc_ıd, int uye_ıd, int kitap_ıd, DateTime odunc_tarihi, DateTime iade_tarihi)
    {
        Odunc_ıd = odunc_ıd;
        Uye_ıd = uye_ıd;
        Kitap_ıd = kitap_ıd;
        Odunc_Tarihi = odunc_tarihi;
        Iade_Tarihi = iade_tarihi;
    }

    }
 
  
     
  
}
    
