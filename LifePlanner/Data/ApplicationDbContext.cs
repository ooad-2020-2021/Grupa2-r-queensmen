using LifePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifePlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext<RegistrovaniKorisnik, IdentityRole, string>
    {
        private readonly DbContextOptions _options;


        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            _options = options;
        }

        public DbSet<Jelo> Jela { get; set; }

        public DbSet<NeregistrovaniKorisnik> NeregistrovaniKorisnici { get; set; }

        public DbSet<Raspolozenje> Raspolozenja { get; set; }

        //public DbSet<RegistrovaniKorisnik> RegistrovaniKorisnici { get; set; }

        public DbSet<Zadatak> Zadaci { get; set; }

        public DbSet<Trening> Treninzi { get; set; }

        public DbSet<Voda> KolicineVode { get; set; }

        public override DbSet<RegistrovaniKorisnik> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var splitStringConverter = new ValueConverter<IList<String>, String>(v => String.Join("@", v), v => v.Split(new[] { '@' }));
            modelBuilder.Entity<Trening>().Property(nameof(Trening.Vjezbe)).HasConversion(splitStringConverter);
            modelBuilder.Entity<Jelo>().Property(nameof(Jelo.Sastojci)).HasConversion(splitStringConverter);

            modelBuilder.Entity<Voda>().Property(nameof(Voda.Kolicina)).HasColumnType("decimal(7,2)");


            modelBuilder.Entity<Jelo>().ToTable("Jela");
            modelBuilder.Entity<NeregistrovaniKorisnik>().ToTable("NeregistrovaniKorisnici");
            modelBuilder.Entity<Raspolozenje>().ToTable("Raspolozenja");
            modelBuilder.Entity<Zadatak>().ToTable("Zadaci");
            modelBuilder.Entity<Trening>().ToTable("Treninzi");
            modelBuilder.Entity<Voda>().ToTable("KolicineVode");
            modelBuilder.Entity<RegistrovaniKorisnik>().ToTable("RegistrovaniKorisnici");
        }
    }
}
