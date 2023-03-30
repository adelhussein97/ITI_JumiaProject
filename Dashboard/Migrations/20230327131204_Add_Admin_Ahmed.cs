using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Add_Admin_Ahmed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1675da80-4426-4156-97f1-9a80673eda2d', N'Ahmed', N'Sameh', null, N'AhmedAdmin', N'AHMEDADMIN', N'AhmedAdmin@gmail.com', N'AHMEDADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBgGXGNQDFaTlwmLfZMBPeReIm9pDSyLRJqxuX2kasVfhCZtUq8IlniSHllGTkZexA==', N'CWVI6XWNK4PHHQNUJWECF23HSRVV3WKB', N'4f5795ad-f4a0-4cae-9869-b2090127914b', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[users] where Id = '1675da80-4426-4156-97f1-9a80673eda2d'");
        }
    }
}