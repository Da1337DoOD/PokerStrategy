namespace PokerStrategy.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CategoryForReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ForumReplies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForumReplies_CategoryId",
                table: "ForumReplies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_ForumCategories_CategoryId",
                table: "ForumReplies",
                column: "CategoryId",
                principalTable: "ForumCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_ForumCategories_CategoryId",
                table: "ForumReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumReplies_CategoryId",
                table: "ForumReplies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ForumReplies");
        }
    }
}
