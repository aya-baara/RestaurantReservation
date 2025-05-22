using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddGetCustomersByPartySizeProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetCustomersByPartySize
            @PartySize INT
        AS
        BEGIN
            SELECT c.FirstName, c.LastName, c.Email, c.PhoneNumber
            FROM Customers c
            JOIN Reservations r ON c.CustomerId = r.CustomerId
            WHERE r.PartySize > @PartySize
        END
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetCustomersByPartySize");
        }

    }
}
