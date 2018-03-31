﻿// <auto-generated />
using MediMatchRMIT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MediMatchRMIT.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediMatchRMIT.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("CoordinatesLatitude");

                    b.Property<int>("PostCode");

                    b.Property<int>("Street");

                    b.Property<int>("StreetNo");

                    b.Property<string>("Suburb");

                    b.HasKey("AddressId");

                    b.HasIndex("CoordinatesLatitude");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.DecimalDegrees", b =>
                {
                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longtitude");

                    b.HasKey("Latitude");

                    b.ToTable("DecimalDegrees");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Facility", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MedicalProfessionalMedicalId");

                    b.Property<string>("Support");

                    b.HasKey("ServiceId");

                    b.HasIndex("MedicalProfessionalMedicalId");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.HoursActive", b =>
                {
                    b.Property<int>("ActiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hours");

                    b.Property<string>("WeekDays");

                    b.HasKey("ActiveId");

                    b.ToTable("HoursActive");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.MedicalProfessional", b =>
                {
                    b.Property<int>("MedicalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FacilityName");

                    b.Property<int?>("FeedbackReviewId");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.Property<int?>("LocationAddressId");

                    b.Property<string>("Notes");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("ServiceActiveActiveId");

                    b.Property<string>("Website");

                    b.HasKey("MedicalId");

                    b.HasIndex("FeedbackReviewId");

                    b.HasIndex("LocationAddressId");

                    b.HasIndex("ServiceActiveActiveId");

                    b.ToTable("MedicalProfessional");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Reviews", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MedicalProfessionalMedicalId");

                    b.Property<string>("ServiceType");

                    b.HasKey("ServiceId");

                    b.HasIndex("MedicalProfessionalMedicalId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Address", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.DecimalDegrees", "Coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinatesLatitude");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Facility", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.MedicalProfessional")
                        .WithMany("Facilities")
                        .HasForeignKey("MedicalProfessionalMedicalId");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.MedicalProfessional", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.Reviews", "Feedback")
                        .WithMany()
                        .HasForeignKey("FeedbackReviewId");

                    b.HasOne("MediMatchRMIT.Models.Address", "Location")
                        .WithMany()
                        .HasForeignKey("LocationAddressId");

                    b.HasOne("MediMatchRMIT.Models.HoursActive", "ServiceActive")
                        .WithMany()
                        .HasForeignKey("ServiceActiveActiveId");
                });

            modelBuilder.Entity("MediMatchRMIT.Models.Service", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.MedicalProfessional")
                        .WithMany("Services")
                        .HasForeignKey("MedicalProfessionalMedicalId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MediMatchRMIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MediMatchRMIT.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
