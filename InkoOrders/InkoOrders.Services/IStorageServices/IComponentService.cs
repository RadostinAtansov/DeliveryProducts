using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IComponentService
    {
        void AddComponent(AddComponentServiceViewModel component, string path);
        void AddInvoiceComponent(AddInvoiceComponentServiceViewModel model, string path);
    }
}
