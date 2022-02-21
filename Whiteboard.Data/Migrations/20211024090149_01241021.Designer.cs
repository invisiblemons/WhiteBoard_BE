﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Whiteboard.Data.Context;

namespace Whiteboard.Data.Migrations
{
    [DbContext(typeof(WhiteboardContext))]
    [Migration("20211024090149_01241021")]
    partial class _01241021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Whiteboard.Data.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FireBaseUId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FireBaseUId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PhoneNumber")
                        .HasColumnType("decimal(11,0)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("date");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishedReviews")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerJoined")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnpublishedReviews")
                        .HasColumnType("int");

                    b.Property<int>("WaitingReviews")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CampusId" }, "IX_Campaign_CampusId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PhoneNumber")
                        .HasColumnType("decimal(11,0)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UniversityID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UniversityId" }, "IX_Campus_UniversityID");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Criterion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ratings")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CampaignId" }, "IX_Criterions_CampaignId");

                    b.ToTable("Criterions");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Major", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CampusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CampusId" }, "IX_Major_CampusId");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AboutCampaignID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AboutReviewID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OnDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TopicCampusID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TopicReviewerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.PictureForReview", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ReviewId" }, "IX_PictureForReview_ReviewId");

                    b.ToTable("PictureForReview");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OnDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhyNotPublic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CampaignId" }, "IX_Review_CampaignId");

                    b.HasIndex(new[] { "ReviewerId" }, "IX_Review_ReviewerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.ReviewCriterion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CriterionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CriterionId" }, "IX_ReviewCriteria_CriterionId");

                    b.HasIndex(new[] { "ReviewId" }, "IX_ReviewCriteria_ReviewId");

                    b.ToTable("ReviewCriteria");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Reviewer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Avatar")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Certification")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FireBaseUId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FireBaseUId");

                    b.Property<Guid?>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PhoneNumber")
                        .HasColumnType("decimal(11,0)");

                    b.Property<int>("PublishedReviews")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnpublishedReviews")
                        .HasColumnType("int");

                    b.Property<int>("WaitingReviews")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MajorId" }, "IX_Reviewer_MajorId");

                    b.ToTable("Reviewer");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.University", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PhoneNumber")
                        .HasColumnType("decimal(11,0)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("University");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campaign", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Campus", "Campus")
                        .WithMany("Campaigns")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campus", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.University", "University")
                        .WithMany("Campuses")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Criterion", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Campaign", "Campaign")
                        .WithMany("Criteria")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Major", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Campus", "Campus")
                        .WithMany("Majors")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Notification", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.HasOne("Whiteboard.Data.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.Navigation("Campaign");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.PictureForReview", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Review", "Review")
                        .WithMany("PictureForReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Review", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Campaign", "Campaign")
                        .WithMany("Reviews")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whiteboard.Data.Entities.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.ReviewCriterion", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Criterion", "Criterion")
                        .WithMany("ReviewCriteria")
                        .HasForeignKey("CriterionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Whiteboard.Data.Entities.Review", "Review")
                        .WithMany("ReviewCriteria")
                        .HasForeignKey("ReviewId")
                        .IsRequired();

                    b.Navigation("Criterion");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Reviewer", b =>
                {
                    b.HasOne("Whiteboard.Data.Entities.Major", "Major")
                        .WithMany("Reviewers")
                        .HasForeignKey("MajorId");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campaign", b =>
                {
                    b.Navigation("Criteria");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Campus", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Majors");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Criterion", b =>
                {
                    b.Navigation("ReviewCriteria");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Major", b =>
                {
                    b.Navigation("Reviewers");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Review", b =>
                {
                    b.Navigation("PictureForReviews");

                    b.Navigation("ReviewCriteria");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Whiteboard.Data.Entities.University", b =>
                {
                    b.Navigation("Campuses");
                });
#pragma warning restore 612, 618
        }
    }
}
