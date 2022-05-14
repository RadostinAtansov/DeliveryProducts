using InkoOrders.Data.Model.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration.Accounting
{
    public class BankIncomeExpencesUtilitiBillsConfiguration : IEntityTypeConfiguration<BankIncomeExpencesUtilitiBills>
    {
        public void Configure(EntityTypeBuilder<BankIncomeExpencesUtilitiBills> bieub)
        {
            bieub.HasKey(k => new { k.IncomeId, k.BankPaymentsId, k.UtilityBillsId, k.ExpencesId });

            //1
            bieub
                .HasOne(b => b.BankPayment)
                .WithMany(b => b.BankIncomeExpencesUtility)
                .HasForeignKey(b => b.BankPaymentsId)
                .OnDelete(DeleteBehavior.Restrict);

            bieub
                .HasOne(b => b.Income)
                .WithMany(b => b.IncomePayments)
                .HasForeignKey(b => b.IncomeId)
                .OnDelete(DeleteBehavior.Restrict);

            //2
            bieub
                .HasOne(b => b.BankPayment)
                .WithMany(b => b.BankIncomeExpencesUtility)
                .HasForeignKey(b => b.BankPaymentsId)
                .OnDelete(DeleteBehavior.Restrict);

            bieub
                .HasOne(b => b.Expence)
                .WithMany(b => b.ExpencesPayments)
                .HasForeignKey(b => b.ExpencesId)
                .OnDelete(DeleteBehavior.Restrict);


            //3
            bieub
                .HasOne(b => b.BankPayment)
                .WithMany(b => b.BankIncomeExpencesUtility)
                .HasForeignKey(b => b.BankPaymentsId)
                .OnDelete(DeleteBehavior.Restrict);

            bieub
                .HasOne(b => b.UtilityBill)
                .WithMany(b => b.UtilityPayments)
                .HasForeignKey(b => b.UtilityBillsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
