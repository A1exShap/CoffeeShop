using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStore.DataAccess.Migrations
{
    public partial class Initializereferencedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var mergeProductTypes = MigrationsHelper.ReadSql("merge_product_types.sql");
            migrationBuilder.Sql(mergeProductTypes);
            
            var mergePropertyValueTypes = MigrationsHelper.ReadSql("merge_property_value_types.sql");
            migrationBuilder.Sql(mergePropertyValueTypes);
            
            var mergeOrderStatuses = MigrationsHelper.ReadSql("merge_order_statuses.sql");
            migrationBuilder.Sql(mergeOrderStatuses);
            
            var mergeOperationTypes = MigrationsHelper.ReadSql("merge_operation_types.sql");
            migrationBuilder.Sql(mergeOperationTypes);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var mergeProductTypesRollback = MigrationsHelper.ReadSql("merge_product_types_rollback.sql");
            migrationBuilder.Sql(mergeProductTypesRollback);

            var mergePropertyValueTypesRollback = MigrationsHelper.ReadSql("merge_property_value_types_rollback.sql");
            migrationBuilder.Sql(mergePropertyValueTypesRollback);
            
            var mergeOrderStatusesRollback = MigrationsHelper.ReadSql("merge_order_statuses_rollback.sql");
            migrationBuilder.Sql(mergeOrderStatusesRollback);
            
            var mergeOperationTypesRollback = MigrationsHelper.ReadSql("merge_operation_types_rollback.sql");
            migrationBuilder.Sql(mergeOperationTypesRollback);
        }
    }
}
