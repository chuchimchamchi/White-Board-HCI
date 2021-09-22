using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteBoard_BE.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    PhoneNumber = table.Column<decimal>(type: "decimal(11,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDay = table.Column<DateTime>(type: "date", nullable: false),
                    EndDay = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CriteriaGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriaGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "decimal(11,0)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Criteria_CriteriaGroup",
                        column: x => x.GroupID,
                        principalTable: "CriteriaGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PhoneNumber = table.Column<decimal>(type: "decimal(11,0)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UniversityID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Campus_University",
                        column: x => x.UniversityID,
                        principalTable: "University",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCriteria",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriteriaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCriteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CampaignHasCriteria_Campaign",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignHasCriteria_Criteria",
                        column: x => x.CriteriaID,
                        principalTable: "Criteria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampusMajor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MajorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusMajor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CampusMajor_Campus",
                        column: x => x.CampusID,
                        principalTable: "Campus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampusMajor_Major",
                        column: x => x.MajorID,
                        principalTable: "Major",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignOn",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampusMajorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignOn", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CampaignOn_Campaign",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignOn_CampusMajor",
                        column: x => x.CampusMajorID,
                        principalTable: "CampusMajor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviewer",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<decimal>(type: "decimal(11,0)", nullable: true),
                    BelongTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Certification = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_CampusMajor",
                        column: x => x.BelongTo,
                        principalTable: "CampusMajor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Campaign = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Campaign",
                        column: x => x.Campaign,
                        principalTable: "Campaign",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.CreatedBy,
                        principalTable: "Reviewer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureForReview",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Review = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Picture = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureForReview", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PictureForReview_Review",
                        column: x => x.Review,
                        principalTable: "Review",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewCriteria",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Review = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignCriteriaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewCriteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReviewAboutCriteria_Review",
                        column: x => x.Review,
                        principalTable: "Review",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewCriteria_CampaignCriteria",
                        column: x => x.CampaignCriteriaID,
                        principalTable: "CampaignCriteria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCriteria_CampaignID",
                table: "CampaignCriteria",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCriteria_CriteriaID",
                table: "CampaignCriteria",
                column: "CriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignOn_CampaignID",
                table: "CampaignOn",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignOn_CampusMajorID",
                table: "CampaignOn",
                column: "CampusMajorID");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_UniversityID",
                table: "Campus",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_CampusMajor_CampusID",
                table: "CampusMajor",
                column: "CampusID");

            migrationBuilder.CreateIndex(
                name: "IX_CampusMajor_MajorID",
                table: "CampusMajor",
                column: "MajorID");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_GroupID",
                table: "Criteria",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureForReview_Review",
                table: "PictureForReview",
                column: "Review");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Campaign",
                table: "Review",
                column: "Campaign");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CreatedBy",
                table: "Review",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewCriteria_CampaignCriteriaID",
                table: "ReviewCriteria",
                column: "CampaignCriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewCriteria_Review",
                table: "ReviewCriteria",
                column: "Review");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewer_BelongTo",
                table: "Reviewer",
                column: "BelongTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CampaignOn");

            migrationBuilder.DropTable(
                name: "PictureForReview");

            migrationBuilder.DropTable(
                name: "ReviewCriteria");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "CampaignCriteria");

            migrationBuilder.DropTable(
                name: "Reviewer");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "CampusMajor");

            migrationBuilder.DropTable(
                name: "CriteriaGroup");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
