using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddGetTotalRevenueByRestaurantFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE FUNCTION dbo.TotalRevenue
            (@RestuarantId Int)
            RETURNS Int
            AS
            BEGIN
                return (
	            select sum(o.TotalAmount) from Reservations r
	            join Orders o on r.ReservationId = o.ReservationId
	            where r.RestaurantId = @RestuarantId
	            )
            END
         ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS TotalRevenue");
        }

    }
}
