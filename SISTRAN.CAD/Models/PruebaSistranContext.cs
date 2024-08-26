using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTRAN.CAD.Models;

public partial class PruebaSistranContext : DbContext
{
    public PruebaSistranContext()
    {
    }

    public PruebaSistranContext(DbContextOptions<PruebaSistranContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=PruebaSistran;User=sa;Password=123456;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__2EC8D2AC25813E2F");

            entity.ToTable("Persona");

            entity.Property(e => e.Apellidos).HasMaxLength(90);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.CorreoAlt).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.DireccionAlt).HasMaxLength(150);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(90);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
