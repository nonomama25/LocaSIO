using System;
using System.Web;
namespace LocaSIO
{
	public class Article
	{
		private string _libelle;
		private int _tarifJournalier;
		private int _caution;
		private int _agenceId;
		private string _type;

		public Article(string libelle, int tarifJournalier, int caution, int agenceId, string type)
		{
			_libelle = libelle;
			_tarifJournalier = tarifJournalier;
			_caution = caution;
			_agenceId = agenceId;
			_type = type;
		}

		public string getType()
		{
			return _type;
		}
		public void setType(string type)
		{
			_type = type;
		}
        public string getLibelle()
		{
			return _libelle;
		}

        public void setLibelle(string libelle)
        {
            _libelle = libelle;
        }

        public int getTarifJournalier()
		{
			return _tarifJournalier;
		}

		public void setTarifJournalier(int tarifJournalier)
		{
			_tarifJournalier = tarifJournalier;
		}

		public int getCaution()
		{
			return _caution;
		}

		public void setCaution(int caution)
		{
			_caution = caution;
		}

		public int getAgenceID()
		{
			return _agenceId;
		}

		public void setAgenceID(int agenceId)
		{
			_agenceId = agenceId;
		}

		

	}
}
