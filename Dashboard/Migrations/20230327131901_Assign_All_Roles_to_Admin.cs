using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Assign_All_Roles_to_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [dbo].[UserRoles] (UserId,RoleId) select '1675da80-4426-4156-97f1-9a80673eda2d',Id from [dbo].[Roles]");
            migrationBuilder.Sql("insert into [dbo].[UserRoles] (UserId,RoleId) select 'a7c8fe0f-29d5-4859-a694-6b48f9f60ebb',Id from [dbo].[Roles]");
            migrationBuilder.Sql("insert into [dbo].[UserRoles] (UserId,RoleId) select '0f91c49e-00eb-4b39-b976-ce574d035d7e',Id from [dbo].[Roles]");
            migrationBuilder.Sql("insert into [dbo].[UserRoles] (UserId,RoleId) select '09a8e499-83b2-4969-9e4a-d9d72229f29e',Id from [dbo].[Roles]");
            migrationBuilder.Sql("insert into [dbo].[UserRoles] (UserId,RoleId) select '56ce1ba7-5f7d-4efa-ae3a-306d0462e4bf',Id from [dbo].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[UserRoles]");
        }
    }
}