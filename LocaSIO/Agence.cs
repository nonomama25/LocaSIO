using System;
namespace LocaSIO
{
	public class Agence
	{
		private int Id { get; set; }
		private string _ville;
		private string _UO;


		public Agence(string ville, int id, string uo)
		{
			Id = id;
			_ville = ville;
			_UO = uo;
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

		public string getUO()
		{
            return _UO;
        }
    }
}
