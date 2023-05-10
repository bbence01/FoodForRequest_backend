using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodForRequest.Migrations
{
    public partial class offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71f6fd23-1412-41fc-a7a4-b5766c67fbdc");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "3e2ccacd-12ce-4867-b9d4-b70e877ee540");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "91b30b3d-b283-4551-9fe9-63d10816a269");

            migrationBuilder.DeleteData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "e3220fc5-8db1-404a-b057-1e0fb7ba8086");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "035bbd0d-20fd-46de-823d-57b35bfd167b");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "45b5cc18-33c1-414a-89be-857ce5918917");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "4a487250-4db7-4b0d-a6c5-6816f031864b");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "72c9aaf6-70aa-479c-8622-d8f12eca3557");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "ba70f1a9-e411-4829-b473-177eca63b707");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "da5c266c-9166-4af0-a00d-38f5298dd269");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b925fca-7c7f-463d-a591-1ed8babf8c98");

            migrationBuilder.DeleteData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "10be2a69-ca05-432b-adf2-2002b768dd49");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6d3fe22-589c-4db6-b09b-ed2ac7ece8df");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "FoodUserName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b33d921-a653-46b4-b554-2fcf44b074b8", 0, "462d34c2-f059-49ef-92a0-69603d8f2eed", "FoodUser", null, true, "Béla", "kisbela@gmail.com", "Kiss", false, null, null, "KISBELA@GMAIL.COM", "AQAAAAEAACcQAAAAEN3Y5PJxbDjJUl+zYggtrRmuT3LxwWZDfpkgrfCuEMv5sgJmrPvbk7oVkOmxIX+vJA==", null, false, "4e0fa68f-a601-4e20-bd80-613ec5380d8a", false, "kisbela@gmail.com" },
                    { "6ec16e3b-9a5e-49cd-a243-c2468de5f853", 0, "1318a0c5-4ca2-4bbc-ba02-9c54ba51ab96", "FoodUser", null, true, "József", "jozsefjozsika@gmail.com", "Kelemen", false, null, null, "JOZSEFJOZSIKA@GMAIL.COM", "AQAAAAEAACcQAAAAEGlmZkJkgxGqFEvQoB7IqQms5UlDcQCf1ObSipdFI1/g2TbiHl3AknvBIYwAme0JZA==", null, false, "facd9f9e-ef6c-4a42-b68d-12f2998d8f8a", false, "jozsefjozsika@gmail.com" },
                    { "c80c45df-eb32-416d-acf4-95175e87daa2", 0, "32475cfc-6d12-401c-a4f0-8ead39c895d6", "FoodUser", null, true, "Ferenc", "ferkoberko@gmail.com", "Kovács", false, null, null, "FERKOBERKO@GMAIL.COM", "AQAAAAEAACcQAAAAEIWtLNtd3KMaG63JjPfKTdSV94DMqnuOdwbaJV2t9N2pCh+gdaOd8YJK+QgOlsOcpw==", null, false, "b7683179-f9df-4479-bac7-753ab8c0280e", false, "ferkoberko@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "dfc9ad00-2a5c-48b5-9ec8-23f0decc21a7", "Dark", "4", "Choko" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ContractorId", "RequestId", "Text" },
                values: new object[,]
                {
                    { "c4a3cf4e-0621-4611-bf0a-f46b82411cae", "c80c45df-eb32-416d-acf4-95175e87daa2", "4", "Hello" },
                    { "c8e4e52c-a582-467f-958a-0612429d7ffc", "c80c45df-eb32-416d-acf4-95175e87daa2", "3", "Hi" }
                });

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "3",
                column: "RequestorId",
                value: "6ec16e3b-9a5e-49cd-a243-c2468de5f853");

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "4",
                column: "RequestorId",
                value: "6ec16e3b-9a5e-49cd-a243-c2468de5f853");

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "5",
                column: "RequestorId",
                value: "6ec16e3b-9a5e-49cd-a243-c2468de5f853");

            migrationBuilder.InsertData(
                table: "Foodrequests",
                columns: new[] { "Id", "Description", "IsDone", "Name", "PictureContentType", "RequestorId" },
                values: new object[,]
                {
                    { "43c89048-798b-44d3-8bfd-bc8d4475757f", "Sülthus", false, "Stake", "Image/jpeg", "1b33d921-a653-46b4-b554-2fcf44b074b8" },
                    { "6d589dfb-82cd-4235-885b-d96ad4cd3b2f", "Nyers hal", false, "Susi", "Image/jpeg", "1b33d921-a653-46b4-b554-2fcf44b074b8" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Choosen", "ContractorId", "FoodId" },
                values: new object[,]
                {
                    { "217755f8-f4ec-40f5-b4ae-21794c1d0226", false, "1b33d921-a653-46b4-b554-2fcf44b074b8", "3" },
                    { "5e39dd77-7695-43c3-aefd-f74176f52e22", false, "c80c45df-eb32-416d-acf4-95175e87daa2", "4" },
                    { "d1eca9b3-b27c-4ef8-b0d1-192217ec269d", false, "c80c45df-eb32-416d-acf4-95175e87daa2", "3" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "c38dfa96-0938-405b-9fd6-26fa30b533f5", "Tuna", "6d589dfb-82cd-4235-885b-d96ad4cd3b2f", "Hal" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "d8e2bfa6-f27b-46f9-8fab-d94c7c3fa302", "Rizs", "6d589dfb-82cd-4235-885b-d96ad4cd3b2f", "Rizs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ec16e3b-9a5e-49cd-a243-c2468de5f853");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "c4a3cf4e-0621-4611-bf0a-f46b82411cae");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "c8e4e52c-a582-467f-958a-0612429d7ffc");

            migrationBuilder.DeleteData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "43c89048-798b-44d3-8bfd-bc8d4475757f");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "c38dfa96-0938-405b-9fd6-26fa30b533f5");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "d8e2bfa6-f27b-46f9-8fab-d94c7c3fa302");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "dfc9ad00-2a5c-48b5-9ec8-23f0decc21a7");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "217755f8-f4ec-40f5-b4ae-21794c1d0226");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "5e39dd77-7695-43c3-aefd-f74176f52e22");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: "d1eca9b3-b27c-4ef8-b0d1-192217ec269d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80c45df-eb32-416d-acf4-95175e87daa2");

            migrationBuilder.DeleteData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "6d589dfb-82cd-4235-885b-d96ad4cd3b2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b33d921-a653-46b4-b554-2fcf44b074b8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "FoodUserName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "71f6fd23-1412-41fc-a7a4-b5766c67fbdc", 0, "cb5f47dd-7994-47d9-8f3f-69e515220da5", "FoodUser", null, true, "József", "jozsefjozsika@gmail.com", "Kelemen", false, null, null, "JOZSEFJOZSIKA@GMAIL.COM", "AQAAAAEAACcQAAAAEPYZ7JBdtzgpZf3sM16poclTwscfHeUvTHBQWmilHFnqAWbd2ZQlOYq/cAhZf68L2w==", null, false, "c70f493c-7b5a-4996-99d7-3acfd8cfb9f1", false, "jozsefjozsika@gmail.com" },
                    { "8b925fca-7c7f-463d-a591-1ed8babf8c98", 0, "e79960ea-612f-4914-aa54-d7904ded64df", "FoodUser", null, true, "Ferenc", "ferkoberko@gmail.com", "Kovács", false, null, null, "FERKOBERKO@GMAIL.COM", "AQAAAAEAACcQAAAAELYRhaD50AjWKK6Cuzx6/Qm29+hGhj6JmAza//Wg9Q9c+xpTNiMqHIJrCrkQeGVSXw==", null, false, "17da36b7-bce9-4f11-b1c8-80ba1eb76904", false, "ferkoberko@gmail.com" },
                    { "d6d3fe22-589c-4db6-b09b-ed2ac7ece8df", 0, "b278d6a6-83f0-452a-888b-3d4c82852719", "FoodUser", null, true, "Béla", "kisbela@gmail.com", "Kiss", false, null, null, "KISBELA@GMAIL.COM", "AQAAAAEAACcQAAAAEP3I/Yx6n8tStsV2qhQsfk4ALcBUdhJw26C6iw7OK/+KhGygyhJX4p3pbL/GfZC/mA==", null, false, "132fb752-f12c-4c13-9ddd-f48227ac102f", false, "kisbela@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "4a487250-4db7-4b0d-a6c5-6816f031864b", "Dark", "4", "Choko" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ContractorId", "RequestId", "Text" },
                values: new object[,]
                {
                    { "3e2ccacd-12ce-4867-b9d4-b70e877ee540", "8b925fca-7c7f-463d-a591-1ed8babf8c98", "4", "Hello" },
                    { "91b30b3d-b283-4551-9fe9-63d10816a269", "8b925fca-7c7f-463d-a591-1ed8babf8c98", "3", "Hi" }
                });

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "3",
                column: "RequestorId",
                value: "71f6fd23-1412-41fc-a7a4-b5766c67fbdc");

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "4",
                column: "RequestorId",
                value: "71f6fd23-1412-41fc-a7a4-b5766c67fbdc");

            migrationBuilder.UpdateData(
                table: "Foodrequests",
                keyColumn: "Id",
                keyValue: "5",
                column: "RequestorId",
                value: "71f6fd23-1412-41fc-a7a4-b5766c67fbdc");

            migrationBuilder.InsertData(
                table: "Foodrequests",
                columns: new[] { "Id", "Description", "IsDone", "Name", "PictureContentType", "RequestorId" },
                values: new object[,]
                {
                    { "10be2a69-ca05-432b-adf2-2002b768dd49", "Nyers hal", false, "Susi", "Image/jpeg", "d6d3fe22-589c-4db6-b09b-ed2ac7ece8df" },
                    { "e3220fc5-8db1-404a-b057-1e0fb7ba8086", "Sülthus", false, "Stake", "Image/jpeg", "d6d3fe22-589c-4db6-b09b-ed2ac7ece8df" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Choosen", "ContractorId", "FoodId" },
                values: new object[,]
                {
                    { "72c9aaf6-70aa-479c-8622-d8f12eca3557", false, "8b925fca-7c7f-463d-a591-1ed8babf8c98", "3" },
                    { "ba70f1a9-e411-4829-b473-177eca63b707", false, "d6d3fe22-589c-4db6-b09b-ed2ac7ece8df", "3" },
                    { "da5c266c-9166-4af0-a00d-38f5298dd269", false, "8b925fca-7c7f-463d-a591-1ed8babf8c98", "4" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "035bbd0d-20fd-46de-823d-57b35bfd167b", "Tuna", "10be2a69-ca05-432b-adf2-2002b768dd49", "Hal" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "FoodId", "Name" },
                values: new object[] { "45b5cc18-33c1-414a-89be-857ce5918917", "Rizs", "10be2a69-ca05-432b-adf2-2002b768dd49", "Rizs" });
        }
    }
}
