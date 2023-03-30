using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Add_admin_karam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'0f91c49e-00eb-4b39-b976-ce574d035d7e', N'Karam', N'Karam', null, N'AdminKaram', N'ADMINKARAM', N'AdminKaram@gmail.com', N'ADMINKARAM@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEIpVAUiu6X7HHyw7NI0S+IxYVzcEshtFUWXWkVPtFoCSmSzqIQizTzn82C77nMi3+Q==', N'EQ5Z5KPXSBPESMUVY5JD5LDM7NRY3735', N'1894b558-b983-4471-8e2c-8fabd19979d7', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[users] where Id = '0f91c49e-00eb-4b39-b976-ce574d035d7e'");
        }
    }
}