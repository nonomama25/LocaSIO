using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LocaSIO
{
    internal class AdoContrat
    {
        public static ObservableCollection<Contrat> GetContrats()
        {
            ObservableCollection<Contrat> contrats = new ObservableCollection<Contrat>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT * FROM Contrats"; // On recupere tt les contrats
                reader = cmd.ExecuteReader();
                while (reader.Read()) // Tant qu'il y a des contrats dans la bdd on les ajoute a la liste
                {
                    Debug.WriteLine("Loading Contrat DDB");
                    Debug.WriteLine(reader.GetString(1) + " " + reader.GetString(2));
                    contrats.Add(new Contrat(reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4))); // On ajoute le contrat a la liste
                }
                Ado.CloseSqlConnection();
            }// On ferme la connexion avec la bdd

            catch (SqlException ex) //
            {
                Console.WriteLine(ex.Message);
            }
            return clients; // On retourne la liste de clients
        }

        public static void AddContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Contrats (DateDebut, DateFin, Statut, DistinguishedName) VALUES (@DateDebut, @DateFin, @Statut, @DistinguishedName)";
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "UPDATE Contrats SET DateDebut = @DateDebut, DateFin = @DateFin, Statut = @Statut, DistinguishedName = @DistinguishedName WHERE DateDebut = @DateDebut AND DateFin = @DateFin AND Statut = @Statut AND DistinguishedName = @DistinguishedName";
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
                cmd.ExecuteNonQuery();
                Ado.CloseSqlConnection(); // On ferme la connexion avec la bdd
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteContrat(Contrat contrat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection(); // On ouvre la connexion avec la bdd
                Ado.StatusSqlConnection();
                cmd.CommandText = "DELETE FROM Contrats WHERE DateDebut = @DateDebut AND DateFin = @DateFin AND Statut = @Statut AND DistinguishedName = @DistinguishedName";
                cmd.Parameters.AddWithValue("@DateDebut", contrat.getDateDebut());
                cmd.Parameters.AddWithValue("@DateFin", contrat.getDateFin());
                cmd.Parameters.AddWithValue("@Statut", contrat.GetStatut());
                cmd.Parameters.AddWithValue("@DistinguishedName", contrat.GetDistinguishedName());
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

