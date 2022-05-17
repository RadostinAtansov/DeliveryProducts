using InkoOrders.Data.Model;
using InkoOrders.Data.Model.Storage;
using Microsoft.EntityFrameworkCore;

namespace InkoOrders.Data
{
    public class InkoOrdersDBContext : DbContext
    {
        //ClientDelivery
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientsOrder> ClientOrders { get; set; }
        public DbSet<ClientsTransaction> ClientTransactions { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryClient> DeliveryClients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<RegisterOrderForProduction> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport> ProductsToDeliveryToOrderToTransports { get; set; }
        public DbSet<TransactionPayment> TransactionPayments { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportAndTransactionPayment> TransportAndTransactionPayments { get; set; }
        public DbSet<TransportClient> TransportClients { get; set; }

        //Storage
        public DbSet<Component> Components { get; set; }
        public DbSet<MaterialsInInko> MaterialsInInko { get; set; }
        public DbSet<ToolsCreatedAndBuyedByInko> ToolsCreatedAndBoughtByInko { get; set; }
        public DbSet<WareInko> WaresInko { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(DataSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
