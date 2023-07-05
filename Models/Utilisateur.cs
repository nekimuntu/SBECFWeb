using Microsoft.AspNetCore.Identity;

namespace SuperBowlWeb.Models
{
    public class Utilisateur : IdentityUser
    {


        public string Nom { get; set; }

        public string Prenom { get; set; }

        public bool? RoleVisiteur { get; set; }
        public bool? RoleUtilisateur { get; set; }

        public bool? RoleCommentateur { get; set; }
        public bool? RoleAdmin { get; set; }
    }
}
