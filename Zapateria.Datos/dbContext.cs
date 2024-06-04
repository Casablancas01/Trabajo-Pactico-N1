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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer(@"Data Source=CASABLANCAS; 
                Initial Catalog=ZapateriaEF2024;
                Trusted_Connection=true; 
                TrustServerCertificate=true;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasIndex(e => e.BrandName, "IX_Brand").IsUnique();

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shoes).WithMany(p => p.Brand)
                    .HasForeignKey(d => d.TipoDePlantaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plantas_TiposDePlantas");
            });

            modelBuilder.Entity<TipoDePlanta>(entity =>
            {
                entity.ToTable("TiposDePlantas");
                entity.HasKey(e => e.TipoDePlantaId);

                entity.HasIndex(e => e.Descripcion, "IX_TiposDePlantas").IsUnique();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);

        }
    }
    
}
