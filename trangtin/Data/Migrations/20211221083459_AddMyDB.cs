using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trangtin.Data.Migrations
{
    public partial class AddMyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chuyenmuc",
                columns: table => new
                {
                    chuyenmucid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenchuyenmuc = table.Column<string>(nullable: false),
                    thutu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuyenmuc", x => x.chuyenmucid);
                });

            migrationBuilder.CreateTable(
                name: "chude",
                columns: table => new
                {
                    chudeid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenchude = table.Column<string>(nullable: false),
                    chuyenmucid = table.Column<int>(nullable: false),
                    thutu = table.Column<int>(nullable: false),
                    kichhoat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chude", x => x.chudeid);
                    table.ForeignKey(
                        name: "FK_chude_chuyenmuc_chuyenmucid",
                        column: x => x.chuyenmucid,
                        principalTable: "chuyenmuc",
                        principalColumn: "chuyenmucid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bantin",
                columns: table => new
                {
                    bantinid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chudeid = table.Column<int>(nullable: false),
                    tieude = table.Column<string>(nullable: false),
                    tomtat = table.Column<string>(nullable: false),
                    noidung = table.Column<string>(nullable: false),
                    ngaydang = table.Column<DateTime>(nullable: false),
                    nguoidang = table.Column<string>(nullable: true),
                    hinhanh = table.Column<string>(nullable: true),
                    tieudehinh = table.Column<string>(nullable: true),
                    luotxem = table.Column<int>(nullable: false),
                    noibat = table.Column<bool>(nullable: false),
                    kichhoat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bantin", x => x.bantinid);
                    table.ForeignKey(
                        name: "FK_bantin_chude_chudeid",
                        column: x => x.chudeid,
                        principalTable: "chude",
                        principalColumn: "chudeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bantin_chudeid",
                table: "bantin",
                column: "chudeid");

            migrationBuilder.CreateIndex(
                name: "IX_chude_chuyenmucid",
                table: "chude",
                column: "chuyenmucid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bantin");

            migrationBuilder.DropTable(
                name: "chude");

            migrationBuilder.DropTable(
                name: "chuyenmuc");
        }
    }
}
