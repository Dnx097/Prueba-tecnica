using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sistran.Models;

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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MSI\\\\SQLEXPRESS,1433;Database=PruebaSistran;User=sa;Password=123456;TrustServerCertificate=True;");

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
