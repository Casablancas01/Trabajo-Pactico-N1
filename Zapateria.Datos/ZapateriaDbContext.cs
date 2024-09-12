using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using Zapateria.Entidades;

namespace Zapateria.Datos
{
    public class ZapateriaDbContext : DbContext
    {
        public ZapateriaDbContext()
        {
        }

        public ZapateriaDbContext(DbContextOptions<ZapateriaDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Shoe> Shoes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer(@"Data Source=ENTADEV\SQLEXPRESS; 
        //        Initial Catalog=ZapateriaEF2024;
        //        Trusted_Connection=true; 
        //        TrustServerCertificate=true;"); //considerar cambiar la cadena de conexión

        //<!--<add name="CapsaOyGContext" connectionString="Data Source=ENTADEV\SQLEXPRESS;Initial Catalog=CapsaOyG_DA_PROD;
        //Integrated Security=SSPI;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />-->

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasIndex(e => e.BrandName, "IX_Brand").IsUnique();

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Shoes)
                    .WithOne(p => p.Brand)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Brands");
            });

            // Configuración de Color
            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Colors");
                entity.HasIndex(e => e.ColorName, "IX_Color").IsUnique();

                entity.Property(e => e.ColorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Shoes)
                    .WithOne(p => p.Color)
                    .HasForeignKey(p => p.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Colors");
            });

            // Configuración de Sport
            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports");
                entity.HasIndex(e => e.SportName, "IX_Sport").IsUnique();

                entity.Property(e => e.SportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Shoes)
                    .WithOne(p => p.Sport)
                    .HasForeignKey(p => p.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Sports");
            });

            // Configuración de Genre
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");
                entity.HasIndex(e => e.GenreName, "IX_Genre").IsUnique();

                entity.Property(e => e.GenreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Shoes)
                    .WithOne(p => p.Genre)
                    .HasForeignKey(p => p.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Genres");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}