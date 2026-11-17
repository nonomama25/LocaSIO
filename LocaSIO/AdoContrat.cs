using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LocaSIO
{
    internal class AdoContrat
    {
        public static ObservableCollection<Contrat> GetContrats(int? clientId = null)
        {
            ObservableCollection<Contrat> contrats = new ObservableCollection<Contrat>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT ClientId, DateDebut, DateFin, Statut, DistinguishedName FROM Contrats";
                if (clientId.HasValue)
                {
                    cmd.CommandText += " WHERE ClientId = @ClientId";
                    cmd.Parameters.AddWithValue("@ClientId", clientId.Value);
                }
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des contrats dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Contrat DDB");
                    Debug.WriteLine(reader.GetString(3) + " " + reader.GetString(4));
                    contrats.Add(new Contrat(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4)));
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd

            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
            return contrats; // On retourne la liste de contrats
        }

        public static void AddContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Contrats (ClientId, DateDebut, DateFin, Statut, DistinguishedName) VALUES (@ClientId, @DateDebut, @DateFin, @Statut, @DistinguishedName)";
                cmd.Parameters.AddWithValue("@ClientId", contrat.ClientId);
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void UpdateContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); 
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE Contrats SET DateDebut = @DateDebut, DateFin = @DateFin, Statut = @Statut, DistinguishedName = @DistinguishedName WHERE ClientId = @ClientId AND DateDebut = @DateDebut AND DateFin = @DateFin AND Statut = @Statut AND DistinguishedName = @DistinguishedName";
                cmd.Parameters.AddWithValue("@ClientId", contrat.ClientId);
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection();
            }
            catch (SqlException)
            {
                Ado.CloseSqlConnection();
                throw;
            }
        }

        public static void DeleteContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Contrats WHERE ClientId = @ClientId AND DateDebut = @DateDebut AND DateFin = @DateFin AND Statut = @Statut AND DistinguishedName = @DistinguishedName";
                cmd.Parameters.AddWithValue("@ClientId", contrat.ClientId);
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
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

