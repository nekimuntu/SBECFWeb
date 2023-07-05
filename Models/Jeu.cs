using System.ComponentModel.DataAnnotations;

namespace SuperBowlWeb.Models
{
    public class Jeu
    {
        public int Id { get; set; }

        public int EquipeAId { get; set; }
        public Equipe? EquipeA { get; set; }

        public int EquipeBId { get; set; }
        public Equipe? EquipeB { get; set; }
        public string Meteo { get; set; }

        [Display (Name = "Date de la rencontre")]
        public DateTime? DateRencontre { get; set; }
        [Display(Name = "Debut")]
        public TimeSpan? HeureDebut { get; set; }
        [Display(Name = "Fin")]
        public TimeSpan? HeureFin { get; set; }

        [Display(Name = "Score equipe A")]
        public int? ScoreEquipeA { get; set; }
        [Display(Name = "Score equipe B")]
        public int? ScoreEquipeB { get; set; }

        public int? EquipeGagnante { get; set; }

        public string? Commentaires { get; set; }
        public string Status { get; set; }
        public short StatusCode { get; set; }
    }
}
