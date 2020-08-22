using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoriaCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estadoListaPrecios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoListaPrecios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estadoPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    eCommerce = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoListaPrecio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoListaPrecio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "listaPrecios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    EstadpListaPreciosId = table.Column<int>(nullable: false),
                    EstadoListaPreciosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listaPrecios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listaPrecios_estadoListaPrecios_EstadoListaPreciosId",
                        column: x => x.EstadoListaPreciosId,
                        principalTable: "estadoListaPrecios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    ProvinciaId = table.Column<int>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    eCommerce = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoriaClienteTipoListaPrecio",
                columns: table => new
                {
                    CategoriaClienteId = table.Column<int>(nullable: false),
                    TipoListaPrecioId = table.Column<int>(nullable: false),
                    habilitada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaClienteTipoListaPrecio", x => new { x.CategoriaClienteId, x.TipoListaPrecioId });
                    table.ForeignKey(
                        name: "FK_categoriaClienteTipoListaPrecio_categoriaCliente_CategoriaClienteId",
                        column: x => x.CategoriaClienteId,
                        principalTable: "categoriaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriaClienteTipoListaPrecio_tipoListaPrecio_TipoListaPrecioId",
                        column: x => x.TipoListaPrecioId,
                        principalTable: "tipoListaPrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "presentacionProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    unidades = table.Column<double>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presentacionProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_presentacionProducto_unidad_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "domicilio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calle = table.Column<string>(nullable: false),
                    numero = table.Column<int>(nullable: false),
                    manzana = table.Column<string>(nullable: true),
                    piso = table.Column<string>(nullable: true),
                    codigoPostal = table.Column<string>(nullable: true),
                    latitud = table.Column<string>(nullable: true),
                    DepartamentoId = table.Column<int>(nullable: true),
                    ProvinciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domicilio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_domicilio_departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_domicilio_provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productoPresentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    PresentacionProductoId = table.Column<int>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    costo = table.Column<double>(nullable: false),
                    esFormulado = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productoPresentaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productoPresentaciones_presentacionProducto_PresentacionProductoId",
                        column: x => x.PresentacionProductoId,
                        principalTable: "presentacionProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(nullable: false),
                    nombreComercial = table.Column<string>(nullable: true),
                    cuit = table.Column<string>(nullable: true),
                    habilitado = table.Column<bool>(nullable: false),
                    saldoCC = table.Column<float>(nullable: false),
                    DomicilioId = table.Column<int>(nullable: true),
                    CategoriaClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientes_categoriaCliente_CategoriaClienteId",
                        column: x => x.CategoriaClienteId,
                        principalTable: "categoriaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_clientes_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    observaciones = table.Column<string>(nullable: true),
                    DomicilioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrega_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    DomicilioId = table.Column<int>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    numeroCelular = table.Column<string>(nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    trabajaFeriado = table.Column<bool>(nullable: false),
                    eCommerce = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendedor_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalleListaPrecios",
                columns: table => new
                {
                    ListaPreciosId = table.Column<int>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false),
                    precioCosto = table.Column<double>(nullable: false),
                    porcentajeRentabilidad = table.Column<double>(nullable: false),
                    porcentajeDescuento = table.Column<double>(nullable: false),
                    cantidadMinima = table.Column<int>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
                    precioUnitarioNeto = table.Column<double>(nullable: false),
                    precioUnitarioFinal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleListaPrecios", x => new { x.ListaPreciosId, x.ProductoPresentacionId });
                    table.ForeignKey(
                        name: "FK_detalleListaPrecios_listaPrecios_ListaPreciosId",
                        column: x => x.ListaPreciosId,
                        principalTable: "listaPrecios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleListaPrecios_productoPresentaciones_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "productoPresentaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    EstadoPedidoId = table.Column<int>(nullable: false),
                    EntregaId = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false),
                    ListaPreciosId = table.Column<int>(nullable: false),
                    enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_entrega_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "entrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_estadoPedido_EstadoPedidoId",
                        column: x => x.EstadoPedidoId,
                        principalTable: "estadoPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_listaPrecios_ListaPreciosId",
                        column: x => x.ListaPreciosId,
                        principalTable: "listaPrecios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedorDepartamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    entregaLunes = table.Column<bool>(nullable: false),
                    entregaMartes = table.Column<bool>(nullable: false),
                    entregaMiercoles = table.Column<bool>(nullable: false),
                    entregaJueves = table.Column<bool>(nullable: false),
                    entregaViernes = table.Column<bool>(nullable: false),
                    entregaSabado = table.Column<bool>(nullable: false),
                    entregaDomingo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedorDepartamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendedorDepartamento_departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendedorDepartamento_vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detallePedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    precioUnitario = table.Column<double>(nullable: false),
                    descuento = table.Column<double>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePedido_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallePedido_productoPresentaciones_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "productoPresentaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_categoriaClienteTipoListaPrecio_TipoListaPrecioId",
                table: "categoriaClienteTipoListaPrecio",
                column: "TipoListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_CategoriaClienteId",
                table: "clientes",
                column: "CategoriaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_DomicilioId",
                table: "clientes",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_ProvinciaId",
                table: "departamento",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleListaPrecios_ProductoPresentacionId",
                table: "detalleListaPrecios",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_PedidoId",
                table: "detallePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_ProductoPresentacionId",
                table: "detallePedido",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_domicilio_DepartamentoId",
                table: "domicilio",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_domicilio_ProvinciaId",
                table: "domicilio",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_DomicilioId",
                table: "entrega",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_listaPrecios_EstadoListaPreciosId",
                table: "listaPrecios",
                column: "EstadoListaPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_EntregaId",
                table: "pedido",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_EstadoPedidoId",
                table: "pedido",
                column: "EstadoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ListaPreciosId",
                table: "pedido",
                column: "ListaPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_VendedorId",
                table: "pedido",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_presentacionProducto_UnidadId",
                table: "presentacionProducto",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_productoPresentaciones_PresentacionProductoId",
                table: "productoPresentaciones",
                column: "PresentacionProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedor_DomicilioId",
                table: "vendedor",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedorDepartamento_DepartamentoId",
                table: "vendedorDepartamento",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedorDepartamento_VendedorId",
                table: "vendedorDepartamento",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "categoriaClienteTipoListaPrecio");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "detalleListaPrecios");

            migrationBuilder.DropTable(
                name: "detallePedido");

            migrationBuilder.DropTable(
                name: "vendedorDepartamento");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tipoListaPrecio");

            migrationBuilder.DropTable(
                name: "categoriaCliente");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "productoPresentaciones");

            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropTable(
                name: "estadoPedido");

            migrationBuilder.DropTable(
                name: "listaPrecios");

            migrationBuilder.DropTable(
                name: "vendedor");

            migrationBuilder.DropTable(
                name: "presentacionProducto");

            migrationBuilder.DropTable(
                name: "estadoListaPrecios");

            migrationBuilder.DropTable(
                name: "domicilio");

            migrationBuilder.DropTable(
                name: "unidad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "provincias");
        }
    }
}
