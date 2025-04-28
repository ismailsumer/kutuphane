using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Model;
 

namespace Kutuphane.servis
{
    public class yazar_servis
    {
        readonly DB _dB;
        
        public yazar_servis()
        {
            _dB = new DB();
        }

        // Yazar ekleme
        public int AddYazar(Yazar yazar)
        {
            int result = 0;
            try
            {
                string query = "INSERT INTO writers yazar_ıd, yazar_adı, yazar_soyadı VALUES (@yazar_ıd, @yazar_adı, @yazar_soyadı); SELECT SCOPE IDENTITY;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@yazar_ıd", yazar.Yazar_ıd);
                command.Parameters.AddWithValue("@yazar_adı", yazar.Yazar_adı);
                command.Parameters.AddWithValue("@yazar_soyadı", yazar.Yazar_soyadı);   

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

        // Yazar güncelleme
        public int UpdateYazar(Yazar yazar)
        {
            int result = 0;
            try
            {
                string query = "UPDATE writers SET  yazar_adı = @yazar_adı, yazar_soyadı = @yazar_soyadı; WHERE yazar_ıd;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@yazar_ıd", yazar.Yazar_ıd);
                command.Parameters.AddWithValue("@yazar_adı", yazar.Yazar_adı);
                command.Parameters.AddWithValue("@yazar-soyadı", yazar.Yazar_soyadı);

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

        // Yazar silme
        public int DeleteYazar(int yazar_ıd)
        {
            int result = 0;
            try
            {
                string query = "DELETE FROM Writers WHERE yazar_ıd = @yazar_ıd;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@yazar_ıd", yazar_ıd);

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

        // Yazarları listeleme
        public List<Yazar> ListYazar()
        {
            List<Yazar> yazar = new List<Yazar>();
            try
            {
                string query = "SELECT * FROM writers;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Yazar yazarlar = new Yazar();
                    /*writer.Yazar_ıd = Convert.ToInt32(reader["yazar_ıd"]);*/
                    yazarlar.Yazar_adı = reader["yazar_adı"]?.ToString() ?? string.Empty;
                    yazarlar.Yazar_soyadı = reader["yazar_soyadı"]?.ToString()?? string.Empty;
                    yazar.Add(yazarlar);                   
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
            return yazar;
        }
    }
}