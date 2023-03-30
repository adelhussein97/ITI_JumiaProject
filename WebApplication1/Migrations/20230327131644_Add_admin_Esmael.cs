using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Add_admin_Esmael : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'56ce1ba7-5f7d-4efa-ae3a-306d0462e4bf', N'Esmail ', N'Esmail', null, N'AdminEsmail', N'ADMINESMAIL', N'AdminEsmail@gmail.com', N'ADMINESMAIL@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBBapmrQZPt4HetjWHoIoVigUNQa6LeNFxWN2/EtjXCaM/OZWRn0Rd8GqkBisVUTKw==', N'R22ET3JHXBWVYQOCS6OCTZQC7G2DKZSE', N'5fd2b6e9-4f73-4700-b5b9-5de888b29dec', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[users] where Id ='56ce1ba7-5f7d-4efa-ae3a-306d0462e4bf'");
        }
    }
}