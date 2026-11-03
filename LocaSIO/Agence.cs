using System;
namespace LocaSIO
{
	public class Agence
	{
		public int Id { get; set; }
		private string _ville;

		public Agence(string ville, int id = 0)
		{
			Id = id;
			_ville = ville;
		}

		public string Ville => _ville;

		public string getVille()
		{
			return _ville;
        }

		public void setVille(string ville)
		{
			this._ville = ville;
        }
    }
}
