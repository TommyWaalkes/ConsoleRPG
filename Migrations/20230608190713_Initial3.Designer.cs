﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGConsoleGame.Context;

#nullable disable

namespace RPGConsoleGame.Migrations
{
    [DbContext(typeof(SaveGameContext))]
    [Migration("20230608190713_Initial3")]
    partial class Initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RPGConsoleGame.Attack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("damageType")
                        .HasColumnType("int");

                    b.Property<int>("maxDamage")
                        .HasColumnType("int");

                    b.Property<int>("minDamage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Attacks");
                });

            modelBuilder.Entity("RPGConsoleGame.Factions.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InitialGrowthsId")
                        .HasColumnType("int");

                    b.Property<int>("InitialStatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InitialGrowthsId");

                    b.HasIndex("InitialStatsId");

                    b.ToTable("Factions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Faction");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RPGConsoleGame.Growths", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Growths");
                });

            modelBuilder.Entity("RPGConsoleGame.Jobs.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("GrowthsId")
                        .HasColumnType("int");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.HasIndex("GrowthsId");

                    b.HasIndex("StatsId");

                    b.ToTable("Jobs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Job");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RPGConsoleGame.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("GrowthsId")
                        .HasColumnType("int");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrowthsId");

                    b.HasIndex("JobId");

                    b.HasIndex("RaceId");

                    b.HasIndex("StatsId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RPGConsoleGame.Races.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("GrowthsId")
                        .HasColumnType("int");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.HasIndex("GrowthsId");

                    b.HasIndex("StatsId");

                    b.ToTable("Races");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Race");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Magnitude")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Skills");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Skill");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RPGConsoleGame.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HpCurrent")
                        .HasColumnType("int");

                    b.Property<int>("HpMax")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Xp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("RPGConsoleGame.Factions.NobleEmpire", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Factions.Faction");

                    b.HasDiscriminator().HasValue("NobleEmpire");
                });

            modelBuilder.Entity("RPGConsoleGame.Jobs.Fighter", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Jobs.Job");

                    b.HasDiscriminator().HasValue("Fighter");
                });

            modelBuilder.Entity("RPGConsoleGame.Jobs.Mage", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Jobs.Job");

                    b.HasDiscriminator().HasValue("Mage");
                });

            modelBuilder.Entity("RPGConsoleGame.Races.Human", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Races.Race");

                    b.HasDiscriminator().HasValue("Human");
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.Buff", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Skills.Skill");

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<int>("CastLevel")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Buff");
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.HealSkill", b =>
                {
                    b.HasBaseType("RPGConsoleGame.Skills.Skill");

                    b.HasDiscriminator().HasValue("HealSkill");
                });

            modelBuilder.Entity("RPGConsoleGame.Attack", b =>
                {
                    b.HasOne("RPGConsoleGame.Jobs.Job", null)
                        .WithMany("Attacks")
                        .HasForeignKey("JobId");

                    b.HasOne("RPGConsoleGame.Player", null)
                        .WithMany("Attacks")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("RPGConsoleGame.Factions.Faction", b =>
                {
                    b.HasOne("RPGConsoleGame.Growths", "InitialGrowths")
                        .WithMany()
                        .HasForeignKey("InitialGrowthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGConsoleGame.Stats", "InitialStats")
                        .WithMany()
                        .HasForeignKey("InitialStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InitialGrowths");

                    b.Navigation("InitialStats");
                });

            modelBuilder.Entity("RPGConsoleGame.Jobs.Job", b =>
                {
                    b.HasOne("RPGConsoleGame.Factions.Faction", null)
                        .WithMany("AllowedJobs")
                        .HasForeignKey("FactionId");

                    b.HasOne("RPGConsoleGame.Growths", "Growths")
                        .WithMany()
                        .HasForeignKey("GrowthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGConsoleGame.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Growths");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("RPGConsoleGame.Player", b =>
                {
                    b.HasOne("RPGConsoleGame.Growths", "Growths")
                        .WithMany()
                        .HasForeignKey("GrowthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGConsoleGame.Jobs.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("RPGConsoleGame.Races.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGConsoleGame.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Growths");

                    b.Navigation("Job");

                    b.Navigation("Race");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("RPGConsoleGame.Races.Race", b =>
                {
                    b.HasOne("RPGConsoleGame.Factions.Faction", null)
                        .WithMany("AllowedRaces")
                        .HasForeignKey("FactionId");

                    b.HasOne("RPGConsoleGame.Growths", "Growths")
                        .WithMany()
                        .HasForeignKey("GrowthsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGConsoleGame.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Growths");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.Effect", b =>
                {
                    b.HasOne("RPGConsoleGame.Player", null)
                        .WithMany("Effects")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("RPGConsoleGame.Skills.Skill", b =>
                {
                    b.HasOne("RPGConsoleGame.Player", null)
                        .WithMany("Skills")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("RPGConsoleGame.Factions.Faction", b =>
                {
                    b.Navigation("AllowedJobs");

                    b.Navigation("AllowedRaces");
                });

            modelBuilder.Entity("RPGConsoleGame.Jobs.Job", b =>
                {
                    b.Navigation("Attacks");
                });

            modelBuilder.Entity("RPGConsoleGame.Player", b =>
                {
                    b.Navigation("Attacks");

                    b.Navigation("Effects");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
