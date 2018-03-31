using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MediMatchRMIT.Data.Migrations
{
    public partial class MedicalProfessionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "DecimalDegrees",
                columns: table => new
                {
                    Latitude = table.Column<decimal>(nullable: false),
                    Longtitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecimalDegrees", x => x.Latitude);
                });

            migrationBuilder.CreateTable(
                name: "HoursActive",
                columns: table => new
                {
                    ActiveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hours = table.Column<string>(nullable: true),
                    WeekDays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursActive", x => x.ActiveId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoordinatesLatitude = table.Column<decimal>(nullable: true),
                    PostCode = table.Column<int>(nullable: false),
                    Street = table.Column<int>(nullable: false),
                    StreetNo = table.Column<int>(nullable: false),
                    Suburb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_DecimalDegrees_CoordinatesLatitude",
                        column: x => x.CoordinatesLatitude,
                        principalTable: "DecimalDegrees",
                        principalColumn: "Latitude",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProfessional",
                columns: table => new
                {
                    MedicalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    FeedbackReviewId = table.Column<int>(nullable: true),
                    FirstMidName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LocationAddressId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ServiceActiveActiveId = table.Column<int>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProfessional", x => x.MedicalId);
                    table.ForeignKey(
                        name: "FK_MedicalProfessional_Reviews_FeedbackReviewId",
                        column: x => x.FeedbackReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalProfessional_Address_LocationAddressId",
                        column: x => x.LocationAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalProfessional_HoursActive_ServiceActiveActiveId",
                        column: x => x.ServiceActiveActiveId,
                        principalTable: "HoursActive",
                        principalColumn: "ActiveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalProfessionalMedicalId = table.Column<int>(nullable: true),
                    Support = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Facility_MedicalProfessional_MedicalProfessionalMedicalId",
                        column: x => x.MedicalProfessionalMedicalId,
                        principalTable: "MedicalProfessional",
                        principalColumn: "MedicalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalProfessionalMedicalId = table.Column<int>(nullable: true),
                    ServiceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_MedicalProfessional_MedicalProfessionalMedicalId",
                        column: x => x.MedicalProfessionalMedicalId,
                        principalTable: "MedicalProfessional",
                        principalColumn: "MedicalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CoordinatesLatitude",
                table: "Address",
                column: "CoordinatesLatitude");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_MedicalProfessionalMedicalId",
                table: "Facility",
                column: "MedicalProfessionalMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProfessional_FeedbackReviewId",
                table: "MedicalProfessional",
                column: "FeedbackReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProfessional_LocationAddressId",
                table: "MedicalProfessional",
                column: "LocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProfessional_ServiceActiveActiveId",
                table: "MedicalProfessional",
                column: "ServiceActiveActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MedicalProfessionalMedicalId",
                table: "Service",
                column: "MedicalProfessionalMedicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "MedicalProfessional");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "HoursActive");

            migrationBuilder.DropTable(
                name: "DecimalDegrees");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
