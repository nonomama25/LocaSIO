using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
	internal class AdoArticle
	{
        public static AdoArticle()
        {
            ObservableCollection<BorneArcade> AllArticle = new ObservableCollection<Article>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT * Article";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Debug.WriteLine("Loading Article DDB");
                    Debug.WriteLine(reader.GetString(1) + " " + reader.GetString(2));
                    if (AllArticle.GetType() == typeof(ArticleChantier))
                    {
                        AllArticle.Add(new ArticleChantier(reader.GetString(1), reader.GetInt32(2)));
                    }
                    else if (AllArticle.GetType() == typeof(ArticleSport))
                    {
                        AllArticle.Add(new ArticleSport(reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                    else if (AllArticle.GetType() == typeof(ArticleVehicule))
                    {
                        AllArticle.Add(new ArticleVehicule(reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                    Ado.CloseSqlConnection();
                    else if (AllArticle.GetType() == typeof(ArticleEvenement))
                    {
                        AllArticle.Add(new ArticleEvenement(reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetInt32(4), reader.GetInt32(5)));
                    }
                }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return AllArticle;
        }
        public static void CreateArticle()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Article (Libelle, TarifJournalier, Disponible, Caution, AgenceID) VALUES (@Libelle, @TarifJournalier, @Disponible, @Caution, @AgenceID)";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteArticle()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Article WHERE Id = @Id";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateArticle()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE Article SET Libelle = @Libelle, TarifJournalier = @TarifJournalier, Disponible = @Disponible, Caution = @Caution, AgenceID = @AgenceID WHERE Id = @Id";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
}
	}
}
