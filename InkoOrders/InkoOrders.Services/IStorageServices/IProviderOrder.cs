using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IProviderOrder
    {
        void AddProviderOrder(AddProviderServiceViewModel model);
        void EditOrder(EditProviderOrdertServiceViewModel model);
        void AddInvoicetoOrder(AddInvoiceProviderOrderServiceViewModel model, string path);
    }
}
