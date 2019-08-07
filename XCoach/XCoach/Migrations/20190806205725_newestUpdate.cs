using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XCoach.Migrations
{
    public partial class newestUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AthleteRaces_Athletes_AthleteId",
                table: "AthleteRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteRaces_Races_RaceId",
                table: "AthleteRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteWorkouts_Athletes_AthleteId",
                table: "AthleteWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteWorkouts_Workouts_WorkoutId",
                table: "AthleteWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_AspNetUsers_ApplicationUserId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_ApplicationUserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ApplicationUserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Races_ApplicationUserId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Races");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Workouts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Races",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ActualTime",
                table: "AthleteRaces",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79cf7d0f-e3f1-4aaf-9161-7ece7de80447", "AQAAAAEAACcQAAAAEB6xMJy0Oi9AjpceUr7HD7xL8R6y2pqKLFl3Uc9YgEoEHToH9nYThWHFS60wYP13Lg==" });

            migrationBuilder.UpdateData(
                table: "AthleteRaces",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualTime",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeId",
                table: "Workouts",
                column: "WorkoutTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_UserId",
                table: "Races",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteRaces_Athletes_AthleteId",
                table: "AthleteRaces",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteRaces_Races_RaceId",
                table: "AthleteRaces",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteWorkouts_Athletes_AthleteId",
                table: "AthleteWorkouts",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteWorkouts_Workouts_WorkoutId",
                table: "AthleteWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AspNetUsers_UserId",
                table: "Races",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserId",
                table: "Workouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_WorkoutTypes_WorkoutTypeId",
                table: "Workouts",
                column: "WorkoutTypeId",
                principalTable: "WorkoutTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AthleteRaces_Athletes_AthleteId",
                table: "AthleteRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteRaces_Races_RaceId",
                table: "AthleteRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteWorkouts_Athletes_AthleteId",
                table: "AthleteWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AthleteWorkouts_Workouts_WorkoutId",
                table: "AthleteWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_AspNetUsers_UserId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_WorkoutTypes_WorkoutTypeId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_WorkoutTypeId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Races_UserId",
                table: "Races");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Workouts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Workouts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Races",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Races",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ActualTime",
                table: "AthleteRaces",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e666f46c-d734-495a-a0e0-6449d7b592b0", "AQAAAAEAACcQAAAAEPyNaDmMRMM0bUJs466m/HyCKcHndnkUae6j1mV0hubwOq85/BnfROyidUtubt8dlQ==" });

            migrationBuilder.UpdateData(
                table: "AthleteRaces",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualTime",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ApplicationUserId",
                table: "Workouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_ApplicationUserId",
                table: "Races",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteRaces_Athletes_AthleteId",
                table: "AthleteRaces",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteRaces_Races_RaceId",
                table: "AthleteRaces",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteWorkouts_Athletes_AthleteId",
                table: "AthleteWorkouts",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteWorkouts_Workouts_WorkoutId",
                table: "AthleteWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AspNetUsers_ApplicationUserId",
                table: "Races",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_ApplicationUserId",
                table: "Workouts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
