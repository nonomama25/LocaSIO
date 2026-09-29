using System;
namespace LocaSIO
{
	public class Agence
	{
		private string _ville;

		public Agence(string ville)
		{
			_ville = ville;
		}

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
