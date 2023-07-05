﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperBowlWeb.Data;

#nullable disable

namespace SuperBowlWeb.Migrations
{
    [DbContext(typeof(SuperBowlWebContext))]
    [Migration("20230625225606_addedModelEntity")]
    partial class addedModelEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperBowlWeb.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cote")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaysId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("URLlogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Jeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Commentaires")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRencontre")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeAId")
                        .HasColumnType("int");

                    b.Property<int>("EquipeBId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipeGagnante")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("HeureDebut")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("HeureFin")
                        .HasColumnType("time");

                    b.Property<int?>("ScoreEquipeA")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreEquipeB")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EquipeAId");

                    b.HasIndex("EquipeBId");

                    b.ToTable("Jeux");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Joueur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("EquipeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Numero")
                        .HasColumnType("smallint");

                    b.Property<int>("PaysId")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("PaysId");

                    b.ToTable("Joueur");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Pari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateMise")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("MontantGagne")
                        .HasColumnType("int");

                    b.Property<int>("MontantMise")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("MatchId");

                    b.HasIndex("UserId");

                    b.ToTable("Pari");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumCode")
                        .HasColumnType("int");

                    b.Property<int>("PhoneCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Utilisateur", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RoleAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("RoleCommentateur")
                        .HasColumnType("bit");

                    b.Property<bool?>("RoleUtilisateur")
                        .HasColumnType("bit");

                    b.Property<bool?>("RoleVisiteur")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Equipe", b =>
                {
                    b.HasOne("SuperBowlWeb.Models.Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Jeu", b =>
                {
                    b.HasOne("SuperBowlWeb.Models.Equipe", "EquipeA")
                        .WithMany()
                        .HasForeignKey("EquipeAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperBowlWeb.Models.Equipe", "EquipeB")
                        .WithMany()
                        .HasForeignKey("EquipeBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipeA");

                    b.Navigation("EquipeB");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Joueur", b =>
                {
                    b.HasOne("SuperBowlWeb.Models.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperBowlWeb.Models.Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("SuperBowlWeb.Models.Pari", b =>
                {
                    b.HasOne("SuperBowlWeb.Models.Equipe", "EquipeMise")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperBowlWeb.Models.Jeu", "Jeu")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperBowlWeb.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipeMise");

                    b.Navigation("Jeu");

                    b.Navigation("Utilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
