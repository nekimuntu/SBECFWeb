using System.ComponentModel.DataAnnotations;

namespace SuperBowlWeb.Models
{
    public class Joueur
    {
        [Key]
        public long Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public short Numero { get; set; }

        public int? EquipeId { get; set; }
        public Equipe Equipe { get; set; }

        public int PaysId { get; set; }
        public Pays Pays { get; set; }
    }
}
