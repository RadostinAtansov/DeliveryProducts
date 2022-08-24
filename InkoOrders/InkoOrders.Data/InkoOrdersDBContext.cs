using InkoOrders.Data.Model;
using InkoOrders.Data.Model.Accounting;
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
        public DbSet<Document> Documents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport> ProductsToDeliveryToOrderToTransports { get; set; }
        public DbSet<RegisterOrderForProduction> RegisterOrderForProductions { get; set; }
        public DbSet<TransactionPayment> TransactionPayments { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportAndTransactionPayment> TransportAndTransactionPayments { get; set; }
        public DbSet<TransportClient> TransportClients { get; set; }

        //Storage
        public DbSet<Component> Components { get; set; }
        public DbSet<MaterialsInInko> MaterialsInInko { get; set; }
        public DbSet<ToolCreatedByInko> ToolCreatedByInko { get; set; }
        public DbSet<ToolBoughtByInko> TooldBoughtByInko { get; set; }
        public DbSet<WareInko> WaresInko { get; set; }
        public DbSet<ProviderOrder> ProviderOrders { get; set; }
        public DbSet<InvoicesStorageComponent> InvoicesStorageComponents { get; set; }
        public DbSet<InvoicesStorageMaterial> InvoicesStorageMaterials { get; set; }
        public DbSet<InvoicesStorageWare> InvoicesStorageWares { get; set; }
        public DbSet<InvoicesStorageToolBoughtByInko> InvoicesStorageToolBoughtByInkos { get; set; }
        public DbSet<InvoiceStorageProviderOrder> InvoiceStorageProviderOrders { get; set; }
        public DbSet<HistoryStorage> HistoryStorages { get; set; }
        public DbSet<HistoryWrittenOffStock> HistoryWrittenOffStocks { get; set; }
        public DbSet<StockToWriteOff> StockToWriteOffs { get; set; }

        //Accounting
        public DbSet<BankIncomeExpencesUtilitiBills> BankIncomeExpencesUtilitiBills { get; set; }
        public DbSet<BankPayments> BankPayments { get; set; }
        public DbSet<Expences> Expences { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<UtilityBills> UtilityBills { get; set; }

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
