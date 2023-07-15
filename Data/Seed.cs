using Microsoft.AspNetCore.Identity;
using SuperBowlWeb.Models;
using SuperBowlWeb.Models.Constantes;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperBowlWeb.Data
{
    public class Seed
    {
        public static async Task SeedData(SuperBowlWebContext context, UserManager<Utilisateur> userManager)
        {
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

            if (!context.Jeux.Any())
            {
                List<Jeu> jeux = new List<Jeu>
                    {
                        new Jeu
                        {
                            EquipeAId = 1,
                            EquipeBId = 2,
                            DateRencontre = new DateTime(2024, 1, 24),
                            HeureDebut = new TimeSpan(13, 0, 0),
                            Meteo = "Ensoleille",
                            Commentaires = " ",
                            Status = "A venir",
                            StatusCode = 3,
                        },

                        new Jeu
                        {
                            EquipeAId = 1,
                            EquipeBId = 4,
                            DateRencontre = new DateTime(2024, 1, 25),
                            HeureDebut = new TimeSpan(13, 0, 0),
                            Meteo = "Ensoleille",
                            Commentaires = " ",
                            Status = "A venir",
                            StatusCode = 3,

                        },
                        new Jeu
                        {
                            EquipeAId = 2,
                            EquipeBId = 3,
                            DateRencontre = new DateTime(2024, 1, 26),
                            HeureDebut = new TimeSpan(13, 0, 0),
                            Meteo = "Ensoleille",
                            Commentaires = " ",
                            Status = "A venir",
                            StatusCode = 3,
                        },
                        new Jeu
                        {
                            EquipeAId = 3,
                            EquipeBId = 4,
                            DateRencontre = new DateTime(2023, 06, 30),
                            HeureDebut = new TimeSpan(13, 0, 0),
                            Meteo = "Ensoleille",
                            Commentaires = " ",
                            Status = "Termine",
                            StatusCode = 0,
                        },

                        new Jeu
                        {
                            EquipeAId = 1,
                            EquipeBId = 2,
                            DateRencontre = new DateTime(2023, 6, 30),
                            HeureDebut = new TimeSpan(13, 0, 0),
                            Meteo = "Nuageux",
                            Commentaires = " ",
                            Status = "En Cours",
                            StatusCode = 2,
                        },
                        new Jeu
                        {
                            EquipeAId = 3,
                            EquipeBId = 4,
                            DateRencontre = new DateTime(2023, 6, 30),
                            HeureDebut = new TimeSpan(16, 0, 0),
                            Meteo = "Ensoleille",
                            Commentaires = " ",
                            Status = "En Cours",
                            StatusCode = 2,
                        }

                    };
                await context.AddRangeAsync(jeux);
                await context.SaveChangesAsync();
            }
            if (!context.Joueur.Any())
            {

                //Id Nom Prenom Numero  EquipeId PaysId
                //1   yannick nagau   1   2   75
                //2   djibril sankofa 2   2   75
                //3   Cyril nganou  1   1   75
                //4   Levetic Test    2   1   75
                List<Joueur> joueurs = new List<Joueur> {
                    //Equipe 2
                    new Joueur
                    {
                        Nom="Nagau",
                        Prenom="Yannick",
                        Numero=1,
                        EquipeId=2,
                        PaysId=75,
                    },
                    new Joueur
                    {
                        Nom="Sankofa",
                        Prenom="Djibril",
                        Numero=2,
                        EquipeId=2,
                        PaysId=75,
                    },
                    new Joueur
                    {
                        Nom="Artemis",
                        Prenom="Issac",
                        Numero=3,
                        EquipeId=2,
                        PaysId=75,
                    },

                    //Equipe 1 \\
                    new Joueur
                    {
                        Nom="Gomaal",
                        Prenom="Likongo",
                        Numero=1,
                        EquipeId=1,
                        PaysId=74,
                    },
                    new Joueur
                    {
                        Nom="Bertrand",
                        Prenom="narmur",
                        Numero=2,
                        EquipeId=1,
                        PaysId=75,
                    },
                    new Joueur
                    {
                        Nom="Pedro",
                        Prenom="Alvarez",
                        Numero=3,
                        EquipeId=1,
                        PaysId=23,
                    },
                    //Equipe 3 \\
                    new Joueur
                    {
                        Nom="AlexandorPulos",
                        Prenom="Ishti",
                        Numero=1,
                        EquipeId=3,
                        PaysId=12,
                    },
                    new Joueur
                    {
                        Nom="Loviam",
                        Prenom="Istanbul",
                        Numero=1,
                        EquipeId=3,
                        PaysId=66,
                    },
                    new Joueur
                    {
                        Nom="Greek",
                        Prenom="Legreek",
                        Numero=1,
                        EquipeId=3,
                        PaysId=26,
                    },

                    //Equipe 4 \\
                    new Joueur
                    {
                        Nom="Rafaelo",
                        Prenom="Di Vanci",
                        Numero=1,
                        EquipeId=4,
                        PaysId=63,
                    },
                    new Joueur
                    {
                        Nom="Stalone",
                        Prenom="Silvestre",
                        Numero=2,
                        EquipeId=4,
                        PaysId=63,
                    },
                    new Joueur
                    {
                        Nom="Robot",
                        Prenom="LeCop",
                        Numero=3,
                        EquipeId=4,
                        PaysId=63,
                    },
                };
                await context.AddRangeAsync(joueurs);
                await context.SaveChangesAsync();
            }
            if (!userManager.Users.Any())
            {
                var users = new List<Utilisateur>
                {
                    new Utilisateur {
                        UserName="nago",
                        Nom = "NagoSeed",
                        Prenom = "YannickSeed",
                        Email="nago@test.com",
                        Role=(int)RoleUser.Utilisateur

                    },
                    new Utilisateur {
                        UserName="kimuntu",
                        Nom = "kimuntuSeed",
                        Prenom = "kongoSeed",
                        Email="kimuntu@test.com",
                        Role=(int)RoleUser.Utilisateur

                    },
                    new Utilisateur {
                        UserName="comment",
                        Nom = "Comment",
                        Prenom = "PrenomSeed",
                        Email="comment@test.com",
                        Role=(int)RoleUser.Commentateur

                    },
                    new Utilisateur {

                        UserName="admin",
                        Nom = "Admin",
                        Prenom = "Prenom",
                        Email="admin@test.com",
                        Role= (int)RoleUser.Admin

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
            }
        }
    }
}
