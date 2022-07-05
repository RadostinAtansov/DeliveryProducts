using InkoOrders.Data.Model.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Component = InkoOrders.Data.Model.Storage.Component;

namespace InkoOrders.Data.Configuration.Storage
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> component)
        {
            component
                .HasMany<InvoicesStorageComponent>(c => c.InvoiceComponents)
                .WithOne(c => c.Component)
                .HasForeignKey(fk => fk.ComponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
