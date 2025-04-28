using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Model;
using Kutuphane.Utils;
using Microsoft.VisualBasic;

namespace Kutuphane.servis
{
    public class üye_servis
    {
        readonly DB _dB;

        public üye_servis()
        {
            _dB = new DB();
        }

        // Üye ekleme
        public int Addüye(Uye uye)
        {
            int result = 0;
            try
            {
                string query = "INSERT INTO uye uye_ıd, uye_adı, uye_soyadı, uye_eposta, uye_telefon VALUES ( @uye_ıd, @uye_adı, @uye_soyadı, @uye_eposta, @uye_telefon); SELECT SCOPE IDENTITY;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uye_ıd", uye.Uye_ıd);
                command.Parameters.AddWithValue("@uye_adı", uye.Adı);
                command.Parameters.AddWithValue("@uye_soyadı", uye.Soyadı);
                command.Parameters.AddWithValue("@uye_eposta", uye.E_posta);
                command.Parameters.AddWithValue("@uye_telefon", uye.Telefon);

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

        //Üye güncelleme

        public int UpdateUye(Uye uye)
        {
            int result = 0;
            try
            {
                string query = "UPDATE members SET member_name = @member_name, member_surname = @member_surname, member_email = @member_email, member_phone = @member_phone; WHERE member_id = @member_id;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
               command.Parameters.AddWithValue("@uye_ıd", uye.Uye_ıd);
                command.Parameters.AddWithValue("@uye_adı", uye.Adı);
                command.Parameters.AddWithValue("@uye_soyadı", uye.Soyadı);
                command.Parameters.AddWithValue("@uye_eposta", uye.E_posta);
                command.Parameters.AddWithValue("@uye_telefon", uye.Telefon);

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

        //Üye silme
        public int DeleteUye(int uye_ıd)
        {
            int result = 0;
            try
            {
                string query = "DELETE FROM members WHERE Uye_ıd =@uye_ıd;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@uye_ıd", uye_ıd);

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

        //Üye listeleme
        public List<Uye> listuye()
        {
            List<Uye> Uye = new List<Uye>();
            try
            {
                string query = "SELECT * FROM members;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlConnection connection = _dB.GetConnection();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Uye uye = new Uye();
                    uye.Uye_ıd = Convert.ToInt32(reader["uye_ıd"]);
                    uye.Adı = reader["uye_adı"]?.ToString() ?? string.Empty;
                    uye.Soyadı = reader["uye_soyadı"]?.ToString() ?? string.Empty;
                    uye.E_posta = reader["uye_eposta"]?.ToString() ?? string.Empty;
                    uye.Telefon = reader["uye_telefon"]?.ToString() ?? string.Empty;
                    Uye.Add(uye);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Uye;
        }
    }
}