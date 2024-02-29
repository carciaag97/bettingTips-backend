
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
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
            modelBuilder.Entity<Category>().ToTable("Categories").HasKey(c => c.Id);
            modelBuilder.Entity<Photo>().ToTable("Photos").HasKey(p => p.Id);
            modelBuilder.Entity<Post>().ToTable("Posts").HasKey(ps => ps.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(post => post.User)
                .HasForeignKey(post => post.UserId);

            modelBuilder.Entity<Category>()
              .HasMany(u => u.Posts)
              .WithOne(post => post.Category)
              .HasForeignKey(post => post.CategoryId);

            modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Photo>()
                .HasOne(photo => photo.Post)
                .WithMany(post => post.photos)
                .HasForeignKey(photo => photo.PostId);

            new DbInitializer(modelBuilder).Seed();   
        }
    }
}
