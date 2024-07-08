using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Models;

public partial class ToDoWebApiContext : DbContext
{
    public ToDoWebApiContext()
    {
    }

    public ToDoWebApiContext(DbContextOptions<ToDoWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ToDoBaza");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.ToTable("ToDoList");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
