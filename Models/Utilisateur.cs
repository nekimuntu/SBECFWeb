using Microsoft.AspNetCore.Identity;

namespace SuperBowlWeb.Models
{
    public class Utilisateur : IdentityUser
    {


        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Role { get; set; }
    }
}
