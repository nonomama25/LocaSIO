using System;

namespace LocaSIO
{
    internal class Contrat
    {
        private DateTime _dateDebut;
        private DateTime _dateFin;

        private string _statut;
        private string _distinguishedName;

        public Contrat(
            DateTime dateDebut,
            DateTime dateFin,
            string statut,
            string distinguishedName)
        {
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _statut = statut;
            _distinguishedName = distinguishedName;
        }

        public DateTime getDateDebut()
        {
            return _dateDebut;
        }

        public void setDateDebut(DateTime dateDebut)
        {
            _dateDebut = dateDebut;
        }

        public DateTime getDateFin()
        {
            return _dateFin;
        }

        public void setDateFin(DateTime dateFin)
        {
            _dateFin = dateFin;
        }

        public string GetStatut()
        {
            return _statut;
        }

        public string GetDistinguishedName()
        {
            return _distinguishedName;
        }
    }
}