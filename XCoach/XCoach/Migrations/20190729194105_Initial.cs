using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XCoach.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    MPW = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    MeetName = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    EventName = table.Column<string>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    WorkoutTypeId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthleteRaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AthleteId = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: false),
                    ProjectedTime = table.Column<TimeSpan>(nullable: false),
                    ActualTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteRaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AthleteRaces_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteRaces_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AthleteId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Pace = table.Column<TimeSpan>(nullable: false),
                    Repetition = table.Column<int>(nullable: false),
                    WorkoutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AthleteWorkouts_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "f875b5e4-85d5-46c9-baea-1f04d5af72bb", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMAx0bIcB0yA+OE2pVVcf9R8fykjIo6dbEvSoH1G99ANxp5rpr53xs9yj41C1yZaXQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Abc Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "ApplicationUserId", "Distance", "EventDate", "EventName", "Location", "MeetName", "UserId" },
                values: new object[,]
                {
                    { 1, null, 5000, new DateTime(2018, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "5k", "Steeplechase", "Sectionals", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, null, 5000, new DateTime(2018, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "5k", "Steeplechase", "Regionals", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, null, 5000, new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "5k", "Steeplechase", "State", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, null, 5000, new DateTime(2018, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5k", "Steeplechase", "Nationals", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, null, 1600, new DateTime(2019, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mile", "Harpeth Hall", "Metro City Meet", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, null, 800, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "800", "Harpeth Hall", "Metro City Meet", "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Threshold" },
                    { 2, "Tempo" },
                    { 3, "Speed" },
                    { 4, "Hills" },
                    { 5, "Long Run" },
                    { 6, "VO2MAX" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "ApplicationUserId", "Description", "Title", "UserId", "WorkoutTypeId" },
                values: new object[,]
                {
                    { 1, null, "1600m @83% w/ 1600m Recovery, 1200m @88% w/ 1200m Recovery, 800m @92% w/ 800m Recovery, 400m @94% w/ 400m Recovery, 200m All out", "Dante's Inferno", "00000000-ffff-ffff-ffff-ffffffffffff", 1 },
                    { 2, null, "Gradual pickup with all out effort half way up", "Hills @ Graybar", "00000000-ffff-ffff-ffff-ffffffffffff", 4 }
                });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "FirstName", "Gender", "Grade", "LastName", "MPW", "UserId" },
                values: new object[,]
                {
                    { 1, "Sam", "Male", 12, "Britt", 55, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, "Alex", "Male", 12, "Carter", 55, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, "Mac", "Male", 9, "McMackerson", 40, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, "Katherine", "Female", 12, "Knowles", 40, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, "Sarah", "Female", 10, "Sararerson", 35, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, "Jimmy", "Male", 11, "McMillen", 50, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "AthleteRaces",
                columns: new[] { "Id", "ActualTime", "AthleteId", "ProjectedTime", "RaceId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 16, 50, 0), 1, new TimeSpan(0, 0, 17, 5, 0), 2 },
                    { 3, new TimeSpan(0, 0, 0, 0, 0), 1, new TimeSpan(0, 0, 4, 20, 0), 2 },
                    { 4, new TimeSpan(0, 0, 17, 0, 0), 2, new TimeSpan(0, 0, 17, 15, 0), 2 },
                    { 2, new TimeSpan(0, 0, 17, 40, 0), 5, new TimeSpan(0, 0, 18, 10, 0), 2 }
                });

            migrationBuilder.InsertData(
                table: "AthleteWorkouts",
                columns: new[] { "Id", "AthleteId", "Distance", "Pace", "Repetition", "WorkoutDate", "WorkoutId" },
                values: new object[] { 1, 1, 4200, new TimeSpan(0, 0, 4, 30, 0), 1, new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteRaces_AthleteId",
                table: "AthleteRaces",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteRaces_RaceId",
                table: "AthleteRaces",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_UserId",
                table: "Athletes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteWorkouts_AthleteId",
                table: "AthleteWorkouts",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteWorkouts_WorkoutId",
                table: "AthleteWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ApplicationUserId",
                table: "Races",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ApplicationUserId",
                table: "Workouts",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AthleteRaces");

            migrationBuilder.DropTable(
                name: "AthleteWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
