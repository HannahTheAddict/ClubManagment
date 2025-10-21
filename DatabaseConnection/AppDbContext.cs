using HannahElSayed0523003.Models;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.DatabaseConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasIndex(x => x.TeamName).IsUnique();
            //coach-team 1:1
            modelBuilder.Entity<Coach>()
                .HasOne(x => x.Team)
                .WithOne(x => x.coach)
                .HasForeignKey<Team>(x => x.CoachID);
            //team-player 1:m
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Players)
                .WithOne(x => x.Team);

            //team-competition m:m
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Competitions)
                .WithMany(x => x.Teams);

            modelBuilder.Entity<Coach>()
                .HasData(
                new Coach
                {
                    CoachID = 1,
                    CoachName = "lama",
                    ExperienceYears = 3,
                    Specialization = "C#"
                }, new Coach
                {
                    CoachID = 2,
                    CoachName = "salma",
                    ExperienceYears = 4,
                    Specialization = "C++"
                }, new Coach
                {
                    CoachID = 3,
                    CoachName = "laimya",
                    ExperienceYears = 5,
                    Specialization = "F#"
                }, new Coach
                {
                    CoachID = 4,
                    CoachName = "slama",
                    ExperienceYears = 10,
                    Specialization = "WebAPI"
                }, new Coach
                {
                    CoachID = 5,
                    CoachName = "hanna",
                    ExperienceYears = 3,
                    Specialization = "C#"
                }
                );

            modelBuilder.Entity<Team>()
                .HasData(
                new Team
                {
                    TeamID = 1,
                    TeamName = "the wtv",
                    City = "Cairo",
                    CoachID = 1
                }, new Team
                {
                    TeamID = 2,
                    TeamName = "the lll",
                    City = "Giza",
                    CoachID = 2
                }, new Team
                {
                    TeamID = 3,
                    TeamName = "idk",
                    City = "Cairo",
                    CoachID = 3
                }, new Team
                {
                    TeamID = 4,
                    TeamName = "idk2",
                    City = "Alexandria",
                    CoachID = 4
                }, new Team
                {
                    TeamID = 5,
                    TeamName = "greeners",
                    City = "Giza",
                    CoachID = 5
                }
                );

            modelBuilder.Entity<Player>()
                .HasData(
                new Player
                {
                    PlayerID = 1,
                    PlayerName = "ahmed",
                    Age = 17,
                    Position = "leader",
                    TeamID = 1
                }, new Player
                {
                    PlayerID = 2,
                    PlayerName = "mohamed",
                    Age = 18,
                    Position = "member",
                    TeamID = 2
                }, new Player
                {
                    PlayerID = 3,
                    PlayerName = "mahmoud",
                    Age = 19,
                    Position = "leader",
                    TeamID = 3
                }, new Player
                {
                    PlayerID = 4,
                    PlayerName = "salama",
                    Age = 15,
                    Position = "member",
                    TeamID = 4
                }, new Player
                {
                    PlayerID = 5,
                    PlayerName = "yousef",
                    Age = 17,
                    Position = "member",
                    TeamID = 4
                }
                );

            modelBuilder.Entity<Competition>()
                .HasData(
                new Competition
                {
                    CompetitionID = 1,
                    CompetitionName = "app dev",
                    Location = "Cairo",
                    Date = DateTime.UtcNow.AddDays(-10)
                }, new Competition
                {
                    CompetitionID = 2,
                    CompetitionName = "web dev",
                    Location = "Giza",
                    Date = DateTime.UtcNow.AddDays(-20)
                }, new Competition
                {
                    CompetitionID = 3,
                    CompetitionName = "desktop dev",
                    Location = "Alexandria",
                    Date = DateTime.UtcNow.AddDays(-30)
                }, new Competition
                {
                    CompetitionID = 4,
                    CompetitionName = "mobile dev",
                    Location = "Giza",
                    Date = DateTime.UtcNow.AddDays(-25)
                }, new Competition
                {
                    CompetitionID = 5,
                    CompetitionName = "lol",
                    Location = "Cairo",
                    Date = DateTime.UtcNow.AddDays(-30)
                }

                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
