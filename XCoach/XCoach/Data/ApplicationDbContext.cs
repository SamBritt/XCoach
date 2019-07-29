using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XCoach.Models;

namespace XCoach.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<AthleteRace> AthleteRaces { get; set; }
        public DbSet<AthleteWorkout> AthleteWorkouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Abc Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<Athlete>().HasData(
                    new Athlete()
                    {
                        Id = 1,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Sam",
                        LastName = "Britt",
                        Gender = "Male",
                        Grade = 12,
                        MPW = 55
                    },
                    new Athlete()
                    {
                        Id = 2,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Alex",
                        LastName = "Carter",
                        Gender = "Male",
                        Grade = 12,
                        MPW = 55
                    },
                    new Athlete()
                    {
                        Id = 3,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Mac",
                        LastName = "McMackerson",
                        Gender = "Male",
                        Grade = 9,
                        MPW = 40
                    },
                    new Athlete()
                    {
                        Id = 4,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Katherine",
                        LastName = "Knowles",
                        Gender = "Female",
                        Grade = 12,
                        MPW = 40
                    },
                    new Athlete()
                    {
                        Id = 5,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Sarah",
                        LastName = "Sararerson",
                        Gender = "Female",
                        Grade = 10,
                        MPW = 35
                    },
                    new Athlete()
                    {
                        Id = 6,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        FirstName = "Jimmy",
                        LastName = "McMillen",
                        Gender = "Male",
                        Grade = 11,
                        MPW = 50
                    }
                );
            builder.Entity<WorkoutType>().HasData(
                    new WorkoutType
                    {
                        Id = 1,
                        Name = "Threshold"
                    },
                    new WorkoutType
                    {
                        Id = 2,
                        Name = "Tempo"
                    },
                    new WorkoutType
                    {
                        Id = 3,
                        Name = "Speed"
                    },
                    new WorkoutType
                    {
                        Id = 4,
                        Name = "Hills"
                    },
                    new WorkoutType
                    {
                        Id = 5,
                        Name = "Long Run"
                    },
                    new WorkoutType
                    {
                        Id = 6,
                        Name = "VO2MAX"
                    }
                );
            builder.Entity<Workout>().HasData(
                    new Workout
                    {
                        Id = 1,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        Title = "Dante's Inferno",
                        Description = "1600m @83% w/ 1600m Recovery, 1200m @88% w/ 1200m Recovery, 800m @92% w/ 800m Recovery, 400m @94% w/ 400m Recovery, 200m All out",
                        WorkoutTypeId = 1
                    },
                    new Workout
                    {
                        Id = 2,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        Title = "Hills @ Graybar",
                        Description = "Gradual pickup with all out effort half way up",
                        WorkoutTypeId = 4
                    }
                );
            builder.Entity<Race>().HasData(
                    new Race
                    {
                        Id = 1,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "Sectionals",
                        EventName = "5k",
                        Location = "Steeplechase",
                        Distance = 5000,
                        EventDate = new DateTime(2018, 10, 22),
                    },
                    new Race
                    {
                        Id = 2,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "Regionals",
                        EventName = "5k",
                        Location = "Steeplechase",
                        Distance = 5000,
                        EventDate = new DateTime(2018, 10, 29),
                    },
                    new Race
                    {
                        Id = 3,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "State",
                        EventName = "5k",
                        Location = "Steeplechase",
                        Distance = 5000,
                        EventDate = new DateTime(2018, 11, 05),
                    },
                    new Race
                    {
                        Id = 4,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "Nationals",
                        EventName = "5k",
                        Location = "Steeplechase",
                        Distance = 5000,
                        EventDate = new DateTime(2018, 11, 19),
                    },
                    new Race
                    {
                        Id = 5,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "Metro City Meet",
                        EventName = "Mile",
                        Location = "Harpeth Hall",
                        Distance = 1600,
                        EventDate = new DateTime(2019, 04, 10),
                    },
                    new Race
                    {
                        Id = 6,
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                        MeetName = "Metro City Meet",
                        EventName = "800",
                        Location = "Harpeth Hall",
                        Distance = 800,
                        EventDate = new DateTime(2020, 04, 10),
                    }
                );
            builder.Entity<AthleteRace>().HasData(
                    new AthleteRace
                    {
                        Id = 1,
                        AthleteId = 1,
                        RaceId = 2,
                        ProjectedTime = new TimeSpan(0, 17, 05),
                        ActualTime = new TimeSpan(0, 16, 50)
                    },
                    new AthleteRace
                    {
                        Id = 2,
                        AthleteId = 5,
                        RaceId = 2,
                        ProjectedTime = new TimeSpan(0, 18, 10),
                        ActualTime = new TimeSpan(0, 17, 40)
                    },
                    new AthleteRace
                    {
                        Id = 3,
                        AthleteId = 1,
                        RaceId = 2,
                        ProjectedTime = new TimeSpan(0, 4, 20),
                    },
                    new AthleteRace
                    {
                        Id = 4,
                        AthleteId = 2,
                        RaceId = 2,
                        ProjectedTime = new TimeSpan(0, 17, 15),
                        ActualTime = new TimeSpan(0, 17, 00)
                    }
                );
            builder.Entity<AthleteWorkout>().HasData(
                    new AthleteWorkout
                    {
                        Id = 1,
                        AthleteId = 1,
                        WorkoutId = 1,
                        Distance = 4200,
                        Pace = new TimeSpan(0, 04, 30),
                        Repetition = 1,
                        WorkoutDate = new DateTime(2019, 07, 31)
                    }
                );
        }
    }
}
