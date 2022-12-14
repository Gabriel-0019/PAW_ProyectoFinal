using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class rabdContext : DbContext
    {
        public rabdContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<rabdContext>();
            optionsBuilder.UseSqlServer(Util.ConnectionString);

        }

        public rabdContext(DbContextOptions<rabdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquilers { get; set; } = null!;
        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<CategoriaAuto> CategoriaAutos { get; set; } = null!;
        public virtual DbSet<DBErrores> Dberrores { get; set; } = null!;
        public virtual DbSet<Devolucion> Devolucions { get; set; } = null!;
        public virtual DbSet<Envio> Envios { get; set; } = null!;
        public virtual DbSet<Facturacion> Facturacions { get; set; } = null!;
        public virtual DbSet<Observaciones> Observaciones { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<MisFacturas_Result> MisFacturas_Results { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.IdAlquiler);

                entity.ToTable("Alquiler");

                entity.Property(e => e.FechaAlquiler).HasColumnType("datetime");

                entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.IdAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alquiler_Autos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alquiler_Usuario");
            });

            modelBuilder.Entity<Auto>(entity =>
            {
                entity.HasKey(e => e.IdAuto);

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.InsertadoPor).HasMaxLength(50);

                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Modelo).HasMaxLength(50);

                entity.Property(e => e.ModificadorPor).HasMaxLength(50);

                entity.Property(e => e.Placa).HasMaxLength(50);

                entity.Property(e => e.PrecioDia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Transmision).HasMaxLength(50);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Autos_CategoriaAuto");
            });

            modelBuilder.Entity<CategoriaAuto>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("CategoriaAuto");

                entity.Property(e => e.NombreCategoria).HasMaxLength(50);
            });

            modelBuilder.Entity<DBErrores>(entity =>
            {
                entity.HasKey(e => e.IdError)
                    .HasName("DBErrores_ErrorID");

                entity.ToTable("DBErrores");

                entity.Property(e => e.ErrorDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dberrores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("DBErrores_IdUsuario");
            });

            modelBuilder.Entity<Devolucion>(entity =>
            {
                entity.HasKey(e => new { e.IdFactura, e.IdObservacion })
                    .HasName("PK__Devoluci__2C15CDD914FD8090");

                entity.ToTable("Devolucion");

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Devolucions)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__IdFac__4316F928");

                entity.HasOne(d => d.IdObservacionNavigation)
                    .WithMany(p => p.Devolucions)
                    .HasForeignKey(d => d.IdObservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Devolucio__IdObs__440B1D61");
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);

                entity.ToTable("Envio");

                entity.Property(e => e.DetalleDireccion).HasMaxLength(500);

                entity.Property(e => e.FechaEnvio).HasColumnType("date");

                entity.Property(e => e.PrecioBase).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.IdConductor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Envio_Usuario1");
            });

            modelBuilder.Entity<Facturacion>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Facturacion");

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.FechaUltActu).HasColumnType("datetime");

                entity.Property(e => e.MontoAlquiler).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MontoMulta).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PrimerPago).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SegundoPago).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlquilerNavigation)
                    .WithMany(p => p.Facturacions)
                    .HasForeignKey(d => d.IdAlquiler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facturacion_Alquiler");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.Facturacions)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facturacion_Envio");
            });

            modelBuilder.Entity<Observaciones>(entity =>
            {
                entity.HasKey(e => e.IdObservacion)
                    .HasName("PK__Observac__7793AD0B6FC35970");

                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.Property(e => e.NombreRol).HasMaxLength(30);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido).HasMaxLength(70);

                entity.Property(e => e.Cedula).HasMaxLength(20);

                entity.Property(e => e.Contrasena).HasMaxLength(15);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Cvv).HasColumnName("CVV");

                entity.Property(e => e.FechaExpiracion).HasColumnType("date");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NombreTitular).HasMaxLength(50);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_IdRol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
