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
                cmd.CommandText = "SELECT * FROM Agences"; // On recupere tt les agences
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des agences dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Agence DDB");
                    Debug.WriteLine(reader.GetString(1) + " " + reader.GetInt32(2));
                    agences.Add(new Agence(reader.GetString(1), reader.GetInt32(2), reader.GetString(3))); // On ajoute l'agence a la liste
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd
            catch (SqlException ex) //
            {
                Console.WriteLine(ex.Message);
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeleteAgence(Agence agence)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Agences WHERE Ville = @Ville AND UO = @UO";
                cmd.Parameters.AddWithValue("@Ville", agence.getVille());
                cmd.Parameters.AddWithValue("@UO", agence.getUO());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}