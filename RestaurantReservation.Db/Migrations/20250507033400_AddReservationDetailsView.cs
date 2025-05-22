using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW ReservationDetails AS
        SELECT 
            r.ReservationId, 
            c.FirstName,
            c.LastName,
            c.Email,
            c.PhoneNumber AS CustomerPhoneNumber,
            res.Name,
            res.Address,
            res.OpeningHours,
            res.PhoneNumber AS RestaurantPhoneNumber
        FROM Reservations r
        JOIN Customers c ON r.CustomerId = c.CustomerId
        JOIN Restaurants res ON r.RestaurantId = res.RestaurantId;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS ReservationDetails;");
        }

    }
}
