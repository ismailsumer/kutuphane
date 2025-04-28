using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Model;

namespace Kutuphane.servis
{
    public class servis_ödünç
    {
        readonly DB _dB;

        public servis_ödünç()
        {
            _dB = new DB();
        }

        // Ödünç ekleme
        public int AddOdunç(Ödunc ödünç)
        {
            int result = 0;
            try
            {
                string query = "INSERT INTO ödünç (ödünç_ıd, kitap_id, üye_id, ödünç_tarihi, veriş_tarihi) VALUES (@ödünç_id, @kitap_id, @üye_id, @ödünç_tarihi, @veriş_tarihi); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@odunç_ıd", ödünç.Odunc_ıd);
                command.Parameters.AddWithValue("@Kitap_ıd", ödünç.Kitap_ıd);
                command.Parameters.AddWithValue("@üye_ıd", ödünç.Uye_ıd);
                command.Parameters.AddWithValue("@ödünç_tarihi", ödünç.Odunc_Tarihi);
                command.Parameters.AddWithValue("@veriş_tarihi", ödünç.Iade_Tarihi);
                

                result = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        // Ödünç güncelleme
        public int UpdateOdunc(Ödunc odunc)
        {
            int result = 0;
            try
            {
                string query = "UPDATE borrows SET  = @ödünç_tarihi, veriş_tarihi = @veriş_tarihi WHERE üye_ıd = @üye_ıd AND kitap_id = @kitap_id AND üye_id = @üye_id";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@odunç_ıd", odunc.Odunc_ıd);
                command.Parameters.AddWithValue("@kitap_ıd", odunc.Kitap_ıd);
                command.Parameters.AddWithValue("@üye_ıd", odunc.Uye_ıd);
                command.Parameters.AddWithValue("@ödünç_tarihi", odunc.Odunc_Tarihi);
                command.Parameters.AddWithValue("@veriş_tarihi", odunc.Iade_Tarihi);

                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        // Ödünç silme
        public int DeleteOdunc(int  ödünç_id)
        {
            int result = 0;
            try
            {
                string query = "DELETE FROM borrows WHERE odunç_ıd = @ödünç_ıd;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("ödünç_ıd", ödünç_id);

                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return result;
        }

        // Ödünç listeleme
        public List<Ödunc> GetOdunc()
        {
            List<Ödunc> oduncList = new List<Ödunc>();
            try
            {
                string query = "SELECT ödünç_id, kitap_id, üye_id, ödünç_tarihi, veriş_tarihi, DATEDIFF(day, ödünç_tarihi., Odunc.Iade_tarihi) AS Difference FROM borrows;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ödunc ödunc= new Ödunc();
                    ödunc.Odunc_ıd = Convert.ToInt32(reader["ödünç_id"]);
                    ödunc.Kitap_ıd = Convert.ToInt32(reader["kitap_id"]);
                    ödunc.Uye_ıd = Convert.ToInt32(reader["üye_id"]);
                    ödunc.Odunc_Tarihi = Convert.ToDateTime(reader["ödünç_tarihi"]);
                    ödunc.Iade_Tarihi = Convert.ToDateTime(reader["Iade_tarihi"]);
                    
                    oduncList.Add(ödunc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return oduncList;
        }
    }
}