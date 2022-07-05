using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IComponentService
    {
        void AddInvoiceComponent(AddInvoiceComponentServiceViewModel model, string path);
        void AddComponent(AddComponentServiceViewModel model, string path);
        void Edit(EditComponentServiceViewModel model);
    }
}
