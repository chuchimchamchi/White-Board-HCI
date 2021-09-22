using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WhiteBoard_BE.Models.Entities;

#nullable disable

namespace WhiteBoard_BE.Helpers
{
    public partial class WhiteBoardDBContext : DbContext
    {
        public WhiteBoardDBContext()
        {
        }

        public WhiteBoardDBContext(DbContextOptions<WhiteBoardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignCriterion> CampaignCriteria { get; set; }
        public virtual DbSet<CampaignOn> CampaignOns { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<CampusMajor> CampusMajors { get; set; }
        public virtual DbSet<CriteriaGroup> CriteriaGroups { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<PictureForReview> PictureForReviews { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewCriterion> ReviewCriteria { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=WhiteBoardDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Avatar).IsUnicode(false);
            });

            modelBuilder.Entity<CampaignCriterion>(entity =>
            {
                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignCriteria)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignHasCriteria_Campaign");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.CampaignCriteria)
                    .HasForeignKey(d => d.CriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignHasCriteria_Criteria");
            });

            modelBuilder.Entity<CampaignOn>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignOns)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignOn_Campaign");

                entity.HasOne(d => d.CampusMajor)
                    .WithMany(p => p.CampaignOns)
                    .HasForeignKey(d => d.CampusMajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignOn_CampusMajor");
            });

            modelBuilder.Entity<Campus>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Campuses)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Campus_University");
            });

            modelBuilder.Entity<CampusMajor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Campus)
                    .WithMany(p => p.CampusMajors)
                    .HasForeignKey(d => d.CampusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampusMajor_Campus");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.CampusMajors)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampusMajor_Major");
            });

            modelBuilder.Entity<Criterion>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Criteria)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Criteria_CriteriaGroup");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.Code).IsUnicode(false);
            });

            modelBuilder.Entity<PictureForReview>(entity =>
            {
                entity.Property(e => e.Picture).IsUnicode(false);

                entity.HasOne(d => d.ReviewNavigation)
                    .WithMany(p => p.PictureForReviews)
                    .HasForeignKey(d => d.Review)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PictureForReview_Review");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.CampaignNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Campaign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Campaign");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<ReviewCriterion>(entity =>
            {
                entity.HasOne(d => d.CampaignCriteria)
                    .WithMany(p => p.ReviewCriteria)
                    .HasForeignKey(d => d.CampaignCriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewCriteria_CampaignCriteria");

                entity.HasOne(d => d.ReviewNavigation)
                    .WithMany(p => p.ReviewCriteria)
                    .HasForeignKey(d => d.Review)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewAboutCriteria_Review");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Certification).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.Reviewers)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK_User_CampusMajor");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
