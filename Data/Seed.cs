using Microsoft.AspNetCore.Identity;
using SuperBowlWeb.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperBowlWeb.Data
{
    public class Seed
    {
        public static async Task SeedData(SuperBowlWebContext context, UserManager<Utilisateur> userManager)
        {
            //List<Jeu> jeux1 = new List<Jeu>
            //    {
            //        new Jeu
            //        {
            //            EquipeAId = 1,
            //            EquipeBId = 2,
            //            DateRencontre = new DateOnly(2023, 6, 30),
            //            HeureDebut = new TimeSpan(13, 0, 0),
            //            Meteo = "Nuageux",
            //            Commentaires = " ",
            //            Status = "En Cours",
            //            StatusCode = 2,
            //        },
            //        new Jeu
            //        {
            //            EquipeAId = 3,
            //            EquipeBId = 4,
            //            DateRencontre = new DateOnly(2023, 6, 30),
            //            HeureDebut = new TimeSpan(16, 0, 0),
            //            Meteo = "Ensoleille",
            //            Commentaires = " ",
            //            Status = "En Cours",
            //            StatusCode = 2,
            //        }
            //};
            //await context.Jeux.AddRangeAsync(jeux1);
            //await context.SaveChangesAsync();
            if (!userManager.Users.Any())
            {
                var users = new List<Utilisateur>
                {
                    new Utilisateur {
                        UserName="nago",
                        Nom = "NagoSeed",
                        Prenom = "YannickSeed",
                        Email="nago@test.com",
                        RoleUtilisateur=true

                    },
                    new Utilisateur {
                        UserName="kimuntu",
                        Nom = "kimuntuSeed",
                        Prenom = "kongoSeed",
                        Email="kimuntu@test.com",
                        RoleUtilisateur=true

                    },
                    new Utilisateur {
                        UserName="comment",
                        Nom = "Comment",
                        Prenom = "PrenomSeed",
                        Email="comment@test.com",
                        RoleCommentateur=true

                    },
                    new Utilisateur {

                        UserName="admin",
                        Nom = "Admin",
                        Prenom = "Prenom",
                        Email="admin@test.com",
                        RoleCommentateur=true

                    }
                };

                foreach (var user in users)
                {
                    IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");
                    if (!result.Succeeded)
                    {
                        //Do something with the errors  
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                }


                if (!context.Jeux.Any())
                {
                    List<Jeu> jeux = new List<Jeu>
                {
                    new Jeu
                    {
                        EquipeAId = 1,
                        EquipeBId = 2,
                        DateRencontre = new DateTime(2024, 1, 24),
                        HeureDebut = new TimeSpan(13, 0, 0)
                    },

                    new Jeu
                    {
                        EquipeAId = 1,
                        EquipeBId = 4,
                        DateRencontre = new DateTime(2024, 1, 25),
                        HeureDebut = new TimeSpan(13, 0, 0)
                    },
                    new Jeu
                    {
                        EquipeAId = 2,
                        EquipeBId = 3,
                        DateRencontre = new DateTime(2024, 1, 26),
                        HeureDebut = new TimeSpan(13, 0, 0)
                    },
                    new Jeu
                    {
                        EquipeAId = 3,
                        EquipeBId = 4,
                        DateRencontre = new DateTime(2023, 06, 30),
                        HeureDebut = new TimeSpan(13, 0, 0)
                    }
                };
                    await context.Jeux.AddRangeAsync(jeux);
                    await context.SaveChangesAsync();
                }
                if (!context.Equipe.Any())
                {
                    var equipes = new List<Equipe>
                {
                    new Equipe
                    {
                        Nom="PSG",
                        PaysId=1,
                        URLlogo="/assets/pict/psg.png"
                    },
                    new Equipe
                    {
                        Nom="Metz",
                        PaysId=1,
                        URLlogo="/assets/pict/metz.png"
                    },
                    new Equipe
                    {
                        Nom="Nantes",
                        PaysId=1,
                        URLlogo="/assets/pict/nantes.jpg"
                    },
                    new Equipe
                    {
                        Nom="Marseille",
                        PaysId=1,
                        URLlogo="/assets/pict/marseille.png"
                    }
                };
                    await context.Equipe.AddRangeAsync(equipes);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
