using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    public partial class allInOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BuyedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insignificant = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceInStorageAndCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PredicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Payments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllExpences = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromStocks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromServices = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientCompanyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RecipientVATNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientIdentifyNomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecipientAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientNames = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RecipientTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistributorCompanyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DistributorVATNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorIdentifyNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistributorNames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistributorTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsInInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quаntity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceInStorageAndCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInInko = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insignificant = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsInInko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HowManyProductsOrderedByPosition = table.Column<int>(type: "int", nullable: false),
                    Arrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArrivedQuantityAndProductsFromOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChangeStatusChangeDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterOrderForProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNameAndCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishhOrderDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendOrderDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WayBill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOrder = table.Column<int>(type: "int", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderTimeout = table.Column<int>(type: "int", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterOrderForProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolCreatedByInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<bool>(type: "bit", nullable: false),
                    CreatedFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeWhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insignificant = table.Column<bool>(type: "bit", nullable: false),
                    PlaceInStorageAndCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolCreatedByInko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TooldBoughtByInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bought = table.Column<bool>(type: "bit", nullable: false),
                    BoughtFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeBought = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insignificant = table.Column<bool>(type: "bit", nullable: false),
                    PlaceInStorageAndCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TooldBoughtByInko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriotion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvancePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
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
                    FromCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DatetimeOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatetimeArrive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilityBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Electricity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stocks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Transport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Customs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoPerformars = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaresInko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActiveOrOld = table.Column<bool>(type: "bit", nullable: false),
                    TimeActiveAndHowOld = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Insignificant = table.Column<bool>(type: "bit", nullable: false),
                    PlaceInStorageAndCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaresInko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DistributorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRegistryNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                name: "Documents",
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Transports_TransportId",
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
                name: "BankIncomeExpencesUtilitiBills",
                columns: table => new
                {
                    BankPaymentsId = table.Column<int>(type: "int", nullable: false),
                    IncomeId = table.Column<int>(type: "int", nullable: false),
                    UtilityBillsId = table.Column<int>(type: "int", nullable: false),
                    ExpencesId = table.Column<int>(type: "int", nullable: false),
                    TransactionPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankIncomeExpencesUtilitiBills", x => new { x.IncomeId, x.BankPaymentsId, x.UtilityBillsId, x.ExpencesId });
                    table.ForeignKey(
                        name: "FK_BankIncomeExpencesUtilitiBills_BankPayments_BankPaymentsId",
                        column: x => x.BankPaymentsId,
                        principalTable: "BankPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankIncomeExpencesUtilitiBills_Expences_ExpencesId",
                        column: x => x.ExpencesId,
                        principalTable: "Expences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankIncomeExpencesUtilitiBills_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankIncomeExpencesUtilitiBills_TransactionPayments_TransactionPaymentId",
                        column: x => x.TransactionPaymentId,
                        principalTable: "TransactionPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankIncomeExpencesUtilitiBills_UtilityBills_UtilityBillsId",
                        column: x => x.UtilityBillsId,
                        principalTable: "UtilityBills",
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
                        name: "FK_ClientOrders_RegisterOrderForProductions_OrderId",
                        column: x => x.OrderId,
                        principalTable: "RegisterOrderForProductions",
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    RegisterOrderForProductionId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Products_RegisterOrderForProductions_RegisterOrderForProductionId",
                        column: x => x.RegisterOrderForProductionId,
                        principalTable: "RegisterOrderForProductions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id");
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
                        name: "FK_ProductsToDeliveryToOrderToTransports_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsToDeliveryToOrderToTransports_RegisterOrderForProductions_OrderId",
                        column: x => x.OrderId,
                        principalTable: "RegisterOrderForProductions",
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
                name: "IX_BankIncomeExpencesUtilitiBills_BankPaymentsId",
                table: "BankIncomeExpencesUtilitiBills",
                column: "BankPaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_BankIncomeExpencesUtilitiBills_ExpencesId",
                table: "BankIncomeExpencesUtilitiBills",
                column: "ExpencesId");

            migrationBuilder.CreateIndex(
                name: "IX_BankIncomeExpencesUtilitiBills_TransactionPaymentId",
                table: "BankIncomeExpencesUtilitiBills",
                column: "TransactionPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_BankIncomeExpencesUtilitiBills_UtilityBillsId",
                table: "BankIncomeExpencesUtilitiBills",
                column: "UtilityBillsId");

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
                name: "IX_Documents_TransportId",
                table: "Documents",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClientId",
                table: "Products",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RegisterOrderForProductionId",
                table: "Products",
                column: "RegisterOrderForProductionId");

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
                name: "BankIncomeExpencesUtilitiBills");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "DeliveryClients");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "MaterialsInInko");

            migrationBuilder.DropTable(
                name: "ProductsToDeliveryToOrderToTransports");

            migrationBuilder.DropTable(
                name: "ProviderOrders");

            migrationBuilder.DropTable(
                name: "ToolCreatedByInko");

            migrationBuilder.DropTable(
                name: "TooldBoughtByInko");

            migrationBuilder.DropTable(
                name: "TransportAndTransactionPayments");

            migrationBuilder.DropTable(
                name: "TransportClients");

            migrationBuilder.DropTable(
                name: "WaresInko");

            migrationBuilder.DropTable(
                name: "BankPayments");

            migrationBuilder.DropTable(
                name: "Expences");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "UtilityBills");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionPayments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "RegisterOrderForProductions");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
