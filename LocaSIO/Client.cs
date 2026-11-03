using System;

namespace LocaSIO
{

	internal class Client
	{
		private string _nom;
		private string _prenom;
		private string _email;
		private int _telephone;

		public Client(string nom, string prenom, string email, int telephone)
		{
			_nom = nom;
			_prenom = prenom;
			_email = email;
			_telephone = telephone;
		}

		public string getNom()
		{
			return _nom;
		}

		public void setNom(string nom)
		{
			this._nom = nom;
		}

		public string getPrenom()
		{
			return _prenom;
		}

		public void setPrenom(string prenom)
		{
			this._prenom = prenom;
		}

		public string getEmail()
		{
			return _email;
		}

		public void setEmail(string email)
		{
			this._email = email;
		}

		public int getTelephone()
		{
			return _telephone;
		}

		public void setTelephone(int telephone)
		{
			this._telephone = telephone;
		}
	}
}