using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SuperBowlWeb.Models
{
    public class PoolClasses
    {

        public class EQUIPE
        {
            public int Id { get; set; }

            public string Nom { get; set; }

            public int? PaysId { get; set; }
        }

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

        public class Jeu
        {
            public int Id { get; set; }

            public int EquipeA { get; set; }

            public int EquipeB { get; set; }

            public DateTime? DateRencontre { get; set; }

            public TimeSpan? HeureDebut { get; set; }

            public TimeSpan? HeureFin { get; set; }

            public int? ScoreEquipeA { get; set; }

            public int? ScoreEquipeB { get; set; }

            public int? EquipeGagnante { get; set; }

            public string Commentaires { get; set; }
        }

       

        public class Pari
        {
            public int Id { get; set; }

            public int MatchId { get; set; }

            public string UserId { get; set; }

            public int MontantMise { get; set; }

            public int EquipeId { get; set; }

            public Equipe EquipeMise { get; set; }

            
        }

        public class Pays
        {
            public int Id { get; set; }

            public string Iso { get; set; }

            public string Name { get; set; }

            public string Iso3 { get; set; }

            public int? NumCode { get; set; }

            public int PhoneCode { get; set; }
        }

        

        public class UTILISATEUR :IdentityUser
        {
           

            public string Nom { get; set; }

            public string Prenom { get; set; }           

            public bool? RoleAdmin { get; set; }

            public bool? RoleUtilisateur { get; set; }

            public bool? RoleCommentateur { get; set; }
        }


    }
}
