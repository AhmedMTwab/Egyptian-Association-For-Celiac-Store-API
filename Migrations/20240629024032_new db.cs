using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Egyptian_association_of_cieliac_patients.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "assosiation_branch",
                columns: table => new
                {
                    assosiation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    open_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    close_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assosiation_branch", x => x.assosiation_id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "clinic",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    open_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    close_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic", x => x.clinic_id);
                });

            migrationBuilder.CreateTable(
                name: "dises",
                columns: table => new
                {
                    dises_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dises", x => x.dises_id);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    major = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "health_insurance",
                columns: table => new
                {
                    insurance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LicenseCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_health_insurance", x => x.insurance_id);
                });

            migrationBuilder.CreateTable(
                name: "hospital",
                columns: table => new
                {
                    hospital_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital", x => x.hospital_id);
                });

            migrationBuilder.CreateTable(
                name: "lab",
                columns: table => new
                {
                    lab_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    open_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    close_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab", x => x.lab_id);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy",
                columns: table => new
                {
                    pharmacy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    open_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    close_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy", x => x.pharmacy_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assosiation_branch_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assosiation_branch_phone", x => new { x.phone_number, x.assosiation_id });
                    table.ForeignKey(
                        name: "FK_assosiation_branch_phone_assosiation_branch",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patient_bloodtype = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.patient_id);
                    table.ForeignKey(
                        name: "FK_patient_assosiation_branch_assosiation_id",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raw_material",
                columns: table => new
                {
                    material_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raw_material", x => x.material_id);
                    table.ForeignKey(
                        name: "FK_raw_material_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinic_address",
                columns: table => new
                {
                    clinic_address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_address", x => new { x.clinic_address, x.clinic_id });
                    table.ForeignKey(
                        name: "FK_clinic_address_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinic_assosiation_discount",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_assosiation_discount", x => new { x.clinic_id, x.assosiation_id });
                    table.ForeignKey(
                        name: "FK_clinic_assosiation_discount_assosiation_branch",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_assosiation_discount_clinic",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinic_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_phone", x => new { x.phone_number, x.clinic_id });
                    table.ForeignKey(
                        name: "FK_clinic_phone_clinic",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assosiation_dises_follow",
                columns: table => new
                {
                    dises_id = table.Column<int>(type: "int", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assosiation_dises_follow", x => new { x.dises_id, x.assosiation_id });
                    table.ForeignKey(
                        name: "FK_assosiation_dises__dises",
                        column: x => x.dises_id,
                        principalTable: "dises",
                        principalColumn: "dises_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assosiation_dises_follow_assosiation_branch",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctor_clinic_work",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    arrive_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    leave_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_clinic_work", x => new { x.clinic_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_doctor_clinic_work_clinic",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctor_clinic_work_doctor",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctor_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_phone", x => new { x.phone_number, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_doctor_phone_doctor",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assosiation_insurance_provide",
                columns: table => new
                {
                    assosiation_id = table.Column<int>(type: "int", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assosiation_insurance_provide", x => new { x.assosiation_id, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_assosiation_assosiation_branch",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assosiation_health_insurance",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinic_insurance_discount",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_insurance_discount", x => new { x.clinic_id, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_clinic_insurance_discount_clinic",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clinic_insurance_discount_health_insurance",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "insurance_address",
                columns: table => new
                {
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_address", x => new { x.address, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_insurance_address_health_insurance",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "insurance_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_phone", x => new { x.phone_number, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_insurance_phone_health_insurance",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_address",
                columns: table => new
                {
                    hospital_address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hospital_id = table.Column<int>(type: "int", nullable: false),
                    hospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_address", x => new { x.hospital_address, x.hospital_id });
                    table.ForeignKey(
                        name: "FK_hospital_address_hospital_hospitalId",
                        column: x => x.hospitalId,
                        principalTable: "hospital",
                        principalColumn: "hospital_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_insurance_discount",
                columns: table => new
                {
                    hospital_id = table.Column<int>(type: "int", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_insurance_discount", x => new { x.hospital_id, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_hospital_insurance_discount_health_insurance_insurance_id",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_insurance_discount_hospital_hospital_id",
                        column: x => x.hospital_id,
                        principalTable: "hospital",
                        principalColumn: "hospital_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hospital_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_phone", x => new { x.phone_number, x.hospital_id });
                    table.ForeignKey(
                        name: "FK_hospital_phone_hospital_hospital_id",
                        column: x => x.hospital_id,
                        principalTable: "hospital",
                        principalColumn: "hospital_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_type",
                columns: table => new
                {
                    hospital_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hospital_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_type", x => new { x.hospital_type, x.hospital_id });
                    table.ForeignKey(
                        name: "FK_hospital_type_hospital_hospital_id",
                        column: x => x.hospital_id,
                        principalTable: "hospital",
                        principalColumn: "hospital_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab_address",
                columns: table => new
                {
                    lab_address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lab_id = table.Column<int>(type: "int", nullable: false),
                    labId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_address", x => new { x.lab_address, x.lab_id });
                    table.ForeignKey(
                        name: "FK_lab_address_lab_labId",
                        column: x => x.labId,
                        principalTable: "lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab_assosiation_discount",
                columns: table => new
                {
                    lab_id = table.Column<int>(type: "int", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_assosiation_discount", x => new { x.lab_id, x.assosiation_id });
                    table.ForeignKey(
                        name: "FK_lab_assosiation_discount_assosiation_branch_assosiation_id",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lab_assosiation_discount_lab_lab_id",
                        column: x => x.lab_id,
                        principalTable: "lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab_insurance_discount",
                columns: table => new
                {
                    lab_id = table.Column<int>(type: "int", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_insurance_discount", x => new { x.lab_id, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_lab_insurance_discount_health_insurance_insurance_id",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lab_insurance_discount_lab_lab_id",
                        column: x => x.lab_id,
                        principalTable: "lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lab_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_phone", x => new { x.phone_number, x.lab_id });
                    table.ForeignKey(
                        name: "FK_lab_phone_lab_lab_id",
                        column: x => x.lab_id,
                        principalTable: "lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lab_type",
                columns: table => new
                {
                    lab_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lab_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab_type", x => new { x.lab_type, x.lab_id });
                    table.ForeignKey(
                        name: "FK_lab_type_lab_lab_id",
                        column: x => x.lab_id,
                        principalTable: "lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy_address",
                columns: table => new
                {
                    pharmacy_address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pharmacy_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy_address", x => new { x.pharmacy_address, x.pharmacy_id });
                    table.ForeignKey(
                        name: "FK_pharmacy_address_pharmacy_pharmacy_id",
                        column: x => x.pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy_assosiation_discount",
                columns: table => new
                {
                    pharmacy_id = table.Column<int>(type: "int", nullable: false),
                    assosiation_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy_assosiation_discount", x => new { x.pharmacy_id, x.assosiation_id });
                    table.ForeignKey(
                        name: "FK_pharmacy_assosiation_discount_assosiation_branch_assosiation_id",
                        column: x => x.assosiation_id,
                        principalTable: "assosiation_branch",
                        principalColumn: "assosiation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pharmacy_assosiation_discount_pharmacy_pharmacy_id",
                        column: x => x.pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy_insurance_discount",
                columns: table => new
                {
                    Pharmacy_id = table.Column<int>(type: "int", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    discount_precentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy_insurance_discount", x => new { x.Pharmacy_id, x.insurance_id });
                    table.ForeignKey(
                        name: "FK_pharmacy_insurance_discount_health_insurance_insurance_id",
                        column: x => x.insurance_id,
                        principalTable: "health_insurance",
                        principalColumn: "insurance_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pharmacy_insurance_discount_pharmacy_Pharmacy_id",
                        column: x => x.Pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pharmacy_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pharmacy_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacy_phone", x => new { x.phone_number, x.pharmacy_id });
                    table.ForeignKey(
                        name: "FK_pharmacy_phone_pharmacy_pharmacy_id",
                        column: x => x.pharmacy_id,
                        principalTable: "pharmacy",
                        principalColumn: "pharmacy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_record",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: true),
                    dises_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_record", x => x.record_id);
                    table.ForeignKey(
                        name: "FK_medical_record-patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_date = table.Column<DateOnly>(type: "date", nullable: false),
                    order_details = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total_cost = table.Column<decimal>(type: "money", nullable: false),
                    shipment_location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    shipment_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    shipment_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    Cart_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_Carts_Cart_id",
                        column: x => x.Cart_id,
                        principalTable: "Carts",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id");
                });

            migrationBuilder.CreateTable(
                name: "patient_address",
                columns: table => new
                {
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_address", x => new { x.address, x.patient_id });
                    table.ForeignKey(
                        name: "FK_patient_address_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_dises-have",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    dises_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_dises-have", x => new { x.patient_id, x.dises_id });
                    table.ForeignKey(
                        name: "FK_patient_dises-have_dises",
                        column: x => x.dises_id,
                        principalTable: "dises",
                        principalColumn: "dises_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_dises-have_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_phone",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_phone", x => new { x.phone_number, x.patient_id });
                    table.ForeignKey(
                        name: "FK_patient_phone_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    reservation_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    book_date = table.Column<DateOnly>(type: "date", nullable: false),
                    book_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    clinic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_reservation_clinic_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "clinic",
                        principalColumn: "clinic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dises_product_catogrize",
                columns: table => new
                {
                    dises_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    catogert_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dises_product_catogrize", x => new { x.dises_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_dises_product_catogrize_dises",
                        column: x => x.dises_id,
                        principalTable: "dises",
                        principalColumn: "dises_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dises_product_catogrize_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_product_view",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_product_view", x => new { x.patient_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_patient_product_view_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_product_view_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    image_path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_image", x => new { x.product_id, x.image_path });
                    table.ForeignKey(
                        name: "FK_product_image_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dises_material_catogrize",
                columns: table => new
                {
                    dises_id = table.Column<int>(type: "int", nullable: false),
                    material_id = table.Column<int>(type: "int", nullable: false),
                    catogery_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dises_material_catogrize", x => new { x.dises_id, x.material_id });
                    table.ForeignKey(
                        name: "FK_raw_material_dises_catogrize_dises",
                        column: x => x.dises_id,
                        principalTable: "dises",
                        principalColumn: "dises_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_raw_material_dises_catogrize_raw_material",
                        column: x => x.material_id,
                        principalTable: "raw_material",
                        principalColumn: "material_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_rawmaterial_veiw",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    material_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_rawmaterial_veiw", x => new { x.patient_id, x.material_id });
                    table.ForeignKey(
                        name: "FK_patient_rawmaterial_veiw_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_rawmaterial_veiw_raw_material",
                        column: x => x.material_id,
                        principalTable: "raw_material",
                        principalColumn: "material_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rawmaterial_image",
                columns: table => new
                {
                    image_path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    material_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rawmaterial_image", x => new { x.image_path, x.material_id });
                    table.ForeignKey(
                        name: "FK_rawmaterial_image_raw_material",
                        column: x => x.material_id,
                        principalTable: "raw_material",
                        principalColumn: "material_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctor_medicalrecord_veiw",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_medicalrecord_veiw", x => new { x.record_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_doctor_medicalrecord_veiw_doctor",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctor_medicalrecord_veiw_medical_record",
                        column: x => x.record_id,
                        principalTable: "medical_record",
                        principalColumn: "record_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_record-drug",
                columns: table => new
                {
                    drug = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_record-drug", x => new { x.drug, x.record_id });
                    table.ForeignKey(
                        name: "FK_medical_record-drug_medical_record",
                        column: x => x.record_id,
                        principalTable: "medical_record",
                        principalColumn: "record_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medical_record-test",
                columns: table => new
                {
                    test = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_record-test", x => new { x.record_id, x.test });
                    table.ForeignKey(
                        name: "FK_medical_record-test_medical_record",
                        column: x => x.record_id,
                        principalTable: "medical_record",
                        principalColumn: "record_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    total_paid = table.Column<decimal>(type: "money", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payment_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07c277cf-e131-451d-8ab9-c8e9c8ccb7aa", "4615f5df-6745-4f82-bda9-398cb9fc06e8", "UserManager", "usermanager" },
                    { "6bcae34f-4f0f-4504-ba1b-5f48b27dc3dd", "af9ed102-3a2a-436a-95cb-b48183850688", "Admin", "admin" },
                    { "6ff65ed8-01eb-4e8a-b044-a68dbacd3d4a", "455d62ad-a952-4ea7-88c8-18bce29a87da", "Doctor", "doctor" },
                    { "77e8b0ab-072f-482f-a74d-ed0451a168e2", "13829279-6805-43be-b47c-8df2a32758dd", "StoreManager", "storemanager" },
                    { "9b6d9be1-6eac-40cf-b69f-899910ff7997", "acd08230-b280-455a-80c1-d0c42fc30741", "MedicalManager", "medicalmanager" },
                    { "c8d54bed-6f2f-40f6-a9ca-ef4c8450615a", "475ddf7b-8e58-4888-8ae7-780047ee9c80", "NormalUser", "normaluser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_assosiation_branch_phone_assosiation_id",
                table: "assosiation_branch_phone",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_assosiation_dises_follow_assosiation_id",
                table: "assosiation_dises_follow",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_assosiation_insurance_provide_insurance_id",
                table: "assosiation_insurance_provide",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_address_clinic_id",
                table: "clinic_address",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_assosiation_discount_assosiation_id",
                table: "clinic_assosiation_discount",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_insurance_discount_insurance_id",
                table: "clinic_insurance_discount",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinic_phone_clinic_id",
                table: "clinic_phone",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_dises_material_catogrize_material_id",
                table: "dises_material_catogrize",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_dises_product_catogrize_product_id",
                table: "dises_product_catogrize",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_clinic_work_doctor_id",
                table: "doctor_clinic_work",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_medicalrecord_veiw_doctor_id",
                table: "doctor_medicalrecord_veiw",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_phone_doctor_id",
                table: "doctor_phone",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_address_hospitalId",
                table: "hospital_address",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_insurance_discount_insurance_id",
                table: "hospital_insurance_discount",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_phone_hospital_id",
                table: "hospital_phone",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_type_hospital_id",
                table: "hospital_type",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_address_insurance_id",
                table: "insurance_address",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_phone_insurance_id",
                table: "insurance_phone",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_address_labId",
                table: "lab_address",
                column: "labId");

            migrationBuilder.CreateIndex(
                name: "IX_lab_assosiation_discount_assosiation_id",
                table: "lab_assosiation_discount",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_insurance_discount_insurance_id",
                table: "lab_insurance_discount",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_phone_lab_id",
                table: "lab_phone",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_lab_type_lab_id",
                table: "lab_type",
                column: "lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_medical_record_patient_id",
                table: "medical_record",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_medical_record-drug_record_id",
                table: "medical_record-drug",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_Cart_id",
                table: "order",
                column: "Cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_patient_id",
                table: "order",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_assosiation_id",
                table: "patient",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_address_patient_id",
                table: "patient_address",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_dises-have_dises_id",
                table: "patient_dises-have",
                column: "dises_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_phone_patient_id",
                table: "patient_phone",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_product_view_product_id",
                table: "patient_product_view",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_rawmaterial_veiw_material_id",
                table: "patient_rawmaterial_veiw",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_OrderId",
                table: "payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_address_pharmacy_id",
                table: "pharmacy_address",
                column: "pharmacy_id");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_assosiation_discount_assosiation_id",
                table: "pharmacy_assosiation_discount",
                column: "assosiation_id");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_insurance_discount_insurance_id",
                table: "pharmacy_insurance_discount",
                column: "insurance_id");

            migrationBuilder.CreateIndex(
                name: "IX_pharmacy_phone_pharmacy_id",
                table: "pharmacy_phone",
                column: "pharmacy_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_CartId",
                table: "product",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_raw_material_CartId",
                table: "raw_material",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_rawmaterial_image_material_id",
                table: "rawmaterial_image",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_clinic_id",
                table: "reservation",
                column: "clinic_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_patient_id",
                table: "reservation",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "assosiation_branch_phone");

            migrationBuilder.DropTable(
                name: "assosiation_dises_follow");

            migrationBuilder.DropTable(
                name: "assosiation_insurance_provide");

            migrationBuilder.DropTable(
                name: "clinic_address");

            migrationBuilder.DropTable(
                name: "clinic_assosiation_discount");

            migrationBuilder.DropTable(
                name: "clinic_insurance_discount");

            migrationBuilder.DropTable(
                name: "clinic_phone");

            migrationBuilder.DropTable(
                name: "dises_material_catogrize");

            migrationBuilder.DropTable(
                name: "dises_product_catogrize");

            migrationBuilder.DropTable(
                name: "doctor_clinic_work");

            migrationBuilder.DropTable(
                name: "doctor_medicalrecord_veiw");

            migrationBuilder.DropTable(
                name: "doctor_phone");

            migrationBuilder.DropTable(
                name: "hospital_address");

            migrationBuilder.DropTable(
                name: "hospital_insurance_discount");

            migrationBuilder.DropTable(
                name: "hospital_phone");

            migrationBuilder.DropTable(
                name: "hospital_type");

            migrationBuilder.DropTable(
                name: "insurance_address");

            migrationBuilder.DropTable(
                name: "insurance_phone");

            migrationBuilder.DropTable(
                name: "lab_address");

            migrationBuilder.DropTable(
                name: "lab_assosiation_discount");

            migrationBuilder.DropTable(
                name: "lab_insurance_discount");

            migrationBuilder.DropTable(
                name: "lab_phone");

            migrationBuilder.DropTable(
                name: "lab_type");

            migrationBuilder.DropTable(
                name: "medical_record-drug");

            migrationBuilder.DropTable(
                name: "medical_record-test");

            migrationBuilder.DropTable(
                name: "patient_address");

            migrationBuilder.DropTable(
                name: "patient_dises-have");

            migrationBuilder.DropTable(
                name: "patient_phone");

            migrationBuilder.DropTable(
                name: "patient_product_view");

            migrationBuilder.DropTable(
                name: "patient_rawmaterial_veiw");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "pharmacy_address");

            migrationBuilder.DropTable(
                name: "pharmacy_assosiation_discount");

            migrationBuilder.DropTable(
                name: "pharmacy_insurance_discount");

            migrationBuilder.DropTable(
                name: "pharmacy_phone");

            migrationBuilder.DropTable(
                name: "product_image");

            migrationBuilder.DropTable(
                name: "rawmaterial_image");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "hospital");

            migrationBuilder.DropTable(
                name: "lab");

            migrationBuilder.DropTable(
                name: "medical_record");

            migrationBuilder.DropTable(
                name: "dises");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "health_insurance");

            migrationBuilder.DropTable(
                name: "pharmacy");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "raw_material");

            migrationBuilder.DropTable(
                name: "clinic");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "assosiation_branch");
        }
    }
}
