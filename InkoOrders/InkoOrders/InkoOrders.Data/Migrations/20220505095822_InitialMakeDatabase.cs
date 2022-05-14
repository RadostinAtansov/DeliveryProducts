using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class InitialMakeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PredicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Payments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipientVATNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientIdentifyNomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipientAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipientNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipientTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistributorCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorVATNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorIdentifyNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriotion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvancePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatetimeOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatetimeArrive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRegistryNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportAndTransactionPayments",
                columns: table => new
                {
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    TransactionPaymentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportAndTransactionPayments", x => new { x.TransportId, x.TransactionPaymentsId });
                    table.ForeignKey(
                        name: "FK_TransportAndTransactionPayments_TransactionPayments_TransactionPaymentsId",
                        column: x => x.TransactionPaymentsId,
                        principalTable: "TransactionPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportAndTransactionPayments_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientTransactions",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TrasactionPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransactions", x => new { x.ClientId, x.TrasactionPaymentId });
                    table.ForeignKey(
                        name: "FK_ClientTransactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_TransactionPayments_TrasactionPaymentId",
                        column: x => x.TrasactionPaymentId,
                        principalTable: "TransactionPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryClients", x => new { x.DeliveryId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_DeliveryClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryClients_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryClients_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderTimeout = table.Column<int>(type: "int", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportClients", x => new { x.ClientId, x.TransportId });
                    table.ForeignKey(
                        name: "FK_TransportClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportClients_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => new { x.OrderId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    TransportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductsToDeliveryToOrderToTransports",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    TransactionPaymentId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsToDeliveryToOrderToTransports", x => new { x.OrderId, x.DeliveryId, x.ClientId, x.TransactionPaymentId, x.TransportId });
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_TransactionPayments_TransactionPaymentId",
                        column: x => x.TransactionPaymentId,
                        principalTable: "TransactionPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_ClientId",
                table: "ClientOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_InvoiceId",
                table: "Clients",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_TrasactionPaymentId",
                table: "ClientTransactions",
                column: "TrasactionPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClients_ClientId",
                table: "DeliveryClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryClients_TransportId",
                table: "DeliveryClients",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_TransportId",
                table: "Document",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TransportId",
                table: "Products",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToDeliveryToOrderToTransports_ClientId",
                table: "ProductsToDeliveryToOrderToTransports",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToDeliveryToOrderToTransports_DeliveryId",
                table: "ProductsToDeliveryToOrderToTransports",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToDeliveryToOrderToTransports_ProductId",
                table: "ProductsToDeliveryToOrderToTransports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToDeliveryToOrderToTransports_TransactionPaymentId",
                table: "ProductsToDeliveryToOrderToTransports",
                column: "TransactionPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToDeliveryToOrderToTransports_TransportId",
                table: "ProductsToDeliveryToOrderToTransports",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportAndTransactionPayments_TransactionPaymentsId",
                table: "TransportAndTransactionPayments",
                column: "TransactionPaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportClients_TransportId",
                table: "TransportClients",
                column: "TransportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "DeliveryClients");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ProductsToDeliveryToOrderToTransports");

            migrationBuilder.DropTable(
                name: "TransportAndTransactionPayments");

            migrationBuilder.DropTable(
                name: "TransportClients");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionPayments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
