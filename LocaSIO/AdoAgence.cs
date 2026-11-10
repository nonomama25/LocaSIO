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
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT Id, Ville, UO FROM Agences";
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des agences dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Agence DDB");
                    agences.Add(new Agence(reader.GetString(1), reader.GetString(2)));
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
            return agences; // On retourne la liste d'agences
        }
        public static void AddAgence(Agence agence)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Agences (Ville, UO) VALUES (@Ville, @UO)";
                cmd.Parameters.AddWithValue("@Ville", agence.getVille());
                cmd.Parameters.AddWithValue("@UO", agence.getUO());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
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
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Agences WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@ville", agence.getVille());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }
    }
}