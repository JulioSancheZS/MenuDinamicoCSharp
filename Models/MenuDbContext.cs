using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MenuDinamicoAPI.Models;

public partial class MenuDbContext : DbContext
{
    public MenuDbContext()
    {
    }

    public MenuDbContext(DbContextOptions<MenuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemMenu> ItemMenus { get; set; }

    public virtual DbSet<ItemRol> ItemRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemMenu>(entity =>
        {
            entity.HasKey(e => e.IdItemMenu).HasName("PK__ItemMenu__ADB04716FA8A2FC0");

            entity.ToTable("ItemMenu");

            entity.Property(e => e.EsActivo).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ruta).HasMaxLength(256);
            entity.Property(e => e.Texto).HasMaxLength(50);
            entity.Property(e => e.Visible).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdItemMenuPadreNavigation).WithMany(p => p.InverseIdItemMenuPadreNavigation)
                .HasForeignKey(d => d.IdItemMenuPadre)
                .HasConstraintName("FK_ItemMenu_ItemMenu");
        });

        modelBuilder.Entity<ItemRol>(entity =>
        {
            entity.HasKey(e => e.IdItemRol).HasName("PK__ItemRol__060FEDF9C5CA6E61");

            entity.ToTable("ItemRol");

            entity.HasOne(d => d.IdItemMenuNavigation).WithMany(p => p.ItemRols)
                .HasForeignKey(d => d.IdItemMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemRol_ItemMenu");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.ItemRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemRol_Rol");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CFF6EB5D5");

            entity.ToTable("Rol");

            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97B7DA2DF7");

            entity.ToTable("Usuario");

            entity.Property(e => e.Correo).HasMaxLength(400);
            entity.Property(e => e.EsActivo).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pass).HasMaxLength(200);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(200)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
