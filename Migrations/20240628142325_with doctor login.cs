using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Egyptian_association_of_cieliac_patients.Migrations
{
    /// <inheritdoc />
    public partial class withdoctorlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "0f7672e1-c8c9-44dc-9697-bb32ec7a382c", "bd6124a1-e644-4605-9c11-9625eed2ce12", "StoreManager", "storemanager" },
                    { "135db849-00cd-4039-9c03-5a016bac933d", "0c43984d-edc7-479b-83c1-4dde6ff098fa", "Doctor", "doctor" },
                    { "674e660d-a744-4b05-9b3a-0a7bb9207feb", "4a569597-09c0-4800-b256-a39c2fc7d13c", "Admin", "admin" },
                    { "a554ce68-1553-4894-bc3b-6674dd862ccd", "86f31da4-17bf-4695-93f3-3247f6e70e05", "MedicalManager", "medicalmanager" },
                    { "e3d65d39-2780-4743-bc57-f53053827f62", "0795b71b-4045-4e8c-baca-e884c1354a43", "NormalUser", "normaluser" },
                    { "f42e9cfa-5be8-42e5-8388-5a3fa4094239", "37fec942-f74a-46b5-9acd-799f7caf060f", "UserManager", "usermanager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7672e1-c8c9-44dc-9697-bb32ec7a382c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "135db849-00cd-4039-9c03-5a016bac933d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "674e660d-a744-4b05-9b3a-0a7bb9207feb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a554ce68-1553-4894-bc3b-6674dd862ccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d65d39-2780-4743-bc57-f53053827f62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f42e9cfa-5be8-42e5-8388-5a3fa4094239");

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
        }
    }
}
