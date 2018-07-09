using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProyectoW1.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canton",
                columns: table => new
                {
                    IDCanton = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodCanton = table.Column<int>(nullable: true),
                    IDProvicia = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canton", x => x.IDCanton);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    IDdistrito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodDistrito = table.Column<int>(nullable: true),
                    IDCanton = table.Column<int>(nullable: true),
                    IDProvicia = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.IDdistrito);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    IDEntidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.IDEntidad);
                });

            migrationBuilder.CreateTable(
                name: "NivelAcademico",
                columns: table => new
                {
                    IDNivel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcademico", x => x.IDNivel);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    IDProvincia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.IDProvincia);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    IDEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.IDEvento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    IDTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.IDTipo);
                });

            migrationBuilder.CreateTable(
                name: "Tema",
                columns: table => new
                {
                    IDTema = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IDTipo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.IDTema);
                    table.ForeignKey(
                        name: "FK_Tema_TipoEvento",
                        column: x => x.IDTipo,
                        principalTable: "TipoEvento",
                        principalColumn: "IDEvento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido1 = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Apellido2 = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Clave = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: true),
                    IDEntidad = table.Column<int>(nullable: true),
                    IDNivel = table.Column<int>(nullable: true),
                    IDTipo = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Usuario = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Entidad",
                        column: x => x.IDEntidad,
                        principalTable: "Entidad",
                        principalColumn: "IDEntidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_NivelAC",
                        column: x => x.IDNivel,
                        principalTable: "NivelAcademico",
                        principalColumn: "IDNivel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario",
                        column: x => x.IDTipo,
                        principalTable: "TipoUsuario",
                        principalColumn: "IDTipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    IDContacto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identificador = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    IDUsuario = table.Column<int>(nullable: true),
                    TipoContacto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.IDContacto);
                    table.ForeignKey(
                        name: "FK_Contacto_Usuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    IDUbicacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDCanton = table.Column<int>(nullable: true),
                    IDDistrito = table.Column<int>(nullable: true),
                    IDEvento = table.Column<int>(nullable: true),
                    IDProvincia = table.Column<int>(nullable: true),
                    Lugar = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.IDUbicacion);
                    table.ForeignKey(
                        name: "FK_Ubica_Canton",
                        column: x => x.IDCanton,
                        principalTable: "Canton",
                        principalColumn: "IDCanton",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ubica_Distrito",
                        column: x => x.IDDistrito,
                        principalTable: "Distrito",
                        principalColumn: "IDdistrito",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ubica_provincia",
                        column: x => x.IDProvincia,
                        principalTable: "Provincia",
                        principalColumn: "IDProvincia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    IDEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calificacion = table.Column<int>(nullable: true),
                    Estado = table.Column<int>(nullable: true),
                    FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDExpositor = table.Column<int>(nullable: true),
                    IDTema = table.Column<int>(nullable: true),
                    IDTipoEvento = table.Column<int>(nullable: true),
                    IDUbicacion = table.Column<int>(nullable: true),
                    Limite = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.IDEvento);
                    table.ForeignKey(
                        name: "FK_Evento_Usuario",
                        column: x => x.IDExpositor,
                        principalTable: "Usuario",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Tema",
                        column: x => x.IDTema,
                        principalTable: "Tema",
                        principalColumn: "IDTema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Ubica",
                        column: x => x.IDUbicacion,
                        principalTable: "Ubicacion",
                        principalColumn: "IDUbicacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    IDCalifiacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calificacion = table.Column<int>(nullable: true),
                    Comentario = table.Column<string>(unicode: false, maxLength: 1500, nullable: true),
                    IDEvento = table.Column<int>(nullable: true),
                    IDUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.IDCalifiacion);
                    table.ForeignKey(
                        name: "FK_Calificacion_Evento",
                        column: x => x.IDEvento,
                        principalTable: "Evento",
                        principalColumn: "IDEvento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificacion_Usuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IDReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Confirma = table.Column<int>(nullable: true),
                    IDEvento = table.Column<int>(nullable: true),
                    IDUsuario = table.Column<int>(nullable: true),
                    Reserva = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IDReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Evento",
                        column: x => x.IDEvento,
                        principalTable: "Evento",
                        principalColumn: "IDEvento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_IDEvento",
                table: "Calificacion",
                column: "IDEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_IDUsuario",
                table: "Calificacion",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IDUsuario",
                table: "Contacto",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IDExpositor",
                table: "Evento",
                column: "IDExpositor");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IDTema",
                table: "Evento",
                column: "IDTema");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IDUbicacion",
                table: "Evento",
                column: "IDUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDEvento",
                table: "Reserva",
                column: "IDEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IDUsuario",
                table: "Reserva",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tema_IDTipo",
                table: "Tema",
                column: "IDTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IDCanton",
                table: "Ubicacion",
                column: "IDCanton");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IDDistrito",
                table: "Ubicacion",
                column: "IDDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IDEvento",
                table: "Ubicacion",
                column: "IDEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicacion_IDProvincia",
                table: "Ubicacion",
                column: "IDProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IDEntidad",
                table: "Usuario",
                column: "IDEntidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IDNivel",
                table: "Usuario",
                column: "IDNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IDTipo",
                table: "Usuario",
                column: "IDTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ubica_Evento",
                table: "Ubicacion",
                column: "IDEvento",
                principalTable: "Evento",
                principalColumn: "IDEvento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubica_Evento",
                table: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Tema");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "NivelAcademico");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "Canton");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
