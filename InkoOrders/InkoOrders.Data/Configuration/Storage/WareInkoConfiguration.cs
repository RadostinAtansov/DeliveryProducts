using InkoOrders.Data.Model.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration.Storage
{
    public class WareInkoConfiguration : IEntityTypeConfiguration<WareInko>
    {
        public void Configure(EntityTypeBuilder<WareInko> ware)
        {
            ware
                .HasMany<InvoicesStorageWare>(i => i.InvoicesWares)
                .WithOne(w => w.Ware)
                .HasForeignKey(k => k.WareInkoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
