using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Add_admin_fady : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("  INSERT INTO[dbo].[users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'09a8e499-83b2-4969-9e4a-d9d72229f29e', N'Fady', N'Falts', null, N'FadyAdmin', N'FADYADMIN', N'FadyAdmin@gmail.com', N'FADYADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELYcz3iR8geP6islLOMbQC4VUKXvLSGMAABo1uc7yBkI+Lbz9EtFEuEvY/N7IBKP5Q==', N'HE2T2RGUCJC26I22HDFHLMQLNEMLIRHH', N'1f7d1560-5557-46ac-922d-fcce37262e6d', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[users] where Id ='09a8e499-83b2-4969-9e4a-d9d72229f29e' ");
        }
    }
}