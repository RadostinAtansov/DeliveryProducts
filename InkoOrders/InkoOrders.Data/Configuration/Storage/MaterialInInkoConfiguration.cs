
using InkoOrders.Data.Model.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration.Storage
{
    public class MaterialInInkoConfiguration : IEntityTypeConfiguration<MaterialsInInko>
    {
        public void Configure(EntityTypeBuilder<MaterialsInInko> material)
        {
            material
                .HasMany<InvoicesStorageMaterial>(c => c.InvoicesMaterial)
                .WithOne(x => x.Material)
                .HasForeignKey(k => k.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
