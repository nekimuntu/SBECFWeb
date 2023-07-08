namespace SuperBowlWeb.Controllers.DTO
{
    public class PariDTO
    {
        public int MatchId { get; set; }
        public string UserId { get; set; }
        public int MontantMise { get; set; }
        public int? MontantGagne { get; set; }
        public DateTime DateMise { get; set; }
        public int EquipeId { get; set; }
    }
}
