using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Whiteboard.Data.Migrations
{
    public partial class _01051121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Campaign_CampaignId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Review_ReviewId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CampaignId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReviewId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Notifications");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AboutCampaignID",
                table: "Notifications",
                column: "AboutCampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AboutReviewID",
                table: "Notifications",
                column: "AboutReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TopicReviewerID",
                table: "Notifications",
                column: "TopicReviewerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Campaign_AboutCampaignID",
                table: "Notifications",
                column: "AboutCampaignID",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Review_AboutReviewID",
                table: "Notifications",
                column: "AboutReviewID",
                principalTable: "Review",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Reviewer_TopicReviewerID",
                table: "Notifications",
                column: "TopicReviewerID",
                principalTable: "Reviewer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Campaign_AboutCampaignID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Review_AboutReviewID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Reviewer_TopicReviewerID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AboutCampaignID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AboutReviewID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TopicReviewerID",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CampaignId",
                table: "Notifications",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReviewId",
                table: "Notifications",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Campaign_CampaignId",
                table: "Notifications",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Review_ReviewId",
                table: "Notifications",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
