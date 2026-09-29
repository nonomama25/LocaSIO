using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
    internal class ArticleSport : Article
    {
        private string _immatriculation;
        private string _typeVehicule;
        private int _nbKilometre;
        private string _typeCarburant;

        public ArticleSport(string immatriculation, string typeVehicule, int nbKilometre, string typeCarburant, string libelle, int tarifJournalier, bool disponible, int caution, int agenceId)
            : base(libelle, tarifJournalier, disponible, caution, agenceId)
        {
            this._immatriculation = immatriculation;
            this._typeVehicule = typeVehicule;
            this._nbKilometre = nbKilometre;
            this._saison = saison;
        }

        public string getTypeVehicule()
        {
            return _typeVehicule;
        }
        public void setTypeVehicule(string typeVehicule)
        {
            this._typeVehicule = typeVehicule;
        }
        public string getImmatriculation()
        {
            return _immatriculation;
        }
        public void setImmatriculation(string immatriculation)
        {
            this._immatriculation = immatriculation;
        }
        public int getNbKilometre()
        {
            return _nbKilometre;
        }
        public void setNbKilometre(int nbKilometre)
        {
            this._nbKilometre = nbKilometre;
        }
        public string getTypeCarburant()
        {
            return _typeCarburant;
        }

        public void setTypeCarburant(string typeCarburant)
        {
            this._typeCarburant = typeCarburant;
        }
    }
}