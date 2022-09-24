using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuplementosShop.Migrations
{
    public partial class addingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fff6d57-55ac-49d2-9250-703e44776ac5", "AQAAAAEAACcQAAAAEC7EXC98kL+W2n2EcQrJKeW/lYW3g5jhC6wNXIeiqRBOzVp+2XyFnt0xQf0tkWk50Q==", "b1da4965-31c0-4ddf-bccd-65b5e08f6e76" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "300g", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.hln.com.ar%2Fproductos%2Fcreatina-monohidrato-300-grs-star-nutrition%2F&psig=AOvVaw3uY-qNqzTqO9GJMDKADHn2&ust=1664115334639000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCOCKlObOrfoCFQAAAAAdAAAAABAh", "Creatina Star", 8000 },
                    { 2, 2, "300g", "https://farmaciassanchezantoniolli.com.ar/6136-large_default/ultra-tech-creatine-suplemento-deportivo-creatina-x-300g.jpg", "Creatina ultra tech", 9200 },
                    { 3, 3, "285g", "https://titansport.com.ar/wp-content/uploads/2021/02/Pump-v8.png", "Pump V8 Star", 3500 },
                    { 4, 3, "60 servicios", "http://d2r9epyceweg5n.cloudfront.net/stores/001/614/635/products/c4-cellucor-x-601-4b61cb1d3db2b8262f16299857991074-640-0.jpg", "Cellucor C4", 20400 },
                    { 5, 1, "30 servicios, sabor chocolate", "https://www.demusculos.com/shop/24-medium_default/proteina-premium-whey-protein-2-lbs-star-nutrition.jpg", "Whey Protein Star", 5200 },
                    { 6, 1, "30 servicios, sabor chocolate", "https://http2.mlstatic.com/D_NQ_NP_812835-MLA50418167124_062022-O.webp", "Whey Protein Truemade Ena", 5300 },
                    { 7, 1, "30 servicios, sabor vainilla", "https://www.farmacialeloir.com.ar/img/articulos/2021/09/ena_whey_x_pro_complex_protein_1_imagen2.jpg", "Whey Protein X-Pro Ena", 7500 },
                    { 8, 2, "200g", "https://d2r9epyceweg5n.cloudfront.net/stores/001/740/999/products/creatina-universal-200-g1-e8c56af1b6e101139116242981241414-1024-1024.jpg", "Creatina Universal", 12000 },
                    { 9, 1, "1kg, sabor chocolate", "http://d3ugyf2ht6aenh.cloudfront.net/stores/001/040/363/products/chocolate1-369cf71a9add07c4fa16207447748528-640-01-150d24b78c045c676916500317383129-640-0.jpg", "Proteina Ultratech", 12000 },
                    { 10, 2, "300g", "http://d3ugyf2ht6aenh.cloudfront.net/stores/001/533/270/products/28-4-crea-shock-181-c3a33f165bc143986116214473685261-640-0.jpg", "Creatina Nutrilab", 3000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58e3410f-250b-4d1d-9ad0-4aa623ed2247", "AQAAAAEAACcQAAAAEDr3r8AzkXS+JiyPtR170g+gQdetkvtUld18CgyuWk4FVlt6WHt0FUs+MsXZh0lsyA==", "579398d8-7090-4dc9-97c2-aac2a8835eda" });
        }
    }
}
