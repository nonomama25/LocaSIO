using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace LocaSIO
{
    internal static class AdoArticle
    {
        public static ObservableCollection<Article> GetArticles()
        {
            var articles = new ObservableCollection<Article>();
            using var connection = Ado.OpenSqlConnection();
            using var command = new SqlCommand(
                "SELECT Id, Libelle, TarifJournalier, Disponible, Caution, AgenceID FROM Article ORDER BY Libelle",
                connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                articles.Add(new Article(
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetBoolean(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5))
                {
                    Id = reader.GetInt32(0)
                });
            }

            return articles;
        }

        public static void CreateArticle(Article article)
        {
            using var connection = Ado.OpenSqlConnection();
            using var command = new SqlCommand(
                "INSERT INTO Article (Libelle, TarifJournalier, Disponible, Caution, AgenceID) VALUES (@Libelle, @TarifJournalier, @Disponible, @Caution, @AgenceID)",
                connection);
            AddArticleParameters(command, article);
            command.ExecuteNonQuery();
        }

        public static void AddArticle(Article article)
        {
            CreateArticle(article);
        }

        public static void DeleteArticle(Article article)
        {
            using var connection = Ado.OpenSqlConnection();
            using var command = new SqlCommand("DELETE FROM Article WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", article.Id);
            command.ExecuteNonQuery();
        }

        public static void UpdateArticle(Article article)
        {
            using var connection = Ado.OpenSqlConnection();
            using var command = new SqlCommand(
                "UPDATE Article SET Libelle = @Libelle, TarifJournalier = @TarifJournalier, Disponible = @Disponible, Caution = @Caution, AgenceID = @AgenceID WHERE Id = @Id",
                connection);
            AddArticleParameters(command, article);
            command.Parameters.AddWithValue("@Id", article.Id);
            command.ExecuteNonQuery();
        }

        private static void AddArticleParameters(SqlCommand command, Article article)
        {
            command.Parameters.AddWithValue("@Libelle", article.getLibelle());
            command.Parameters.AddWithValue("@TarifJournalier", article.getTarifJournalier());
            command.Parameters.AddWithValue("@Disponible", article.getDisponible());
            command.Parameters.AddWithValue("@Caution", article.getCaution());
            command.Parameters.AddWithValue("@AgenceID", article.getAgenceId());
        }
    }
}
