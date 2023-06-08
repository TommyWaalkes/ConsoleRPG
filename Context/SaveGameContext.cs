using Microsoft.EntityFrameworkCore;
using RPGConsoleGame.Factions;
using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using RPGConsoleGame.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RPGConsoleGame.Context
{
    internal class SaveGameContext : DbContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Race> Races { get; set; }
        DbSet<Faction> Factions { get; set; }
        DbSet<Stats> Stats { get; set; }
        DbSet<Growths> Growths { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<Attack> Attacks { get; set; }
        DbSet<Effect> Effects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=RPGConsoleGame;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HealSkill>();
            builder.Entity<Buff>();
            builder.Entity<NobleEmpire>();
            builder.Entity<Mage>();
            builder.Entity<Fighter>();
            builder.Entity<Human>();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
