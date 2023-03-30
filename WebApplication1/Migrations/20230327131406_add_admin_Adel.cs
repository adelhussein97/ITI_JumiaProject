using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class add_admin_Adel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[users]([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'a7c8fe0f-29d5-4859-a694-6b48f9f60ebb', N'Adel', N'Hessien', null, N'AdelADmin', N'ADELADMIN', N'AdelADmin@gmail.com', N'ADELADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELvndrEBxlzaYrs4Q7WSDDkK9NlVvKofqA1K8H+hSXH8GHBrQvnNsDUXVI9h3JQqTA==', N'VCZUGYSXKSEARI6L4AIFJ4NEZXTDBQS4', N'e433358b-e074-4eac-8da7-11fe3d063034', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[users] where Id = 'a7c8fe0f-29d5-4859-a694-6b48f9f60ebb'");
        }
    }
}