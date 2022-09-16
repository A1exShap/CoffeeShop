using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStore.DataAccess.Migrations
{
    public partial class Addedtestproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fillTestProducts = MigrationsHelper.ReadSql("fill_test_products.sql");
            migrationBuilder.Sql(fillTestProducts);
            
            var fillTestProductProperties = MigrationsHelper.ReadSql("fill_test_product_properties.sql");
            migrationBuilder.Sql(fillTestProductProperties);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var deleteTestProducts = MigrationsHelper.ReadSql("delete_test_products.sql");
            migrationBuilder.Sql(deleteTestProducts);
        }
    }
}
