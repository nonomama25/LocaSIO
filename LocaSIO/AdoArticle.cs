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
                cmd.CommandText = "SELECT Id, Libelle, TarifJournalier, Disponible, Caution, AgenceID FROM Article";
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des articles dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Article DDB");
                    var article = new Article(reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetInt32(4), reader.GetInt32(5));
                    article.setID(reader.GetInt32(0));
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
                cmd.CommandText = "INSERT INTO Article (Libelle, TarifJournalier, Disponible, Caution, AgenceID) VALUES (@Libelle, @TarifJournalier, @Disponible, @Caution, @AgenceID)";
                cmd.Parameters.AddWithValue("@Libelle", article.getLibelle());
                cmd.Parameters.AddWithValue("@TarifJournalier", article.getTarifJournalier());
                cmd.Parameters.AddWithValue("@Disponible", article.getDisponible());
                cmd.Parameters.AddWithValue("@Caution", article.getCaution());
                cmd.Parameters.AddWithValue("@AgenceID", article.getAgenceID());
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
                cmd.CommandText = "DELETE FROM Article WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", article.getID());
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
                cmd.CommandText = "UPDATE Article SET Libelle = @Libelle, TarifJournalier = @TarifJournalier, Disponible = @Disponible, Caution = @Caution, AgenceID = @AgenceID WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Libelle", article.getLibelle());
                cmd.Parameters.AddWithValue("@TarifJournalier", article.getTarifJournalier());
                cmd.Parameters.AddWithValue("@Disponible", article.getDisponible());
                cmd.Parameters.AddWithValue("@Caution", article.getCaution());
                cmd.Parameters.AddWithValue("@AgenceID", article.getAgenceID());
                cmd.Parameters.AddWithValue("@Id", article.getID());
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
