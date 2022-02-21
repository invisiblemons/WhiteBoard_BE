using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Whiteboard.Data.Entities;

#nullable disable

namespace Whiteboard.Data.Context
{
    public partial class WhiteboardContext : DbContext
    {
        public WhiteboardContext()
        {
        }

        public WhiteboardContext(DbContextOptions<WhiteboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Criterion> Criterions { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<PictureForReview> PictureForReviews { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewCriterion> ReviewCriteria { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=WhiteBoardDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FireBaseUId)
                    .IsRequired()
                    .HasColumnName("FireBaseUId");

            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.HasIndex(e => e.CampusId, "IX_Campaign_CampusId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDay).HasColumnType("date");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.CampusId);
            });

            modelBuilder.Entity<Campus>(entity =>
            {
                entity.ToTable("Campus");

                entity.HasIndex(e => e.UniversityId, "IX_Campus_UniversityID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();


                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Campuses)
                    .HasForeignKey(d => d.UniversityId);
            });

            modelBuilder.Entity<Criterion>(entity =>
            {
                entity.HasIndex(e => e.CampaignId, "IX_Criterions_CampaignId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Criteria)
                    .HasForeignKey(d => d.CampaignId);
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.HasIndex(e => e.CampusId, "IX_Major_CampusId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.Majors)
                    .HasForeignKey(d => d.CampusId);
            });

            modelBuilder.Entity<PictureForReview>(entity =>
            {
                entity.ToTable("PictureForReview");

                entity.HasIndex(e => e.ReviewId, "IX_PictureForReview_ReviewId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Picture).IsRequired();

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.PictureForReviews)
                    .HasForeignKey(d => d.ReviewId);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.HasIndex(e => e.CampaignId, "IX_Review_CampaignId");

                entity.HasIndex(e => e.ReviewerId, "IX_Review_ReviewerId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.OnDateTime).HasColumnType("datetime");

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CampaignId);

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReviewerId);
            });

            modelBuilder.Entity<ReviewCriterion>(entity =>
            {
                entity.HasIndex(e => e.CriterionId, "IX_ReviewCriteria_CriterionId");

                entity.HasIndex(e => e.ReviewId, "IX_ReviewCriteria_ReviewId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Criterion)
                    .WithMany(p => p.ReviewCriteria)
                    .HasForeignKey(d => d.CriterionId);

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewCriteria)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.ToTable("Reviewer");

                entity.HasIndex(e => e.MajorId, "IX_Reviewer_MajorId");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Certification).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FireBaseUId)
                    .IsRequired()
                    .HasColumnName("FireBaseUId");

                entity.Property(e => e.Status).IsRequired();

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Reviewers)
                    .HasForeignKey(d => d.MajorId);
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
