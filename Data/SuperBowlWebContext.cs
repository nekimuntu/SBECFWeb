using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Models;
using SuperBowlWeb.Models.DateConversion;

namespace SuperBowlWeb.Data
{
    public class SuperBowlWebContext : IdentityDbContext<Utilisateur>
    {
        public SuperBowlWebContext (DbContextOptions<SuperBowlWebContext> options)
            : base(options)
        {
        }

        public DbSet<SuperBowlWeb.Models.Jeu> Jeux { get; set; } = default!;
        public DbSet<SuperBowlWeb.Models.Equipe> Equipe { get; set; } = default!;
        public DbSet<SuperBowlWeb.Models.Pays> Pays { get; set; } = default!;
        public DbSet<SuperBowlWeb.Models.Pari> Pari { get; set; } = default!;
        public DbSet<SuperBowlWeb.Models.Joueur> Joueur { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Equipe>()
                .HasOne(x => x.Pays)
                .WithMany()
                .HasForeignKey(x => x.PaysId);
            modelBuilder.Entity<Equipe>()
                .HasMany<Joueur>(x => x.Joueurs)
                .WithOne(x=>x.Equipe)
                .HasForeignKey(x => x.EquipeId);

            modelBuilder.Entity<Jeu>()
               .HasOne(x => x.EquipeA)
               .WithMany()
               .HasForeignKey(x => x.EquipeAId);
            modelBuilder.Entity<Jeu>()
               .HasOne(x => x.EquipeB)
               .WithMany()
               .HasForeignKey(x => x.EquipeBId);

            modelBuilder.Entity<Pari>()
                .HasOne(x => x.Jeu)
                .WithMany()
                .HasForeignKey(x => x.MatchId);
            modelBuilder.Entity<Pari>()
                .HasOne(x => x.EquipeMise)
                .WithMany()
                .HasForeignKey(x => x.EquipeId);
            modelBuilder.Entity<Pari>()
                .HasOne(x => x.Utilisateur)
                .WithMany()
                .HasForeignKey(x => x.UserId);
            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();
        }
    }                                                                            
}
