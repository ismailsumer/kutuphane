namespace Kutuphane.Model
{
    public struct Yazar
    {
        public int Yazar_ıd { get; set; }
        public string Yazar_adı { get; set; }
        public string Yazar_soyadı { get; set; }

        public Yazar(int yazar_ıd, string yazar_adı, string yazar_soyadı)
        {
            Yazar_ıd = yazar_ıd;
            Yazar_adı = yazar_adı;
            Yazar_soyadı =yazar_soyadı;
            
        }
    }
}    

