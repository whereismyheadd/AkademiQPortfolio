using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AkademiQPortfolio.Data
{
    public partial class portfolyodbContext : DbContext
    {
        public portfolyodbContext()
        {
        }

        public portfolyodbContext(DbContextOptions<portfolyodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Award> Awards { get; set; } = null!;
        public virtual DbSet<CategoryTable> CategoryTables { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<HomePage> HomePages { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<ProjectsTable> ProjectsTables { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Skilltable> Skilltables { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-STV56C8K\\SQLEXPRESS;Database=portfolyodb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("About");

                entity.Property(e => e.AboutId).HasColumnName("AboutID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AwardsId).HasColumnName("AwardsID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CategoryTable>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("categoryTable");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Adress).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Icon3).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.İcon1).HasMaxLength(100);

                entity.Property(e => e.İcon2).HasMaxLength(100);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.EducationId).HasColumnName("EducationID");

                entity.Property(e => e.EndYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Section).HasMaxLength(100);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");

                entity.Property(e => e.ExperienceId).HasColumnName("ExperienceID");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EndYear)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ExperienceName).HasMaxLength(200);

                entity.Property(e => e.StartYear)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<HomePage>(entity =>
            {
                entity.HasKey(e => e.HomeId)
                    .HasName("PK_Table_1");

                entity.ToTable("HomePage");

                entity.Property(e => e.HomeId).HasColumnName("HomeID");

                entity.Property(e => e.ImagePath).HasMaxLength(200);

                entity.Property(e => e.NameSurname).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Mail).HasMaxLength(200);

                entity.Property(e => e.MessageContent).HasMaxLength(4000);

                entity.Property(e => e.NameSurname).HasMaxLength(100);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(500);
            });

            modelBuilder.Entity<ProjectsTable>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("ProjectsTable");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Images).HasMaxLength(500);

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProjectsTables)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProjectsTable_categoryTable");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ExperiencesId)
                    .HasName("PK_experiences");

                entity.ToTable("services");

                entity.Property(e => e.ExperiencesId).HasColumnName("ExperiencesID");

                entity.Property(e => e.Descriptions).HasMaxLength(400);

                entity.Property(e => e.Title).HasMaxLength(50);

                
            });

            modelBuilder.Entity<Skilltable>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.ToTable("skilltable");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.SkillValue).HasDefaultValueSql("((50))");

                entity.Property(e => e.Test).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialName);

                entity.ToTable("Testimonial");

                entity.Property(e => e.TestimonialName).HasColumnName("TestimonialName,");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.TestimonialId)
                    .HasMaxLength(10)
                    .HasColumnName("TestimonialID")
                    .IsFixedLength();

                entity.Property(e => e.TestimonialName1)
                    .HasMaxLength(100)
                    .HasColumnName("TestimonialName");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
