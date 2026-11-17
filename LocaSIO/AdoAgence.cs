using System;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
    internal class AdoAgence : Ado
    {
        public static ObservableCollection<Agence> GetAgences()
        {
            ObservableCollection<Agence> agences = new ObservableCollection<Agence>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                cmd.CommandText = "SELECT Id, Ville, UO FROM Agences";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // On utilise le constructeur avec l'ID
                        agences.Add(new Agence(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
            return agences;
        }

        public static void AddAgence(Agence agence)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();

                cmd.CommandText = "INSERT INTO Agences (Ville, UO) VALUES (@Ville, @UO)";

                cmd.Parameters.AddWithValue("@Ville", agence.Ville); // Utilise la propriété .Ville sans parenthèses
                cmd.Parameters.AddWithValue("@UO", agence.UO);       // Utilise la propriété .UO sans parenthèses

                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void DeleteAgence(Agence agence)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                // Maintenant que l'Id existe sur l'objet Agence, on peut supprimer proprement par l'Id !
                cmd.CommandText = "DELETE FROM Agences WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", agence.Id);
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