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
                                    @PostId INT,
                                    @CreatedByUserId INT,
                                    @CreatedDate DATETIME2(7),
                                    @LastModifiedUserId INT,
                                    @LastModifiedDate DATETIME2(7),
                                    @IsActive BIT,
                                    @IsDeleted BIT
                                    AS
                                    BEGIN
                                        INSERT INTO Categories (Name, PostId, CreatedByUserId, CreatedDate, LastModifiedUserId, LastModifiedDate, IsActive, IsDeleted)
                                        VALUES (@Name, @PostId, @CreatedByUserId, @CreatedDate, @LastModifiedUserId, @LastModifiedDate, @IsActive, @IsDeleted);
                                    END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertCategory");
        }
    }
}
