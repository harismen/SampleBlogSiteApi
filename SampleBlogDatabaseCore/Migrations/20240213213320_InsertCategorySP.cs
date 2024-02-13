using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBlogDatabaseCore.Migrations
{
    public partial class InsertCategorySP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE InsertCategory
                                    @Name NVARCHAR(100),
                                    @CreatedDate DATETIME2(7),
                                    @IsActive BIT,
                                    @IsDeleted BIT
                                    AS
                                    BEGIN
                                        INSERT INTO Categories (Name, CreatedDate, IsActive, IsDeleted)
                                        VALUES (@Name, @CreatedDate, @IsActive, @IsDeleted);
                                    END"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertCategory");
        }
    }
}
