using System;

namespace LocaSIO
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; } // Type string pour garder les zéros initiaux

        // Constructeur complet (utile si l'ID est déjà connu)
        public Client(int id, string nom, string prenom, string email, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
        }

        // Constructeur sans ID (utile si l'ID est généré automatiquement par la base de données)
        public Client(string nom, string prenom, string email, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
        }
    }
}