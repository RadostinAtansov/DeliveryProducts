using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IWareInkoService
    {
        void AddWare(AddWareServiceViewModel model, string path);
        void Edit(EditWareServiceViewModel model);
        void AddInvoiceToWare(AddInvoiceWareServiceViewModel model, string path);
    }
}
