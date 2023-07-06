namespace SuperBowlWeb.Models
{
    public class JoueurDTO
    {
        public long Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public short Numero { get; set; }

        public int? EquipeId { get; set; }
        
        public string Pays { get; set; }
    }
}
