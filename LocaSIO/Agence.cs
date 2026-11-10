using System;
namespace LocaSIO
{
	public class Agence
	{
		private string Ville;
		private string UO;


		public Agence(string ville, string uo)
		{
			this.Ville = ville;
			this.UO = uo;
		}

		public string getVille()
		{
			return Ville;
        }

		public void setVille(string ville)
		{
			this.Ville = ville;
        }

		public string getUO()
		{
            return UO;
        }
    }
}
