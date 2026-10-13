using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LocaSIO
{
    internal class AdoClient
    {
        public static ObservableCollection<Client> GetClients()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT * FROM Clients"; // On recupere tt les clients
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des clients dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Client DDB");
                    Debug.WriteLine(reader.GetString(1) + " " + reader.GetString(2));
                    clients.Add(new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4))); // On ajoute le client a la liste
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd

            catch (SqlException ex) //
            {
                Console.WriteLine(ex.Message);
            }
            return clients; // On retourne la liste de clients
        }

        public static void AddClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Clients (Nom, Prenom, Email, Telephone) VALUES (@Nom, @Prenom, @Email, @Telephone)";
                cmd.Parameters.AddWithValue("@Nom", client.getNom());
                cmd.Parameters.AddWithValue("@Prenom", client.getPrenom());
                cmd.Parameters.AddWithValue("@Email", client.getEmail());
                cmd.Parameters.AddWithValue("@Telephone", client.getTelephone());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE Clients SET Nom = @Nom, Prenom = @Prenom, Email = @Email, Telephone = @Telephone WHERE Nom = @Nom AND Prenom = @Prenom AND Email = @Email AND Telephone = @Telephone";
                cmd.Parameters.AddWithValue("@Nom", client.getNom());
                cmd.Parameters.AddWithValue("@Prenom", client.getPrenom());
                cmd.Parameters.AddWithValue("@Email", client.getEmail());
                cmd.Parameters.AddWithValue("@Telephone", client.getTelephone());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Clients WHERE Nom = @Nom AND Prenom = @Prenom AND Email = @Email AND Telephone = @Telephone";
                cmd.Parameters.AddWithValue("@Nom", client.getNom());
                cmd.Parameters.AddWithValue("@Prenom", client.getPrenom());
                cmd.Parameters.AddWithValue("@Email", client.getEmail());
                cmd.Parameters.AddWithValue("@Telephone", client.getTelephone());
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

