using System;
namespace LocalSIO
{
	internal class Article
	{
		private string _libelle;
		private int _tarifJournalier;
		private bool _disponible;
		private int _caution;
		private int _agenceId;

		public Article(string libelle, int tarifJournalier, bool disponible, int caution, int agenceId)
		{
			_libelle = libelle;
			_tarifJournalier = tarifJournalier;
			_disponible = disponible;
			_caution = caution;
			_agenceId = agenceId;
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

		public bool getDisponible()
		{
			return _disponible;
		}

		public void setDisponible(bool disponible)
		{
			_disponible = disponible;
		}

		public int getCaution()
		{
			return _caution;
		}

		public void setCaution(int caution)
		{
			_caution = caution;
		}

		public int getAgenceId()
		{
			return _agenceId
		}

		public void setAgenceId(int agenceId)
		{
			_agenceId = agenceId;
		}

		

	}
}
