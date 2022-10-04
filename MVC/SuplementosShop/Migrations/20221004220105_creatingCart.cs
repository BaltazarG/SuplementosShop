using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuplementosShop.Migrations
{
    public partial class creatingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48c97b6e-7b14-4e12-bc5a-b98f604c658f", "AQAAAAEAACcQAAAAEMNhyEfN8cSma+ATzaUs9Gm+DbY00l7DKt1tZGQDi2so6Iu7ZOfflB6m1U4R9Sl7LA==", "cb13ab03-a366-4b91-a09f-39b4712ae22a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fbd4a36-8062-42af-912e-fa22aa808bbf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bac7473d-8875-4023-b0db-caac4517072e", "AQAAAAEAACcQAAAAEMZRvqH2kmY66bs7MJibgpwI1Hs6g9/n1ZXoEsChtBH/M5KJpJAnfUocfYF7l+kKeQ==", "4085f3bb-31bc-4aa3-864b-8ec8a0986095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "563bcc80-16ed-4f79-83d4-ed3fe59a933c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c725147d-6a20-4590-818e-8cb661dedaf3", "AQAAAAEAACcQAAAAENtBt28jHwPovcxk8cDD9PDiy2j2ZmQlfbNx7rwhf/xP539aa2wtdOfT9BCKYmRZOQ==", "9b1910cc-0c7a-4c04-845c-3a2a04bbb1d2" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "563bcc80-16ed-4f79-83d4-ed3fe59a933c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e11c116b-f5f5-44bf-ad0d-1191cc087888", "AQAAAAEAACcQAAAAEH099CK2kbbt+GCS/wjg/LkgwP9xvHi17PCpG7N7IlXrSGjZuIwlF5A3vjLE+z3USQ==", "31d05b71-8c23-4e00-bbf2-fbb489512dd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fbd4a36-8062-42af-912e-fa22aa808bbf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebd3e454-f96e-493c-8475-9b0ac4f57c1e", "AQAAAAEAACcQAAAAEH3XXKgZF14ZeEYq55+W6eysb/hOshwWqJjkW+BfA3qLmGg/6isejJAk67BegiEODg==", "fb9141e3-6f5b-47ee-bc35-acfb79c48c21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "563bcc80-16ed-4f79-83d4-ed3fe59a933c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6339a2bf-9235-4c41-9c4b-884fb8142aa4", "AQAAAAEAACcQAAAAEHm+46giT75k8DneubQDrqfrxuanr1G+n3d8s07sD0Lx2Tk0bzYaiugYJCZcTB1+4A==", "3bd0e38e-0fe2-45f3-b1cd-07ec02c8e452" });
        }
    }
}
