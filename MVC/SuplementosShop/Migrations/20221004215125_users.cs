using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuplementosShop.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59973da1-dd11-46d7-88ed-ad93819d2f85", "59973da1-dd11-46d7-88ed-ad93819d2f85", "Customer", "CUSTOMER" },
                    { "e6c36ff5-f673-4745-bf9d-7b321388ed38", "e6c36ff5-f673-4745-bf9d-7b321388ed38", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e11c116b-f5f5-44bf-ad0d-1191cc087888", "AQAAAAEAACcQAAAAEH099CK2kbbt+GCS/wjg/LkgwP9xvHi17PCpG7N7IlXrSGjZuIwlF5A3vjLE+z3USQ==", "31d05b71-8c23-4e00-bbf2-fbb489512dd2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0fbd4a36-8062-42af-912e-fa22aa808bbf", 0, "ebd3e454-f96e-493c-8475-9b0ac4f57c1e", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE", "AQAAAAEAACcQAAAAEH3XXKgZF14ZeEYq55+W6eysb/hOshwWqJjkW+BfA3qLmGg/6isejJAk67BegiEODg==", null, false, "fb9141e3-6f5b-47ee-bc35-acfb79c48c21", false, "Employee" },
                    { "563bcc80-16ed-4f79-83d4-ed3fe59a933c", 0, "6339a2bf-9235-4c41-9c4b-884fb8142aa4", "customer@gmail.com", true, false, null, "CUSTOMER@GMAIL.COM", "CUSTOMER", "AQAAAAEAACcQAAAAEHm+46giT75k8DneubQDrqfrxuanr1G+n3d8s07sD0Lx2Tk0bzYaiugYJCZcTB1+4A==", null, false, "3bd0e38e-0fe2-45f3-b1cd-07ec02c8e452", false, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 11, 1, "30 servicios", "data:image/jpeg;base64,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", "Iso Whey Ripped Star", 8000 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e6c36ff5-f673-4745-bf9d-7b321388ed38", "0fbd4a36-8062-42af-912e-fa22aa808bbf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59973da1-dd11-46d7-88ed-ad93819d2f85", "563bcc80-16ed-4f79-83d4-ed3fe59a933c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c36ff5-f673-4745-bf9d-7b321388ed38", "0fbd4a36-8062-42af-912e-fa22aa808bbf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59973da1-dd11-46d7-88ed-ad93819d2f85", "563bcc80-16ed-4f79-83d4-ed3fe59a933c" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59973da1-dd11-46d7-88ed-ad93819d2f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c36ff5-f673-4745-bf9d-7b321388ed38");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fbd4a36-8062-42af-912e-fa22aa808bbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "563bcc80-16ed-4f79-83d4-ed3fe59a933c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fff6d57-55ac-49d2-9250-703e44776ac5", "AQAAAAEAACcQAAAAEC7EXC98kL+W2n2EcQrJKeW/lYW3g5jhC6wNXIeiqRBOzVp+2XyFnt0xQf0tkWk50Q==", "b1da4965-31c0-4ddf-bccd-65b5e08f6e76" });
        }
    }
}
