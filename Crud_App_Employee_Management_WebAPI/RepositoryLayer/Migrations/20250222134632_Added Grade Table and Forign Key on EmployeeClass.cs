using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedGradeTableandForignKeyonEmployeeClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "Grades",
            //    columns: table => new
            //    {
            //        GradeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        GradeName = table.Column<string>(type: "longtext", nullable: false),
            //        GradeDescription = table.Column<string>(type: "longtext", nullable: false),
            //        Created_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Modified_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        Created_By = table.Column<sbyte>(type: "tinyint", nullable: false),
            //        ModifiedBy = table.Column<sbyte>(type: "tinyint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Grades", x => x.GradeId);
            //    })
            //    .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        UserName = table.Column<string>(type: "longtext", nullable: false),
            //        Password = table.Column<string>(type: "longtext", nullable: false),
            //        Email = table.Column<string>(type: "longtext", nullable: false),
            //        roles = table.Column<string>(type: "longtext", nullable: false),
            //        FirstName = table.Column<string>(type: "longtext", nullable: false),
            //        LastName = table.Column<string>(type: "longtext", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_users", x => x.Id);
            //    })
            //    .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "EmployeeClass",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        EmployeeFirstName = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeLastName = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeDesignation = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeUserName = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeePassword = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeAge = table.Column<int>(type: "int", nullable: false),
            //        EmployeeCity = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeState = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeZipCode = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeCountry = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeePhone = table.Column<string>(type: "longtext", nullable: true),
            //        EmployeeGrade = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmployeeClass", x => x.EmployeeId);
            //        table.ForeignKey(
            //            name: "FK_EmployeeClass_Grades_EmployeeGrade",
            //            column: x => x.EmployeeGrade,
            //            principalTable: "Grades",
            //            principalColumn: "GradeId",
            //            onDelete: ReferentialAction.Cascade);
            //    })
            //    .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EmployeeClass_EmployeeGrade",
            //    table: "EmployeeClass",
            //    column: "EmployeeGrade");

            //migrationBuilder.AddColumn<int>(
            //    name: "EmployeeGrade",
            //    table: "EmployeeClass",
            //    nullable: false,
            //    defaultValue: 0 // You can set a default value if needed
            //);
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeClass_Grade",  // Custom FK name
                table: "EmployeeClass",
                column: "EmployeeGrade",   // Foreign Key Column
                principalTable: "Grades",   // Referenced Table
                principalColumn: "GradeId" // Primary Key Column in Grade table
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "EmployeeClass");

            //migrationBuilder.DropTable(
            //    name: "users");

            //migrationBuilder.DropTable(
            //    name: "Grades");
            migrationBuilder.DropColumn(
               name: "EmployeeGrade",
               table: "EmployeeClass"
            );
        }
    }
}
