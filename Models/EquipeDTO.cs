namespace SuperBowlWeb.Models
{
    public class EquipeDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public int Cote { get; set; }

        public int? PaysId { get; set; }

        public string Pays { get; set; }
        public string URLlogo { get; set; }
        public string Iso { get; set; }
        public ICollection<JoueurDTO> Joueurs { get; set; }
    }
}
