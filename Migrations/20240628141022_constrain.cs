using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Egyptian_association_of_cieliac_patients.Migrations
{
    /// <inheritdoc />
    public partial class constrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_order_rawmaterials",
                table: "raw_material");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac7d2f3-c4cc-49ae-8487-e289bd28f7e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c6bcc17-b144-44ee-9413-d2f671427e9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a702aee9-36e2-4389-be8f-07fe074d5374");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba73624c-1382-4b1e-a9c8-88b4b80eda14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05315edf-b9f4-47ee-95cb-53c435495a1a", "b3d639f5-00d5-4347-ad18-930a83b3868f", "MedicalManager", "medicalmanager" },
                    { "6f50391c-3d68-496b-8802-5587608fd116", "6dabf7a3-71bb-4210-a271-dee3ae2606b3", "StoreManager", "storemanager" },
                    { "820e42ce-e8cc-4d5c-bfe9-a9157cbd6e13", "92b36231-ba43-4d00-8f0d-d900e4a6bb7f", "UserManager", "usermanager" },
                    { "8a3d511f-1e03-4105-af3b-f3ae6069db99", "aef59174-9d71-42f1-9b2b-7e3a11018831", "Admin", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_orderid",
                table: "product",
                column: "orderid",
                principalTable: "order",
                principalColumn: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_raw_material_order_orderid",
                table: "raw_material",
                column: "orderid",
                principalTable: "order",
                principalColumn: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_order_orderid",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_raw_material_order_orderid",
                table: "raw_material");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05315edf-b9f4-47ee-95cb-53c435495a1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f50391c-3d68-496b-8802-5587608fd116");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "820e42ce-e8cc-4d5c-bfe9-a9157cbd6e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a3d511f-1e03-4105-af3b-f3ae6069db99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ac7d2f3-c4cc-49ae-8487-e289bd28f7e2", "fcb0c4fd-5e4b-48d9-bfbd-95390ae9cbdd", "MedicalManager", "medicalmanager" },
                    { "8c6bcc17-b144-44ee-9413-d2f671427e9f", "ccd748eb-b69d-44d1-bd19-3b93f7a9fe6d", "Admin", "admin" },
                    { "a702aee9-36e2-4389-be8f-07fe074d5374", "82fa19a8-bc53-461f-a641-b5c4d232d5f3", "UserManager", "usermanager" },
                    { "ba73624c-1382-4b1e-a9c8-88b4b80eda14", "4ace3df9-7eaf-4d93-ab6e-efb10ea508b4", "StoreManager", "storemanager" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_order_product",
                table: "product",
                column: "orderid",
                principalTable: "order",
                principalColumn: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_rawmaterials",
                table: "raw_material",
                column: "orderid",
                principalTable: "order",
                principalColumn: "order_id");
        }
    }
}
