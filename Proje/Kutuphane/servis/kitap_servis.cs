using System.Data;
using Microsoft.Data.SqlClient;
using Kutuphane.Utils;
using Kutuphane.Model;
using System.IO.Pipelines;


namespace Kutuphane.servis
{
    public class servis_kitap
    {
        readonly DB _dB;

        public  servis_kitap()
        {
            _dB = new DB();
        }

        // Kitap ekleme
        public int AddKitap(Kitap kitap)
        {
            int result = 0;
            try
            {
                string query = "INSERT INTO books kitap_ıd, yazar_ıd,Başlık, Yayın_yılı, ISBN VALUES (@kitap_ıd, @yazar-ıd, @Başlık, @Yayın_yılı, @ISBN); ";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                
                command.Parameters.AddWithValue("@kitap_ıd", kitap.Kitap_ıd);
                command.Parameters.AddWithValue("@yazar_ıd", kitap.Yazar_ıd);
                command.Parameters.AddWithValue("@başlık", kitap.Başlık);
                command.Parameters.AddWithValue("@yayın_yılı", kitap.Yayın_Yılı);
                command.Parameters.AddWithValue("@ISBN", kitap.ISBN);
                
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

        // Kitap güncelleme
        public int UpdateKitap(Kitap kitap)
        {
            int result = 0;
            try
            {
                {
                    string query = "UPDATE books SET SET title = @başlık, yayın_yılı = @yayın_yılı, ISBN = @ISBN; WHERE kitap_ıd = @kitap_ıd AND yazar_ıd = @yazar_ıd;";
                    SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                    {
                        command.Parameters.AddWithValue("@kitap_ıd", kitap.Kitap_ıd);
                        command.Parameters.AddWithValue("@yazar_id", kitap.Yazar_ıd);
                        command.Parameters.AddWithValue("@başlık", kitap.Başlık);
                        command.Parameters.AddWithValue("@yayın_yılı", kitap.Yayın_Yılı);
                        command.Parameters.AddWithValue("@ISBN", kitap.ISBN);

                        result = command.ExecuteNonQuery();
                    }
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
            return result;
        }

        // Kitap silme
        public int DeleteKitap(int Kitap_ıd)
        {
            int result = 0;
            try
            {
                string query = "DELETE FROM books WHERE books_id = @Kitap_ıd;";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                command.Parameters.AddWithValue("@Kitap_id", Kitap_ıd);
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

        // Kitap listeleme
        public List<Kitap> listBooks()
        {
            List<Kitap> books = new List<Kitap>();
            try
            {
                string query = "SELECT * FROM Books";
                SqlCommand command = new SqlCommand(query, _dB.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {   
                    Kitap kitap = new Kitap();
                    kitap.Kitap_ıd = Convert.ToInt32(reader["kitap_ıd"]);
                    kitap.Yazar_ıd = Convert.ToInt32(reader["yazar_ıd"]);
                    kitap.Başlık = reader["başlık"]?.ToString() ?? string.Empty;
                    kitap.Yayın_Yılı = Convert.ToInt32(reader["yayın_yılı"]);
                    kitap.ISBN = reader["ISBN"]?.ToString() ?? string.Empty;
                    books.Add(kitap);
             }   }         
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _dB.CloseConnection();
            }
            return books;
        }       
    }
}