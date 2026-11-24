using System;

namespace LocaSIO
{
    internal class Contrat
    {
        public int ClientId { get; }
        private DateTime _dateDebut;
        private DateTime _dateFin;

        private int ArticleId { get; set; }

        private string _statut;
        private string _distinguishedName;

        public Contrat(
            int clientId,
            DateTime dateDebut,
            DateTime dateFin,
            string statut,
            string distinguishedName)
        {
            ClientId = clientId;
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _statut = statut;
            _distinguishedName = distinguishedName;
        }

        public DateTime getDateDebut()
        {
            return _dateDebut;
        }

        public DateTime DateDebut => _dateDebut;

        public void setDateDebut(DateTime dateDebut)
        {
            _dateDebut = dateDebut;
        }

        public DateTime getDateFin()
        {
            return _dateFin;
        }

        public DateTime DateFin => _dateFin;

        public void setDateFin(DateTime dateFin)
        {
            _dateFin = dateFin;
        }

        public string GetStatut()
        {
            return _statut;
        }

        public string Statut => _statut;

        public string GetDistinguishedName()
        {
            return _distinguishedName;
        }

        public string DistinguishedName => _distinguishedName;
    }
}