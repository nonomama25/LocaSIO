using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
    internal class ArticleEvenement : Article
    {
        private string _typeMateriel;
        private int _nbPiece;
        private bool _Electrique;

        public ArticleEvenement(string typeMateriel, int nbPiece, bool Electrique, string libelle, int tarifJournalier, int caution, int agenceId, string type)
            : base(libelle, tarifJournalier, caution, agenceId, type)
        {
            this._typeMateriel = typeMateriel;
            this._nbPiece = nbPiece;
            this._Electrique = Electrique;
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
        public bool getElectrique()
        {
            return _Electrique;
        }

        public void setElectrique(bool Electrique)
        {
            this._Electrique = Electrique;
        }
    }
}