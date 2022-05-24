using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiBaseDatos.Models
{
    public partial class Prog31105Context : DbContext
    {
        public Prog31105Context()
        {
        }

        public Prog31105Context(DbContextOptions<Prog31105Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deportes { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<TipoDeporte> TipoDeportes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("server=localhost; Database=Prog3-11-05;Port=5432;User id=ClaseProg3;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.HasIndex(e => e.IDtipoDeporte, "fki_fk_tipoDeporte");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IDtipoDeporte).HasColumnName("iDTipoDeporte");

                entity.HasOne(d => d.IDtipoDeporteNavigation)
                    .WithMany(p => p.Deportes)
                    .HasForeignKey(d => d.IDtipoDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoDeporte");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("personas");

                entity.HasIndex(e => e.IDsexo, "fki_fk_sexo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IDsexo).HasColumnName("iDSexo");

                entity.HasOne(d => d.IDsexoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IDsexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sexo");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("iD");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("Sexo");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoDeporte>(entity =>
            {
                entity.ToTable("tipoDeporte");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IDroll, "fki_fk_rol");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IDroll).HasColumnName("iDRoll");

                entity.HasOne(d => d.IDrollNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IDroll)
                    .HasConstraintName("fk_rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
