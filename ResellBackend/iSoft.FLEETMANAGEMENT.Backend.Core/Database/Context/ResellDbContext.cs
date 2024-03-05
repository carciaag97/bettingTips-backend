
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Config;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context
{
    public class ResellDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public ResellDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseSqlServer(AppConfig.ConnectionStringConfig.MainDatabase);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TicketMatch> TicketMatches { get; set; }

       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
            modelBuilder.Entity<Category>().ToTable("Categories").HasKey(c => c.Id);
            modelBuilder.Entity<Statistics>().ToTable("Statistics").HasKey(s => s.Id);
            modelBuilder.Entity<Ticket>().ToTable("Tickets").HasKey(tc => tc.Id);
            modelBuilder.Entity<Team>().ToTable("Teams").HasKey(t => t.Id);
            modelBuilder.Entity<News>().ToTable("News").HasKey(n => n.Id);
            modelBuilder.Entity<Match>().ToTable("Matches").HasKey(m => m.Id);
            modelBuilder.Entity<TicketMatch>().ToTable("TicketMatches").HasKey(tm => new { tm.TicketId, tm.MatchId });


            modelBuilder.Entity<User>()
            .HasMany(u => u.Tickets)
            .WithOne(ticket => ticket.User)
            .HasForeignKey(ticket => ticket.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.News)
                .WithOne(news => news.User)
                .HasForeignKey(news => news.UserId);

            modelBuilder.Entity<Category>()
                .HasMany(u => u.Tickets)
                .WithOne(ticket => ticket.Category)
                .HasForeignKey(ticket => ticket.CategoryId);
            modelBuilder.Entity<Category>()
                .HasOne(s => s.Statistics)
                .WithOne(stat => stat.Category)
                .HasForeignKey<Statistics>(stat => stat.CategoryId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<News>()
                .HasOne(news => news.User)
                .WithMany(user => user.News)
                .HasForeignKey(news => news.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Matches)
                .WithOne(m => m.Ticket)
                .HasForeignKey(m => m.TicketId);


            modelBuilder.Entity<TicketMatch>()
            .HasOne(tm => tm.Ticket)
            .WithMany(t => t.Matches)
            .HasForeignKey(tm => tm.TicketId);

            modelBuilder.Entity<TicketMatch>()
                .HasOne(tm => tm.Match)
                .WithMany(m => m.Tickets)
                .HasForeignKey(tm => tm.MatchId);

            new DbInitializer(modelBuilder).Seed();   
        }
    }
}
