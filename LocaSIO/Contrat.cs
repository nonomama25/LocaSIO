using System;

namespace locaSIO
{
    internal class Contrat
    {
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private StatutContrat _statut;
        private string _distinguishedName;

        public Contrat(DateTime dateDebut, DateTime dateFin, StatutContrat statut, string distinguishedName)
        {
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _statut = statut;
            _distinguishedName = distinguishedName;
        }

        public Datetime getDateDebut()
        {
            return _dateDebut
        }

        public void setDateDebut(DateTime )
        {
            this._nom = nom;
        }

        public Datetime getDateFin()
        {
            return _dateFin
        }

        public void setDateFin(DateTime )
        {
            this._dateFin = DateFin;
        }

        public StatutContrat GetStatut(StatutContrat)
        {
            return _statut
        }

        public void setStatut(StatutContrat )
        {
            this._dateFin = DateFin;
        }

        public string GetDistinguishedName(distinguishedName)
        {
            return _distinguishedName
        }

        public void setDistinguishedName(distinguishedName)
        {
            this._dateFin = DateFin;
        }


    }

}