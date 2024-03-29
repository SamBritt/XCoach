﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XCoach.Data;

namespace XCoach.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

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

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("XCoach.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

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

                    b.Property<string>("StreetAddress");

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

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "79cf7d0f-e3f1-4aaf-9161-7ece7de80447",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEB6xMJy0Oi9AjpceUr7HD7xL8R6y2pqKLFl3Uc9YgEoEHToH9nYThWHFS60wYP13Lg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            StreetAddress = "123 Abc Way",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("XCoach.Models.Athlete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<int>("Grade");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("MPW");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Athletes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Sam",
                            Gender = "Male",
                            Grade = 12,
                            LastName = "Britt",
                            MPW = 55,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Alex",
                            Gender = "Male",
                            Grade = 12,
                            LastName = "Carter",
                            MPW = 55,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Mac",
                            Gender = "Male",
                            Grade = 9,
                            LastName = "McMackerson",
                            MPW = 40,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Katherine",
                            Gender = "Female",
                            Grade = 12,
                            LastName = "Knowles",
                            MPW = 40,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Sarah",
                            Gender = "Female",
                            Grade = 10,
                            LastName = "Sararerson",
                            MPW = 35,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Jimmy",
                            Gender = "Male",
                            Grade = 11,
                            LastName = "McMillen",
                            MPW = 50,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        });
                });

            modelBuilder.Entity("XCoach.Models.AthleteRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan?>("ActualTime");

                    b.Property<int>("AthleteId");

                    b.Property<TimeSpan>("ProjectedTime");

                    b.Property<int>("RaceId");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("RaceId");

                    b.ToTable("AthleteRaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActualTime = new TimeSpan(0, 0, 16, 50, 0),
                            AthleteId = 1,
                            ProjectedTime = new TimeSpan(0, 0, 17, 5, 0),
                            RaceId = 2
                        },
                        new
                        {
                            Id = 2,
                            ActualTime = new TimeSpan(0, 0, 17, 40, 0),
                            AthleteId = 5,
                            ProjectedTime = new TimeSpan(0, 0, 18, 10, 0),
                            RaceId = 2
                        },
                        new
                        {
                            Id = 3,
                            AthleteId = 1,
                            ProjectedTime = new TimeSpan(0, 0, 4, 20, 0),
                            RaceId = 2
                        },
                        new
                        {
                            Id = 4,
                            ActualTime = new TimeSpan(0, 0, 17, 0, 0),
                            AthleteId = 2,
                            ProjectedTime = new TimeSpan(0, 0, 17, 15, 0),
                            RaceId = 2
                        });
                });

            modelBuilder.Entity("XCoach.Models.AthleteWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AthleteId");

                    b.Property<int>("Distance");

                    b.Property<TimeSpan>("Pace");

                    b.Property<int>("Repetition");

                    b.Property<DateTime>("WorkoutDate");

                    b.Property<int>("WorkoutId");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("AthleteWorkouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AthleteId = 1,
                            Distance = 4200,
                            Pace = new TimeSpan(0, 0, 4, 30, 0),
                            Repetition = 1,
                            WorkoutDate = new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkoutId = 1
                        });
                });

            modelBuilder.Entity("XCoach.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distance");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("MeetName")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Distance = 5000,
                            EventDate = new DateTime(2018, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "5k",
                            Location = "Steeplechase",
                            MeetName = "Sectionals",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 2,
                            Distance = 5000,
                            EventDate = new DateTime(2018, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "5k",
                            Location = "Steeplechase",
                            MeetName = "Regionals",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 3,
                            Distance = 5000,
                            EventDate = new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "5k",
                            Location = "Steeplechase",
                            MeetName = "State",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 4,
                            Distance = 5000,
                            EventDate = new DateTime(2018, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "5k",
                            Location = "Steeplechase",
                            MeetName = "Nationals",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 5,
                            Distance = 1600,
                            EventDate = new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Mile",
                            Location = "Harpeth Hall",
                            MeetName = "Metro City Meet",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            Id = 6,
                            Distance = 800,
                            EventDate = new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "800",
                            Location = "Harpeth Hall",
                            MeetName = "Metro City Meet",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        });
                });

            modelBuilder.Entity("XCoach.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("WorkoutTypeId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutTypeId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "1600m @83% w/ 1600m Recovery, 1200m @88% w/ 1200m Recovery, 800m @92% w/ 800m Recovery, 400m @94% w/ 400m Recovery, 200m All out",
                            Title = "Dante's Inferno",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            WorkoutTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Gradual pickup with all out effort half way up",
                            Title = "Hills @ Graybar",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            WorkoutTypeId = 4
                        });
                });

            modelBuilder.Entity("XCoach.Models.WorkoutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("WorkoutTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Threshold"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tempo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Speed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hills"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Long Run"
                        },
                        new
                        {
                            Id = 6,
                            Name = "VO2MAX"
                        });
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
                    b.HasOne("XCoach.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("XCoach.Models.ApplicationUser")
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

                    b.HasOne("XCoach.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("XCoach.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCoach.Models.Athlete", b =>
                {
                    b.HasOne("XCoach.Models.ApplicationUser", "User")
                        .WithMany("Athletes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCoach.Models.AthleteRace", b =>
                {
                    b.HasOne("XCoach.Models.Athlete", "Athlete")
                        .WithMany("AthleteRaces")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("XCoach.Models.Race", "Race")
                        .WithMany("AthleteRaces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("XCoach.Models.AthleteWorkout", b =>
                {
                    b.HasOne("XCoach.Models.Athlete", "Athlete")
                        .WithMany("AthleteWorkouts")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("XCoach.Models.Workout", "Workout")
                        .WithMany("AthleteWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("XCoach.Models.Race", b =>
                {
                    b.HasOne("XCoach.Models.ApplicationUser", "User")
                        .WithMany("Races")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XCoach.Models.Workout", b =>
                {
                    b.HasOne("XCoach.Models.ApplicationUser", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("XCoach.Models.WorkoutType", "WorkoutType")
                        .WithMany()
                        .HasForeignKey("WorkoutTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
