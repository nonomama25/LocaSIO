using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LocaSIO
{
    internal class AdoArticle : Ado
    {
        public static ObservableCollection<Article> GetArticles()
        {
            ObservableCollection<Article> articles = new ObservableCollection<Article>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT * FROM ArticlesLocations";
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des articles dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Article DDB");
                    var article = new Article(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5));
                    articles.Add(article);
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
            return articles; // On retourne la liste d'articles
        }
        public static void AddArticle(Article article)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO ArticlesLocations (Libelle, TarifJournalier, Caution, AgenceID, Type) VALUES (@Libelle, @TarifJournalier, @Caution, @AgenceID, @Type)";
                cmd.Parameters.AddWithValue("@Libelle", article.getLibelle());
                cmd.Parameters.AddWithValue("@TarifJournalier", article.getTarifJournalier());
                cmd.Parameters.AddWithValue("@Caution", article.getCaution());
                cmd.Parameters.AddWithValue("@AgenceID", article.getAgenceID());
                cmd.Parameters.AddWithValue("@Type", article.GetType());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void DeleteArticle(Article article)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM ArticlesLocations WHERE Id = @Id";
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void UpdateArticle(Article article)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE ArticlesLocation SET Libelle = @Libelle, TarifJournalier = @TarifJournalier, Caution = @Caution, AgenceID = @AgenceID Type = @Type WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Libelle", article.getLibelle());
                cmd.Parameters.AddWithValue("@TarifJournalier", article.getTarifJournalier());
                cmd.Parameters.AddWithValue("@Caution", article.getCaution());
                cmd.Parameters.AddWithValue("@AgenceID", article.getAgenceID());
                cmd.Parameters.AddWithValue("@Type", article.GetType());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }
    }
}
