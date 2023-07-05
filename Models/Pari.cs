namespace SuperBowlWeb.Models
{
    public class Pari
    {
        
        public int Id { get; set; }

        public int MatchId { get; set; }
        public Jeu? Jeu { get; set; }

        public string UserId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public int MontantMise { get; set; }
        public int? MontantGagne { get; set; }
        public DateTime DateMise { get; set; }

        public int EquipeId { get; set; }

        public Equipe? EquipeMise { get; set; }

    }
}
