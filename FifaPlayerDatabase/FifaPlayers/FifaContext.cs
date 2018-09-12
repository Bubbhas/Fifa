using FifaPlayers.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FifaPlayers
{
    class FifaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeamPlayer> UserTeamPlayers { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<RealTeam> RealTeams { get; set; }
        public DbSet<FootballPlayer> FootballPlayers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = DbFifa;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTeamPlayer>().HasKey(x => new { x.PlayerId, x.UserTeamId });
        }
    }
}
