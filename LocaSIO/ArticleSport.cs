using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
    internal class ArticleSport : Article
    {
        private string _typeMateriel;
        private int _niveau;
        private string _saison;

        public ArticleSport(string typeMateriel, int niveau, string saison, string libelle, int tarifJournalier, bool disponible, int caution, int agenceId)
            : base(libelle, tarifJournalier, disponible, caution, agenceId)
        {
            this._typeMateriel = typeMateriel;
            this._niveau = niveau;
            this._saison = saison;
        }

        public string getTypeMateriel()
        {
            return _typeMateriel;
        }
        public void setTypeMateriel(string typeMateriel)
        {
            this._typeMateriel = typeMateriel;
        }
        public int getNbPiece()
        {
            return _nbPiece;
        }
        public void setNbPiece(int nbPiece)
        {
            this._nbPiece = nbPiece;
        }
        public string getSaison()
        {
            return _saison;
        }

        public void setSaison(string saison)
        {
            this._saison = saison;
        }
    }
}