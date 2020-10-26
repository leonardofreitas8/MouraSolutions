using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MouraSolutionsWeb.Migrations
{
    public partial class MigraTodosEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusPedido",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedido", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "StatusProtocolo",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusProtocolo", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    IdZona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaNome = table.Column<string>(nullable: true),
                    BairrosAtendidos = table.Column<string>(nullable: true),
                    FaixaCeps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.IdZona);
                });

            migrationBuilder.CreateTable(
                name: "Motoboy",
                columns: table => new
                {
                    MotoboyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    TeelefoneFixo = table.Column<string>(nullable: true),
                    TeelefoneCelular = table.Column<string>(nullable: true),
                    Veiculo = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ZonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoboy", x => x.MotoboyId);
                    table.ForeignKey(
                        name: "FK_Motoboy_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    PerfilCliente = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    MotoboyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Motoboy_MotoboyId",
                        column: x => x.MotoboyId,
                        principalTable: "Motoboy",
                        principalColumn: "MotoboyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Endereco = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Zona_Setor = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Nome_Contato = table.Column<string>(nullable: true),
                    Telefone_Comercial = table.Column<string>(nullable: true),
                    Telefone_Celular = table.Column<string>(nullable: true),
                    Telefone_Recado = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Obs = table.Column<string>(nullable: true),
                    Data_Registro = table.Column<DateTime>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: true),
                    DataPedidoRetirada = table.Column<DateTime>(nullable: false),
                    HorarioPedido = table.Column<DateTime>(nullable: false),
                    NomeSolicitante = table.Column<string>(nullable: true),
                    DataRetirada = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    statusPedidoId = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(nullable: true),
                    Obsercao = table.Column<string>(nullable: true),
                    ZonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_StatusPedido_statusPedidoId",
                        column: x => x.statusPedidoId,
                        principalTable: "StatusPedido",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePaciente = table.Column<string>(nullable: true),
                    Protocolo = table.Column<string>(nullable: true),
                    ConfMoto = table.Column<string>(nullable: true),
                    ConfClinica = table.Column<string>(nullable: true),
                    ConfEscritorio = table.Column<string>(nullable: true),
                    Tma = table.Column<DateTime>(nullable: false),
                    Obs = table.Column<string>(nullable: true),
                    statusProtocolo = table.Column<int>(nullable: false),
                    StatusIdStatus = table.Column<int>(nullable: true),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_StatusProtocolo_StatusIdStatus",
                        column: x => x.StatusIdStatus,
                        principalTable: "StatusProtocolo",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_MotoboyId",
                table: "Cliente",
                column: "MotoboyId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteID",
                table: "Endereco",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Motoboy_ZonaId",
                table: "Motoboy",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PedidoId",
                table: "Paciente",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_StatusIdStatus",
                table: "Paciente",
                column: "StatusIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ZonaId",
                table: "Pedido",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_statusPedidoId",
                table: "Pedido",
                column: "statusPedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "StatusProtocolo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "StatusPedido");

            migrationBuilder.DropTable(
                name: "Motoboy");

            migrationBuilder.DropTable(
                name: "Zona");
        }
    }
}
