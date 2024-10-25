using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("ea83a2e4-7efb-4078-87d0-1abd38e00198"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 24, 21, 54, 19, 285, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdafc3c9-abe6-4ac5-bdb6-8361524ff999"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 24, 21, 54, 19, 285, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5a4eb59-26b3-4784-b427-65b5f7f57052"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 24, 21, 54, 19, 285, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d7957d2-2ca7-43eb-b9e0-6e300da1a6b4"),
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2cc1ca42-7f05-48e9-b223-886c5c98a4af"),
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8faaae7-fee5-450c-ac98-0baaa046077d"),
                column: "IsAdded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4b56b1a-6372-4e5b-9f61-03ee2b5e6b64"),
                column: "IsAdded",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("ea83a2e4-7efb-4078-87d0-1abd38e00198"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 23, 19, 0, 21, 836, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdafc3c9-abe6-4ac5-bdb6-8361524ff999"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 23, 19, 0, 21, 836, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5a4eb59-26b3-4784-b427-65b5f7f57052"),
                column: "CreateTime",
                value: new DateTime(2024, 10, 23, 19, 0, 21, 836, DateTimeKind.Local).AddTicks(5243));
        }
    }
}
