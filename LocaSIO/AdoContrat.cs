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
    internal class AdoContrat
    {
        public static AdoContrat()
        {
            ObservableCollection<BorneArcade> AllContrat = new ObservableCollection<Article>();
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "SELECT * Contrat";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Debug.WriteLine("Loading Client DDB");
                    Debug.WriteLine(reader.GetString(1) + " " + reader.GetString(2));
                    contrat.Add(new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4))); // On ajoute le client a la liste
                }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return AllContrat;
        }
        public static void CreateArticle()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Ado.OpenSqlConnection();
                Ado.StatusSqlConnection();
                cmd.CommandText = "INSERT INTO Contrat (DateDebut, DateFin, Status, DistinguishedName) VALUES (@DateDebut, @DateFin, @Status, @DistinguishedName)";
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
                cmd.CommandText = "DELETE FROM Contrat WHERE Id = @Id";
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
                cmd.CommandText = "UPDATE Contrat SET DateDebut = @DateDebut, DateFin = @DateFin, Status = @Status, DistinguishedName = @DistinguishedName WHERE Id = @Id";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
