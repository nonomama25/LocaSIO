namespace LocaSIO
{
    public class Agence
    {
        public int Id { get; set; }
        public string Ville { get; set; }
        public string UO { get; set; }

        public Agence(int id, string ville, string uo)
        {
            Id = id;
            Ville = ville;
            UO = uo;
        }

        public Agence(string ville, string uo)
        {
            Ville = ville;
            UO = uo;
        }
    }
}