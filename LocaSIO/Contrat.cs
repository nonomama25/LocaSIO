using System;
namespace locaSIO
{



    public enum StatutContrat
    {
        EnAttente,
        Actif,
        Termine,
        Annule
    }

    public class Contrat
    {
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private StatutContrat _statut;
        private string _distinguishedName;

        public Contrat(DateTime dateDebut, DateTime dateFin, StatutContrat statut, string distinguishedName)
        {
            SetPeriode(dateDebut, dateFin);
            Statut = statut;
            DistinguishedName = distinguishedName;
        }

        public DateTime DateDebut => _dateDebut;
        public DateTime DateFin => _dateFin;

        public StatutContrat Statut
        {
            get => _statut;
            set
            {
                if (!Enum.IsDefined(typeof(StatutContrat), value))
                    throw new ArgumentException("Statut invalide.");
                _statut = value;
            }
        }

        public string DistinguishedName
        {
            get => _distinguishedName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le distinguished name est obligatoire.");
                _distinguishedName = value;
            }
        }

        public void SetPeriode(DateTime dateDebut, DateTime dateFin)
        {
            if (dateFin < dateDebut)
                throw new ArgumentException("La date de fin doit être postérieure à la date de début.");

            _dateDebut = dateDebut;
            _dateFin = dateFin;
        }

        public override string ToString()
        {
            return $"Contrat[{DistinguishedName}, {DateDebut:dd/MM/yyyy} -> {DateFin:dd/MM/yyyy}, {Statut}]";
        }
    }

}