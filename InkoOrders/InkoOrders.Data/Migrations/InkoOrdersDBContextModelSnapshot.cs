﻿// <auto-generated />
using System;
using InkoOrders.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InkoOrders.Data.Migrations
{
    [DbContext(typeof(InkoOrdersDBContext))]
    partial class InkoOrdersDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InkoOrders.Data.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DistributorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TaxRegistryNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ClientsOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientOrders");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ClientsTransaction", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TrasactionPaymentId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "TrasactionPaymentId");

                    b.HasIndex("TrasactionPaymentId");

                    b.ToTable("ClientTransactions");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DeliveryCompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EndPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Payments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PredicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.DeliveryClient", b =>
                {
                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("DeliveryId", "ClientId");

                    b.HasIndex("ClientId");

                    b.HasIndex("TransportId");

                    b.ToTable("DeliveryClients");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DistributorAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistributorCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DistributorCompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("DistributorIdentifyNomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributorNames")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DistributorTelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributorVATNomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RecipientCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecipientCompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("RecipientIdentifyNomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientNames")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("RecipientTelephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientVATNomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Distributor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderTimeout")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId");

                    b.HasIndex("TransportId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ProductsToDeliveryToOrderToTransactionPaymentToTransport", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "DeliveryId", "ClientId", "TransactionPaymentId", "TransportId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionPaymentId");

                    b.HasIndex("TransportId");

                    b.ToTable("ProductsToDeliveryToOrderToTransports");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Storage.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BuyedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Insignificant")
                        .HasColumnType("bit");

                    b.Property<int>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceInStorageAndCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Storage.MatereialsInInko", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Insignificant")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceInStorageAndCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quаntity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeInInko")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MatereialsInInko");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Storage.ToolsCreatedAndBuyedByInko", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BoughtFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BuyedOrCreated")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CreatedFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insignificant")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceInStorageAndCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeBought")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeWhenCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ToolsCreatedAndBoughtByInko");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Storage.WareInko", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ActiveOrOld")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Insignificant")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeActiveAndHowOld")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WaresInko");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransactionPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AdvancePayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Descriotion")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LinkDocuments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TransactionPayments");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatetimeArrive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatetimeOrdered")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromCompany")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ToClient")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransportAndTransactionPayment", b =>
                {
                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionPaymentsId")
                        .HasColumnType("int");

                    b.HasKey("TransportId", "TransactionPaymentsId");

                    b.HasIndex("TransactionPaymentsId");

                    b.ToTable("TransportAndTransactionPayments");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransportClient", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "TransportId");

                    b.HasIndex("TransportId");

                    b.ToTable("TransportClients");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Client", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Invoice", "Invoice")
                        .WithMany("Clients")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ClientsOrder", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Order", "Order")
                        .WithMany("Clients")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ClientsTransaction", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany("TransactionPayments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.TransactionPayment", "TransactionPayment")
                        .WithMany("Clients")
                        .HasForeignKey("TrasactionPaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("TransactionPayment");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.DeliveryClient", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany("Deliveries")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Delivery", "Delivery")
                        .WithMany("Clients")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Transport", null)
                        .WithMany("ClientsDelivery")
                        .HasForeignKey("TransportId");

                    b.Navigation("Client");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Document", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Transport", "Transport")
                        .WithMany("Documents")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Order", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Product", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", null)
                        .WithMany("ProductsClient")
                        .HasForeignKey("ClientId");

                    b.HasOne("InkoOrders.Data.Model.Order", null)
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId");

                    b.HasOne("InkoOrders.Data.Model.Transport", null)
                        .WithMany("ProductsOrdered")
                        .HasForeignKey("TransportId");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.ProductsToDeliveryToOrderToTransactionPaymentToTransport", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Delivery", "Delivery")
                        .WithMany("Products")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Product", "Product")
                        .WithMany("ProDelOrdTranPayTran")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.TransactionPayment", "TransactionPayment")
                        .WithMany("Products")
                        .HasForeignKey("TransactionPaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Transport", "Transport")
                        .WithMany("Products")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Delivery");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("TransactionPayment");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransportAndTransactionPayment", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.TransactionPayment", "TransactionPayment")
                        .WithMany("Transports")
                        .HasForeignKey("TransactionPaymentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Transport", "Transport")
                        .WithMany("TransactionPayments")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TransactionPayment");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransportClient", b =>
                {
                    b.HasOne("InkoOrders.Data.Model.Client", "Client")
                        .WithMany("TransportClients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InkoOrders.Data.Model.Transport", "Transport")
                        .WithMany("ClientsTransport")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Client", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("ProductsClient");

                    b.Navigation("TransactionPayments");

                    b.Navigation("TransportClients");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Delivery", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Invoice", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Order", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("OrderedProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Product", b =>
                {
                    b.Navigation("ProDelOrdTranPayTran");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.TransactionPayment", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Products");

                    b.Navigation("Transports");
                });

            modelBuilder.Entity("InkoOrders.Data.Model.Transport", b =>
                {
                    b.Navigation("ClientsDelivery");

                    b.Navigation("ClientsTransport");

                    b.Navigation("Documents");

                    b.Navigation("Products");

                    b.Navigation("ProductsOrdered");

                    b.Navigation("TransactionPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
