using LifePlanner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifePlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admini { get; set; }

        public DbSet<Jelo> Jela { get; set; }

        public DbSet<NeregistrovaniKorisnik> NeregistrovaniKorisnici { get; set; }

        public DbSet<Raspolozenje> Raspolozenja { get; set; }

        public DbSet<RegistrovaniKorisnik> RegistrovaniKorisnici { get; set; }

        public DbSet<Task> Taskovi { get; set; }

        public DbSet<Trening> Treninzi { get; set; }

        public DbSet<Voda> KolicineVode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var splitStringConverter = new ValueConverter<IList<String>, String>(v => String.Join("@", v), v => v.Split(new[] { '@' }));
            modelBuilder.Entity<Trening>().Property(nameof(Trening.Vjezbe)).HasConversion(splitStringConverter);
            modelBuilder.Entity<Jelo>().Property(nameof(Jelo.Sastojci)).HasConversion(splitStringConverter);

            modelBuilder.Entity<Admin>().ToTable("Admini");
            modelBuilder.Entity<Jelo>().ToTable("Jela");
            modelBuilder.Entity<NeregistrovaniKorisnik>().ToTable("NeregistrovaniKorisnici");
            modelBuilder.Entity<Raspolozenje>().ToTable("Raspolozenja");
            modelBuilder.Entity<RegistrovaniKorisnik>().ToTable("RegistrovaniKorisnici");
            modelBuilder.Entity<Task>().ToTable("Taskovi");
            modelBuilder.Entity<Trening>().ToTable("Treninzi");
            modelBuilder.Entity<Voda>().ToTable("KolicineVode");
        }
    }
}
