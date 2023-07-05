namespace SuperBowlWeb.Models
{
    public class Equipe
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public int Cote { get; set; }

        public int? PaysId { get; set; }

        public Pays Pays { get; set; }
        public string URLlogo { get; set; }

        public ICollection<Joueur>? Joueurs{ get; set; }
    }
}
