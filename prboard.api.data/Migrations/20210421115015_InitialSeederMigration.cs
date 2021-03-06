using System;
using Microsoft.EntityFrameworkCore.Migrations;
using prboard.api.data.Files.Enums;
using prboard.api.data.Users.Enums;

namespace prboard.api.data.Migrations
{
    public partial class InitialSeederMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StripeAccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Type", "SystemName"},
                values: new object[]
                {
                    1, new Guid("1425f15b-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null, (int) FileType.Image,
                    "image"
                }
            );

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Type", "SystemName"},
                values: new object[]
                {
                    2, new Guid("2425f15b-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null, (int) FileType.Zip,
                    "zip"
                }
            );

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Type", "SystemName"},
                values: new object[]
                {
                    3, new Guid("3425f15b-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null, (int) FileType.Pdf,
                    "pdf"
                }
            );

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Type", "SystemName"},
                values: new object[]
                {
                    4, new Guid("4425f15b-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null, (int) FileType.Video,
                    "video"
                }
            );

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[]
                    {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Type"},
                values: new object[]
                {
                    1, new Guid("4125f111-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null,
                    "Individual", (int) UserType.Individual
                }
            );

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[]
                    {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Type"},
                values: new object[]
                {
                    2, new Guid("4225f111-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null,
                    "Business", (int) UserType.Business
                }
            );
            
            SeedCountries(migrationBuilder);
        }

        private void SeedCountries(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    1, new Guid("111e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Afghanistan", "af",
                    "afg"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    2, new Guid("112e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Åland Islands",
                    "ax", "ala"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    3, new Guid("113e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Albania", "al",
                    "alb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    4, new Guid("114e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Algeria", "dz",
                    "dza"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    5, new Guid("115e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "American Samoa",
                    "as", "asm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    6, new Guid("116e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Andorra", "ad",
                    "and"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    7, new Guid("117e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Angola", "ao", "ago"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    8, new Guid("118e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Anguilla", "ai",
                    "aia"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    9, new Guid("119e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Antarctica", "aq",
                    "ata"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    10, new Guid("121e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Antigua and Barbuda", "ag", "atg"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    11, new Guid("122e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Argentina", "ar",
                    "arg"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    12, new Guid("123e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Armenia", "am",
                    "arm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    13, new Guid("124e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Aruba", "aw", "abw"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    14, new Guid("125e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Australia", "au",
                    "aus"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    15, new Guid("126e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Austria", "at",
                    "aut"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    16, new Guid("127e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Azerbaijan", "az",
                    "aze"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    17, new Guid("128e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bahamas", "bs",
                    "bhs"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    18, new Guid("129e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bahrain", "bh",
                    "bhr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    19, new Guid("130e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bangladesh", "bd",
                    "bgd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    20, new Guid("131e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Barbados", "bb",
                    "brb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    21, new Guid("132e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Belarus", "by",
                    "blr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    22, new Guid("133e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Belgium", "be",
                    "bel"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    23, new Guid("134e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Belize", "bz",
                    "blz"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    24, new Guid("135e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Benin", "bj", "ben"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    25, new Guid("136e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bermuda", "bm",
                    "bmu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    26, new Guid("137e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bhutan", "bt",
                    "btn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    27, new Guid("138e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Bolivia (Plurinational State of)", "bo", "bol"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    28, new Guid("139e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Bonaire, Sint Eustatius and Saba", "bq", "bes"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    29, new Guid("140e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Bosnia and Herzegovina", "ba", "bih"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    30, new Guid("141e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Botswana", "bw",
                    "bwa"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    31, new Guid("142e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bouvet Island",
                    "bv", "bvt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    32, new Guid("143e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Brazil", "br",
                    "bra"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    33, new Guid("144e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "British Indian Ocean Territory", "io", "iot"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    34, new Guid("145e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Brunei Darussalam",
                    "bn", "brn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    35, new Guid("146e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Bulgaria", "bg",
                    "bgr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    36, new Guid("147e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Burkina Faso",
                    "bf", "bfa"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    37, new Guid("148e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Burundi", "bi",
                    "bdi"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    38, new Guid("149e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cabo Verde", "cv",
                    "cpv"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    39, new Guid("150e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cambodia", "kh",
                    "khm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    40, new Guid("151e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cameroon", "cm",
                    "cmr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    41, new Guid("152e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Canada", "ca",
                    "can"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    42, new Guid("153e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cayman Islands",
                    "ky", "cym"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    43, new Guid("154e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Central African Republic", "cf", "caf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    44, new Guid("155e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Chad", "td", "tcd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    45, new Guid("156e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Chile", "cl", "chl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    46, new Guid("157e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "China", "cn", "chn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    47, new Guid("158e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Christmas Island",
                    "cx", "cxr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    48, new Guid("159e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Cocos (Keeling) Islands", "cc", "cck"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    49, new Guid("160e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Colombia", "co",
                    "col"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    50, new Guid("161e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Comoros", "km",
                    "com"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    51, new Guid("162e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Congo", "cg", "cog"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    52, new Guid("163e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Congo, Democratic Republic of the", "cd", "cod"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    53, new Guid("164e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cook Islands",
                    "ck", "cok"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    54, new Guid("165e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Costa Rica", "cr",
                    "cri"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    55, new Guid("166e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Côte d'Ivoire",
                    "ci", "civ"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    56, new Guid("167e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Croatia", "hr",
                    "hrv"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    57, new Guid("168e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cuba", "cu", "cub"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    58, new Guid("169e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Curaçao", "cw",
                    "cuw"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    59, new Guid("170e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Cyprus", "cy",
                    "cyp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    60, new Guid("171e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Czechia", "cz",
                    "cze"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    61, new Guid("172e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Denmark", "dk",
                    "dnk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    62, new Guid("173e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Djibouti", "dj",
                    "dji"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    63, new Guid("174e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Dominica", "dm",
                    "dma"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    64, new Guid("175e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Dominican Republic", "do", "dom"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    65, new Guid("176e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Ecuador", "ec",
                    "ecu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    66, new Guid("177e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Egypt", "eg", "egy"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    67, new Guid("178e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "El Salvador", "sv",
                    "slv"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    68, new Guid("179e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Equatorial Guinea",
                    "gq", "gnq"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    69, new Guid("180e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Eritrea", "er",
                    "eri"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    70, new Guid("181e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Estonia", "ee",
                    "est"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    71, new Guid("182e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Eswatini", "sz",
                    "swz"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    72, new Guid("183e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Ethiopia", "et",
                    "eth"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    73, new Guid("184e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Falkland Islands (Malvinas)", "fk", "flk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    74, new Guid("185e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Faroe Islands",
                    "fo", "fro"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    75, new Guid("186e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Fiji", "fj", "fji"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    76, new Guid("187e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Finland", "fi",
                    "fin"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    77, new Guid("188e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "France", "fr",
                    "fra"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    78, new Guid("189e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "French Guiana",
                    "gf", "guf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    79, new Guid("190e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "French Polynesia",
                    "pf", "pyf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    80, new Guid("191e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "French Southern Territories", "tf", "atf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    81, new Guid("192e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Gabon", "ga", "gab"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    82, new Guid("193e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Gambia", "gm",
                    "gmb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    83, new Guid("194e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Georgia", "ge",
                    "geo"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    84, new Guid("195e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Germany", "de",
                    "deu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    85, new Guid("196e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Ghana", "gh",
                    "gha"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    86, new Guid("197e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Gibraltar", "gi",
                    "gib"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    87, new Guid("198e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Greece", "gr",
                    "grc"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    88, new Guid("199e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Greenland", "gl",
                    "grl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    89, new Guid("200e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Grenada", "gd",
                    "grd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    90, new Guid("201e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guadeloupe", "gp",
                    "glp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    91, new Guid("202e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guam", "gu", "gum"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    92, new Guid("203e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guatemala", "gt",
                    "gtm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    93, new Guid("204e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guernsey", "gg",
                    "ggy"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    94, new Guid("205e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guinea", "gn",
                    "gin"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    95, new Guid("206e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guinea-Bissau",
                    "gw", "gnb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    96, new Guid("207e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Guyana", "gy",
                    "guy"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    97, new Guid("208e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Haiti", "ht", "hti"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    98, new Guid("209e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Heard Island and McDonald Islands", "hm", "hmd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    99, new Guid("210e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Holy See", "va",
                    "vat"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    100, new Guid("211e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Honduras", "hn",
                    "hnd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    101, new Guid("212e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Hong Kong", "hk",
                    "hkg"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    102, new Guid("213e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Hungary", "hu",
                    "hun"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    103, new Guid("214e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Iceland", "is",
                    "isl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    104, new Guid("215e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "India", "in",
                    "ind"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    105, new Guid("216e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Indonesia", "id",
                    "idn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    106, new Guid("217e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Iran (Islamic Republic of)", "ir", "irn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    107, new Guid("218e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Iraq", "iq", "irq"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    108, new Guid("219e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Ireland", "ie",
                    "irl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    109, new Guid("220e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Isle of Man",
                    "im", "imn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    110, new Guid("221e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Israel", "il",
                    "isr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    111, new Guid("222e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Italy", "it",
                    "ita"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    112, new Guid("223e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Jamaica", "jm",
                    "jam"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    113, new Guid("224e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Japan", "jp",
                    "jpn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    114, new Guid("225e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Jersey", "je",
                    "jey"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    115, new Guid("226e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Jordan", "jo",
                    "jor"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    116, new Guid("227e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Kazakhstan", "kz",
                    "kaz"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    117, new Guid("228e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Kenya", "ke",
                    "ken"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    118, new Guid("229e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Kiribati", "ki",
                    "kir"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    119, new Guid("230e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Korea (Democratic People's Republic of)", "kp", "prk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    120, new Guid("231e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Korea, Republic of", "kr", "kor"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    121, new Guid("232e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Kuwait", "kw",
                    "kwt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    122, new Guid("233e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Kyrgyzstan", "kg",
                    "kgz"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    123, new Guid("234e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Lao People's Democratic Republic", "la", "lao"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    124, new Guid("235e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Latvia", "lv",
                    "lva"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    125, new Guid("236e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Lebanon", "lb",
                    "lbn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    126, new Guid("237e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Lesotho", "ls",
                    "lso"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    127, new Guid("238e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Liberia", "lr",
                    "lbr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    128, new Guid("239e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Libya", "ly",
                    "lby"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    129, new Guid("240e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Liechtenstein",
                    "li", "lie"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    130, new Guid("241e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Lithuania", "lt",
                    "ltu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    131, new Guid("242e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Luxembourg", "lu",
                    "lux"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    132, new Guid("243e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Macao", "mo",
                    "mac"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    133, new Guid("244e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Madagascar", "mg",
                    "mdg"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    134, new Guid("245e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Malawi", "mw",
                    "mwi"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    135, new Guid("246e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Malaysia", "my",
                    "mys"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    136, new Guid("247e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Maldives", "mv",
                    "mdv"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    137, new Guid("248e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mali", "ml", "mli"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    138, new Guid("249e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Malta", "mt",
                    "mlt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    139, new Guid("250e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Marshall Islands",
                    "mh", "mhl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    140, new Guid("251e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Martinique", "mq",
                    "mtq"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    141, new Guid("252e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mauritania", "mr",
                    "mrt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    142, new Guid("253e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mauritius", "mu",
                    "mus"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    143, new Guid("254e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mayotte", "yt",
                    "myt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    144, new Guid("255e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mexico", "mx",
                    "mex"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    145, new Guid("256e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Micronesia (Federated States of)", "fm", "fsm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    146, new Guid("257e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Moldova, Republic of", "md", "mda"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    147, new Guid("258e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Monaco", "mc",
                    "mco"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    148, new Guid("259e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mongolia", "mn",
                    "mng"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    149, new Guid("260e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Montenegro", "me",
                    "mne"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    150, new Guid("261e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Montserrat", "ms",
                    "msr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    151, new Guid("262e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Morocco", "ma",
                    "mar"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    152, new Guid("263e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Mozambique", "mz",
                    "moz"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    153, new Guid("264e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Myanmar", "mm",
                    "mmr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    154, new Guid("265e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Namibia", "na",
                    "nam"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    155, new Guid("266e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Nauru", "nr",
                    "nru"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    156, new Guid("267e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Nepal", "np",
                    "npl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    157, new Guid("268e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Netherlands",
                    "nl", "nld"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    158, new Guid("269e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "New Caledonia",
                    "nc", "ncl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    159, new Guid("270e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "New Zealand",
                    "nz", "nzl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    160, new Guid("271e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Nicaragua", "ni",
                    "nic"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    161, new Guid("272e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Niger", "ne",
                    "ner"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    162, new Guid("273e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Nigeria", "ng",
                    "nga"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    163, new Guid("274e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Niue", "nu", "niu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    164, new Guid("275e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Norfolk Island",
                    "nf", "nfk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    165, new Guid("276e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "North Macedonia",
                    "mk", "mkd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    166, new Guid("277e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Northern Mariana Islands", "mp", "mnp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    167, new Guid("278e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Norway", "no",
                    "nor"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    168, new Guid("279e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Oman", "om", "omn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    169, new Guid("280e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Pakistan", "pk",
                    "pak"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    170, new Guid("281e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Palau", "pw",
                    "plw"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    171, new Guid("282e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Palestine, State of", "ps", "pse"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    172, new Guid("283e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Panama", "pa",
                    "pan"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    173, new Guid("284e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Papua New Guinea",
                    "pg", "png"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    174, new Guid("285e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Paraguay", "py",
                    "pry"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    175, new Guid("286e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Peru", "pe", "per"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    176, new Guid("287e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Philippines",
                    "ph", "phl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    177, new Guid("288e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Pitcairn", "pn",
                    "pcn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    178, new Guid("289e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Poland", "pl",
                    "pol"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    179, new Guid("290e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Portugal", "pt",
                    "prt"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    180, new Guid("291e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Puerto Rico",
                    "pr", "pri"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    181, new Guid("292e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Qatar", "qa",
                    "qat"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    182, new Guid("293e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Réunion", "re",
                    "reu"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    183, new Guid("294e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Romania", "ro",
                    "rou"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    184, new Guid("295e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Russian Federation", "ru", "rus"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    185, new Guid("296e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Rwanda", "rw",
                    "rwa"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    186, new Guid("297e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Saint Barthélemy",
                    "bl", "blm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    187, new Guid("298e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Saint Helena, Ascension and Tristan da Cunha", "sh", "shn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    188, new Guid("299e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Saint Kitts and Nevis", "kn", "kna"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    189, new Guid("300e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Saint Lucia",
                    "lc", "lca"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    190, new Guid("301e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Saint Martin (French part)", "mf", "maf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    191, new Guid("302e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Saint Pierre and Miquelon", "pm", "spm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    192, new Guid("303e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Saint Vincent and the Grenadines", "vc", "vct"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    193, new Guid("304e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Samoa", "ws",
                    "wsm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    194, new Guid("305e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "San Marino", "sm",
                    "smr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    195, new Guid("306e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Sao Tome and Principe", "st", "stp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    196, new Guid("307e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Saudi Arabia",
                    "sa", "sau"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    197, new Guid("308e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Senegal", "sn",
                    "sen"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    198, new Guid("309e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Serbia", "rs",
                    "srb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    199, new Guid("310e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Seychelles", "sc",
                    "syc"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    200, new Guid("311e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Sierra Leone",
                    "sl", "sle"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    201, new Guid("312e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Singapore", "sg",
                    "sgp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    202, new Guid("313e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Sint Maarten (Dutch part)", "sx", "sxm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    203, new Guid("314e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Slovakia", "sk",
                    "svk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    204, new Guid("315e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Slovenia", "si",
                    "svn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    205, new Guid("316e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Solomon Islands",
                    "sb", "slb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    206, new Guid("317e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Somalia", "so",
                    "som"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    207, new Guid("318e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "South Africa",
                    "za", "zaf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    208, new Guid("319e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "South Georgia and the South Sandwich Islands", "gs", "sgs"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    209, new Guid("320e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "South Sudan",
                    "ss", "ssd"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    210, new Guid("321e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Spain", "es",
                    "esp"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    211, new Guid("322e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Sri Lanka", "lk",
                    "lka"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    212, new Guid("323e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Sudan", "sd",
                    "sdn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    213, new Guid("324e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Suriname", "sr",
                    "sur"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    214, new Guid("325e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Svalbard and Jan Mayen", "sj", "sjm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    215, new Guid("326e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Sweden", "se",
                    "swe"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    216, new Guid("327e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Switzerland",
                    "ch", "che"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    217, new Guid("328e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Syrian Arab Republic", "sy", "syr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    218, new Guid("329e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Taiwan, Province of China", "tw", "twn"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    219, new Guid("330e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Tajikistan", "tj",
                    "tjk"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    220, new Guid("331e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Tanzania, United Republic of", "tz", "tza"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    221, new Guid("332e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Thailand", "th",
                    "tha"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    222, new Guid("333e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Timor-Leste",
                    "tl", "tls"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    223, new Guid("334e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Togo", "tg", "tgo"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    224, new Guid("335e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Tokelau", "tk",
                    "tkl"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    225, new Guid("336e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Tonga", "to",
                    "ton"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    226, new Guid("337e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Trinidad and Tobago", "tt", "tto"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    227, new Guid("338e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Tunisia", "tn",
                    "tun"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    228, new Guid("339e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Turkey", "tr",
                    "tur"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    229, new Guid("340e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Turkmenistan",
                    "tm", "tkm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    230, new Guid("341e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Turks and Caicos Islands", "tc", "tca"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    231, new Guid("342e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Tuvalu", "tv",
                    "tuv"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    232, new Guid("343e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Uganda", "ug",
                    "uga"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    233, new Guid("344e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Ukraine", "ua",
                    "ukr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    234, new Guid("345e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "United Arab Emirates", "ae", "are"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    235, new Guid("346e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "United Kingdom", "gb", "gbr"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    236, new Guid("347e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "United States of America", "us", "usa"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    237, new Guid("348e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "United States Minor Outlying Islands", "um", "umi"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    238, new Guid("349e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Uruguay", "uy",
                    "ury"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    239, new Guid("350e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Uzbekistan", "uz",
                    "uzb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    240, new Guid("351e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Vanuatu", "vu",
                    "vut"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    241, new Guid("352e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Venezuela (Bolivarian Republic of)", "ve", "ven"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    242, new Guid("353e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Viet Nam", "vn",
                    "vnm"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    243, new Guid("354e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Virgin Islands (British)", "vg", "vgb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    244, new Guid("355e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Virgin Islands (U.S.)", "vi", "vir"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    245, new Guid("356e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null,
                    "Wallis and Futuna", "wf", "wlf"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    246, new Guid("357e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Western Sahara",
                    "eh", "esh"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    247, new Guid("358e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Yemen", "ye",
                    "yem"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    248, new Guid("359e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Zambia", "zm",
                    "zmb"
                });
            migrationBuilder.InsertData("Countries",
                new[] {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Alpha2", "Alpha3"},
                new object[]
                {
                    249, new Guid("360e0733-76f6-4a98-9428-23119718de6a"), DateTime.Now, null, null, "Zimbabwe", "zw",
                    "zwe"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeAccountId",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}