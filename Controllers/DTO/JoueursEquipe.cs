using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers.DTO
{
    public class JoueursEquipe
    {
        public Equipe Equipe{ get; set; }
        public List<Joueur> Joueurs { get; set; }
    }
}
