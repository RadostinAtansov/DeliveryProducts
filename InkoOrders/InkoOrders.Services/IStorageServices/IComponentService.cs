using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IComponentService
    {
        void AddComponent(AddComponentServiceViewModel model, string path);
        void AddInvoiceComponent(AddInvoiceComponentServiceViewModel model, string path);
        void Edit(EditComponentServiceViewModel model);
        EditComponentServiceViewModel Edit(int id);
    }
}
