using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LocaSIO
{
    internal class AdoClient : Ado
    {
        public static ObservableCollection<Client> GetClients()
        {
            ObservableCollection<Client> AllClient = new ObservableCollection<Client>();
            AllClient.Clear();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT Id, Nom, Prenom, Email, NumeroTel FROM Clients";
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des clients dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Client DDB");
                    var client = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    AllClient.Add(client);
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd

            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
            return AllClient; // On retourne la liste de clients
        }

        public static void AddClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Clients (Nom, Prenom, Email, NumeroTel) VALUES (@Nom, @Prenom, @Email, @NumeroTel)";
                cmd.Parameters.AddWithValue("@Nom", client.Nom);
                cmd.Parameters.AddWithValue("@Prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@numeroTel", client.Telephone);
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void UpdateClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE Clients SET Nom = @Nom, Prenom = @Prenom, Email = @Email, NumeroTel = @NumeroTel WHERE Nom = @Nom AND Prenom = @Prenom AND Email = @Email AND NumeroTel = @NumeroTel";
                cmd.Parameters.AddWithValue("@Nom", client.Nom);
                cmd.Parameters.AddWithValue("@Prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@NumeroTel", client.Telephone);
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void DeleteClient(Client client)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Clients WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", client.Id);
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

