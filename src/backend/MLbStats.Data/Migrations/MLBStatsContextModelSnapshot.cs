﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MLBStats.Data;

namespace MLBStats.Data.Migrations
{
    [DbContext(typeof(MLBStatsContext))]
    partial class MLBStatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MLBStats.Core.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("MLBStats.Core.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<string>("Height");

                    b.Property<string>("Name");

                    b.Property<int>("WeightLbs");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MLBStats.Core.Models.PlayerStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtBat");

                    b.Property<int>("GamesPlayed");

                    b.Property<int>("Hits");

                    b.Property<int>("HomeRuns");

                    b.Property<int>("PlayerId");

                    b.Property<int>("RBIs");

                    b.Property<int>("SeasonId");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerStatistics");
                });

            modelBuilder.Entity("MLBStats.Core.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MLBStats.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MLBStats.Core.Models.PlayerStatistic", b =>
                {
                    b.HasOne("MLBStats.Core.Models.Player")
                        .WithMany("PlayerStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLBStats.Core.Models.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLBStats.Core.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MLBStats.Core.Models.Team", b =>
                {
                    b.HasOne("MLBStats.Core.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
