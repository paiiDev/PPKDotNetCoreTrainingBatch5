using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainingBatch5.database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=.; Initial Catalog=DotNetTrainingBatch5; User ID=sa; Password=sasa@123; TrustServerCertificate = true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_blog");

            entity.Property(e => e.BlogId).HasColumnName("blogId");
            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .HasColumnName("blogAuthor");
            entity.Property(e => e.BlogContent).HasColumnName("blogContent");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .HasColumnName("blogTitle");
            entity.Property(e => e.DeleteFlag).HasColumnName("deleteFlag");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
