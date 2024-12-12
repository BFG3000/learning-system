using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningProject.Migrations
{
    /// <inheritdoc />
    public partial class fixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResult_Answers_AnswerId",
                table: "AnswerResult");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResult_Results_ResultId",
                table: "AnswerResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_InternalUsers_InternalUserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_InternalUserId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerResult",
                table: "AnswerResult");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InternalUserId",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "AnswerResult",
                newName: "AnswerResults");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResult_ResultId",
                table: "AnswerResults",
                newName: "IX_AnswerResults_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResult_AnswerId",
                table: "AnswerResults",
                newName: "IX_AnswerResults_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerResults",
                table: "AnswerResults",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InternalUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalUserRoles_InternalUsers_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRoles_InternalUserId",
                table: "InternalUserRoles",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRoles_RoleId",
                table: "InternalUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResults_Answers_AnswerId",
                table: "AnswerResults",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResults_Results_ResultId",
                table: "AnswerResults",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResults_Answers_AnswerId",
                table: "AnswerResults");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResults_Results_ResultId",
                table: "AnswerResults");

            migrationBuilder.DropTable(
                name: "InternalUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerResults",
                table: "AnswerResults");

            migrationBuilder.RenameTable(
                name: "AnswerResults",
                newName: "AnswerResult");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResults_ResultId",
                table: "AnswerResult",
                newName: "IX_AnswerResult_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResults_AnswerId",
                table: "AnswerResult",
                newName: "IX_AnswerResult_AnswerId");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InternalUserId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerResult",
                table: "AnswerResult",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_InternalUserId",
                table: "Roles",
                column: "InternalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResult_Answers_AnswerId",
                table: "AnswerResult",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResult_Results_ResultId",
                table: "AnswerResult",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_InternalUsers_InternalUserId",
                table: "Roles",
                column: "InternalUserId",
                principalTable: "InternalUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
