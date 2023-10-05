using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ciudad_departamento_IdDepartamentoFk",
                table: "ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_departamento_pais_IdpaisFk",
                table: "departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pais",
                table: "pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departamento",
                table: "departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ciudad",
                table: "ciudad");

            migrationBuilder.RenameTable(
                name: "pais",
                newName: "Pais");

            migrationBuilder.RenameTable(
                name: "departamento",
                newName: "Departamento");

            migrationBuilder.RenameTable(
                name: "ciudad",
                newName: "Ciudad");

            migrationBuilder.RenameColumn(
                name: "IdpaisFk",
                table: "Departamento",
                newName: "IdPaisFk");

            migrationBuilder.RenameIndex(
                name: "IX_departamento_IdpaisFk",
                table: "Departamento",
                newName: "IX_Departamento_IdPaisFk");

            migrationBuilder.RenameIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "Ciudad",
                newName: "IX_Ciudad_IdDepartamentoFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClienteDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoDeVia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroPri = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bis = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LetraSec = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cardinal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroSec = table.Column<int>(type: "int", nullable: false),
                    LetraTer = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroTer = table.Column<int>(type: "int", nullable: false),
                    CardinalSec = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteDireccion_Ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteDireccion_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClienteTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTelefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteTelefono_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRazaFk = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_IdRazaFk",
                        column: x => x.IdRazaFk,
                        principalTable: "Raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdMascotaFk = table.Column<int>(type: "int", nullable: false),
                    IdServicioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Mascota_IdMascotaFk",
                        column: x => x.IdMascotaFk,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Servicio_IdServicioFk",
                        column: x => x.IdServicioFk,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdClienteFk",
                table: "Cita",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMascotaFk",
                table: "Cita",
                column: "IdMascotaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdServicioFk",
                table: "Cita",
                column: "IdServicioFk");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccion_IdCiudadFk",
                table: "ClienteDireccion",
                column: "IdCiudadFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccion_IdClienteFk",
                table: "ClienteDireccion",
                column: "IdClienteFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClienteTelefono_IdClienteFk",
                table: "ClienteTelefono",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdClienteFk",
                table: "Mascota",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdRazaFk",
                table: "Mascota",
                column: "IdRazaFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamentoFk",
                table: "Ciudad",
                column: "IdDepartamentoFk",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_IdPaisFk",
                table: "Departamento",
                column: "IdPaisFk",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamentoFk",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_IdPaisFk",
                table: "Departamento");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "ClienteDireccion");

            migrationBuilder.DropTable(
                name: "ClienteTelefono");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad");

            migrationBuilder.RenameTable(
                name: "Pais",
                newName: "pais");

            migrationBuilder.RenameTable(
                name: "Departamento",
                newName: "departamento");

            migrationBuilder.RenameTable(
                name: "Ciudad",
                newName: "ciudad");

            migrationBuilder.RenameColumn(
                name: "IdPaisFk",
                table: "departamento",
                newName: "IdpaisFk");

            migrationBuilder.RenameIndex(
                name: "IX_Departamento_IdPaisFk",
                table: "departamento",
                newName: "IX_departamento_IdpaisFk");

            migrationBuilder.RenameIndex(
                name: "IX_Ciudad_IdDepartamentoFk",
                table: "ciudad",
                newName: "IX_ciudad_IdDepartamentoFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pais",
                table: "pais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departamento",
                table: "departamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ciudad",
                table: "ciudad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ciudad_departamento_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk",
                principalTable: "departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departamento_pais_IdpaisFk",
                table: "departamento",
                column: "IdpaisFk",
                principalTable: "pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
