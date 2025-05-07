using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW EmployeeDetails AS
        SELECT e.FirstName,e.LastName ,e.Position , res.Name ,res.Address
        FROM Employees e
        join Restaurants res on e.RestaurantId= res.RestaurantId;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS EmployeeDetails;");
        }
    }
}
